using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ecomerce.Data;
using Ecomerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AppSemTemplate.Extensions;
using Microsoft.Data.SqlClient;

namespace Ecomerce.Controllers
{
    [Authorize]
    [Route("cidades")]
    public class CidadesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userIdentity;

        public CidadesController(ApplicationDbContext context, UserManager<IdentityUser> userIdentity)
        {
            _context = context;
            _userIdentity = userIdentity;
        }

        [Route("listar")]
        [ClaimsAuthorize("Cidades", "CL")]
        public async Task<IActionResult> Index(string busca, bool? ativo, int itensPorPagina = 10, int pagina = 1)
        {
            //var applicationDbContext = _context.Cidades.Include(c => c.Estado);
            //return View(await applicationDbContext.ToListAsync());

            if (pagina < 1)
            {
                pagina = 1;
            }

            var cidades = _context.Cidades
                                .Include(e => e.Estado)
                                .AsQueryable();

            if (!string.IsNullOrEmpty(busca))
            {

                cidades = cidades.Where(c => c.CidadeNome.Contains(busca)
                                            || c.CidadeCodigoIbge.Contains(busca)
                                            || c.Estado.EstadoNome.Contains(busca)
                                            || c.Estado.EstadoSigla.Contains(busca));
            }

            // Calcula o total de registros
            var totalRegistros = await cidades.CountAsync();

            if (ativo.HasValue)
            {
                cidades = cidades.Where(c => c.Ativo == ativo);
            }
            else
            {
                cidades = cidades.Where(c => c.Ativo == true);
            }

            ViewData["count"] = cidades.Count();
            ViewData["itensPorPagina"] = itensPorPagina;
            ViewData["pagina"] = pagina;
            ViewData["totalPaginas"] = Math.Ceiling((double)cidades.Count() / itensPorPagina);
            ViewData["ativo"] = ativo;
            ViewData["totalRegistros"] = totalRegistros;

            return View(await cidades.Skip((pagina - 1) * itensPorPagina).Take(itensPorPagina).ToListAsync());
        }

        [Route("detalhes")]
        [ClaimsAuthorize("Cidades", "CD")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidades
                .Include(e => e.Estado)
                .FirstOrDefaultAsync(c => c.CidadeId == id);

            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        [Route("criar")]
        [ClaimsAuthorize("Cidades", "CA")]
        public IActionResult Create()
        {
            ViewData["EstadoId"] = new SelectList(_context.Estados.Where(e => e.Ativo == true), "EstadoId", "EstadoNome");
            return View();
        }

        private bool CidadeInEstadoExists(int id, string cidadeNome, int estadoId)
        {
            var cidades = _context.Cidades.Where(e => e.EstadoId == estadoId).AsNoTracking();          

            if (cidades != null)
            {
                var cidade = cidades.FirstOrDefault(c => c.CidadeNome == cidadeNome);

                if (cidade != null)
                {
                    if(id == cidade.CidadeId)
                    {
                        return false;
                    }

                    return true;
                }
            }
            else
            {
                return false;
            }

            return false;
        }

        private bool CidadeExists(int id)
        {
            return _context.Cidades.Any(c => c.CidadeId == id);
        }

        [Route("criar")]
        [ClaimsAuthorize("Cidades", "CA")]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("CidadeId,CidadeNome,CidadeCodigoIbge,EstadoId")] Cidade cidade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userLogin = await _userIdentity.GetUserAsync(User);

                    if (userLogin != null)
                    {
                        var userId = userLogin.Id;
                    }

                    if (CidadeInEstadoExists(0, cidade.CidadeNome, cidade.EstadoId) == true)
                    {
                        ModelState.AddModelError("CidadeNome", "Já existe uma cidade com esse nome registrado para o estado selecionado. Verifique se não está inativo pela listagem de Cidades.");
                        ViewData["EstadoId"] = new SelectList(_context.Estados.Where(e => e.Ativo == true), "EstadoId", "EstadoNome", cidade.EstadoId);
                        return View(cidade);
                    }

                    cidade.Ativo = true;

                    cidade.Updated = DateTime.Now;
                    cidade.Created = DateTime.Now;
                    cidade.UserInserted = userLogin.Id;
                    cidade.UserUpdated = userLogin.Id;

                    _context.Add(cidade);
                    await _context.SaveChangesAsync();

                    TempData["save"] = "A Cidade foi criada com sucesso!";

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                TempData["exception"] = ex.ToString();
                return RedirectToAction(nameof(Index));
            }

            ViewData["EstadoId"] = new SelectList(_context.Estados.Where(e => e.Ativo == true), "EstadoId", "EstadoNome", cidade.EstadoId);

            return View(cidade);            
        }

        [HttpGet("editar/{id:int}")]
        [ClaimsAuthorize("Cidades", "CE")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidades.FindAsync(id);

            if (cidade == null)
            {
                return NotFound();
            }
            
            var estadosAtivos = _context.Estados.Where(e => e.Ativo).ToList();
           
            var estadoAssociado = _context.Estados.FirstOrDefault(e => e.EstadoId == cidade.EstadoId);
           
            if (estadoAssociado != null && !estadoAssociado.Ativo)
            {
                estadosAtivos.Add(estadoAssociado); 
            }
           
            ViewData["EstadoId"] = new SelectList(estadosAtivos, "EstadoId", "EstadoNome", cidade.EstadoId);           
            
            return View(cidade);
        }

        [HttpPost("editar/{id:int}")]
        [ClaimsAuthorize("Cidades", "CE")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("CidadeId,CidadeNome,CidadeCodigoIbge,EstadoId,Ativo")] Cidade cidade)
        {
            if (id != cidade.CidadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var cidade_data_base = await _context.Cidades.AsNoTracking().FirstOrDefaultAsync(c => c.CidadeId == id);

                    if (cidade_data_base == null)
                    {
                        return NotFound();
                    }

                    var userLogin = await _userIdentity.GetUserAsync(User);

                    if (userLogin != null)
                    {
                        var userId = userLogin.Id;
                    }

                    if (CidadeInEstadoExists(cidade.CidadeId, cidade.CidadeNome, cidade.EstadoId) == true)
                    {                        
                        ModelState.AddModelError("CidadeNome", "Já existe uma cidade com esse nome registrado para o estado selecionado. Verifique se não está inativo pela listagem de Cidades.");

                        var estadosAtivos = _context.Estados.Where(e => e.Ativo).ToList();

                        var estadoAssociado = _context.Estados.FirstOrDefault(e => e.EstadoId == cidade.EstadoId);

                        if (estadoAssociado != null && !estadoAssociado.Ativo)
                        {
                            estadosAtivos.Add(estadoAssociado);
                        }

                        ViewData["EstadoId"] = new SelectList(estadosAtivos, "EstadoId", "EstadoNome", cidade.EstadoId);

                        return View(cidade);
                    }



                    cidade.Updated = DateTime.Now;                    
                    cidade.UserUpdated = userLogin.Id;
                    cidade.Created = cidade_data_base.Created;
                    cidade.UserInserted = cidade_data_base.UserInserted;

                    _context.Update(cidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!CidadeExists(cidade.CidadeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        TempData["exception"] = ex.ToString();
                        return RedirectToAction(nameof(Index));
                    }
                }

                TempData["save"] = "A Cidade foi atualizada com sucesso!";

                return RedirectToAction(nameof(Index));
            }

            ViewData["EstadoId"] = new SelectList(_context.Estados.Where(e => e.Ativo == true), "EstadoId", "EstadoNome", cidade.EstadoId);

            return View(cidade);            
        }

        [HttpGet("excluir/{id:int}")]
        [ClaimsAuthorize("Cidades", "CR")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidades
                .Include(c => c.Estado)
                .FirstOrDefaultAsync(m => m.CidadeId == id);

            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        [HttpPost("excluir/{id:int}"), ActionName("Delete")]
        [ClaimsAuthorize("Cidades", "CR")]        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cidade = await _context.Cidades.FindAsync(id);

            if (cidade != null)
            {               
                try
                {
                    _context.Cidades.Remove(cidade);

                    await _context.SaveChangesAsync();

                    TempData["delete"] = "A cidade foi excluída com sucesso!";

                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateException ex)
                {
                    var innerException = ex.InnerException;

                    if (innerException is SqlException sqlException && sqlException.Number == 547)
                    {
                        TempData["delete"] = "Não foi possível excluir o registro, avalie se o mesmo não possui registros de associação que impedem essa remoção! Reavalie fazer a inativação em atualizar ou em remoção.";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["exception"] = ex.ToString();
                        return RedirectToAction(nameof(Index));
                    }                    
                }
            }
            else
            {
                return NotFound();
            }      

        }

        [HttpPost("inativar/{id:int}")]
        [ClaimsAuthorize("Cidades", "CE")]
        public async Task<IActionResult> Inativar(int id)
        {
            var cidade = await _context.Cidades
                .FirstOrDefaultAsync(c => c.CidadeId == id);

            if (cidade == null)
            {
                return NotFound();
            }

            try
            {
                cidade.Ativo = false;

                _context.Cidades.Update(cidade);

                await _context.SaveChangesAsync();

                TempData["delete"] = "A Cidade foi desativada com sucesso!";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["exception"] = ex.ToString();
                return RedirectToAction(nameof(Index));
            }
        }

    }
}
