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
    [Route("estados")]
    public class EstadosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userIdentity;

        public EstadosController(ApplicationDbContext context, UserManager<IdentityUser> userIdentity)
        {
            _context = context;
            _userIdentity = userIdentity;
        }

        [Route("listar")]
        [ClaimsAuthorize("Estados", "CL")]
        public async Task<IActionResult> Index(string busca, bool? ativo, int itensPorPagina = 10, int pagina = 1)
        {
            //var applicationDbContext = _context.Estados.Include(e => e.Pais);
            //return View(await applicationDbContext.ToListAsync());

            if (pagina < 1)
            {
                pagina = 1;
            }

            var estados = _context.Estados
                                .Include(p => p.Pais)
                                .AsQueryable();

            if (!string.IsNullOrEmpty(busca))
            {

                estados = estados.Where(e => e.EstadoNome.Contains(busca)
                                            || e.EstadoSigla.Contains(busca)
                                            || e.EstadoCodIbge.Contains(busca)
                                            || e.Pais.PaisNome.Contains(busca)
                                            || e.Pais.PaisNomeIngles.Contains(busca));
            }

            // Calcula o total de registros
            var totalRegistros = await estados.CountAsync();

            if (ativo.HasValue)
            {
                estados = estados.Where(c => c.Ativo == ativo);
            }
            else
            {
                estados = estados.Where(c => c.Ativo == true);
            }

            ViewData["count"] = estados.Count();
            ViewData["itensPorPagina"] = itensPorPagina;
            ViewData["pagina"] = pagina;
            ViewData["totalPaginas"] = Math.Ceiling((double)estados.Count() / itensPorPagina);
            ViewData["ativo"] = ativo;
            ViewData["totalRegistros"] = totalRegistros;

            return View(await estados.Skip((pagina - 1) * itensPorPagina).Take(itensPorPagina).ToListAsync());
        }

        [Route("detalhes")]
        [ClaimsAuthorize("Estados", "CD")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _context.Estados
                .Include(p => p.Pais)
                .FirstOrDefaultAsync(e => e.EstadoId == id);
            
            if (estado == null)
            {
                return NotFound();
            }

            return View(estado);
        }

        [Route("criar")]
        [ClaimsAuthorize("Estados", "CA")]
        public IActionResult Create()
        {
            ViewData["PaisId"] = new SelectList(_context.Paises.Where(p => p.Ativo), "PaisId", "PaisNome");
            return View();
        }

        private bool EstadoNomeExists(string estadoNome)
        {
            return _context.Estados.Any(e => e.EstadoNome == estadoNome);  
        }

        private bool EstadoSiglaExists(string estadoSigla)
        {
            return _context.Estados.Any(e => e.EstadoSigla == estadoSigla);            
        }

        [Route("criar")]
        [ClaimsAuthorize("Estados", "CA")]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("EstadoId,EstadoSigla,EstadoNome,EstadoCodIbge,PaisId")] Estado estado)
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

                    if (EstadoNomeExists(estado.EstadoNome))
                    {
                        ModelState.AddModelError("EstadoNome", "Já existe um estado com esse nome registrado. Verifique se não está inativo pela listagem de Estados.");
                        ViewData["PaisId"] = new SelectList(_context.Paises.Where(p => p.Ativo), "PaisId", "PaisNome", estado.PaisId);
                        return View(estado);
                    }

                    if (EstadoSiglaExists(estado.EstadoSigla))
                    {
                        ModelState.AddModelError("EstadoSigla", "Já existe uma sigla com esse nome registrado. Verifique se não está inativo pela listagem de ESatdos.");
                        ViewData["PaisId"] = new SelectList(_context.Paises.Where(p => p.Ativo), "PaisId", "PaisNome", estado.PaisId);
                        return View(estado);
                    }

                    estado.Ativo = true;

                    estado.Updated = DateTime.Now;
                    estado.Created = DateTime.Now;
                    estado.UserInserted = userLogin.Id;
                    estado.UserUpdated = userLogin.Id;

                    _context.Add(estado);
                    await _context.SaveChangesAsync();

                    TempData["save"] = "O Estado foi criado com sucesso!";

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                TempData["exception"] = ex.ToString();
                return RedirectToAction(nameof(Index));
            }

            ViewData["PaisId"] = new SelectList(_context.Paises.Where(p => p.Ativo), "PaisId", "PaisNome", estado.PaisId);

            return View(estado);            
        }

        [HttpGet("editar/{id:int}")]
        [ClaimsAuthorize("Estados", "CE")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _context.Estados.FindAsync(id);

            if (estado == null)
            {
                return NotFound();
            }

            var paisesAtivos = _context.Paises.Where(p => p.Ativo).ToList();

            var paisAssociado = _context.Paises.FirstOrDefault(p => p.PaisId == estado.PaisId);

            if (paisAssociado != null && !paisAssociado.Ativo)
            {
                paisesAtivos.Add(paisAssociado);
            }

            ViewData["PaisId"] = new SelectList(paisesAtivos, "PaisId", "PaisNome", estado.PaisId);

            return View(estado);
        }

        [HttpPost("editar/{id:int}")]
        [ClaimsAuthorize("Estados", "CE")]
        [HttpPost]       
        public async Task<IActionResult> Edit(int id, [Bind("EstadoId,EstadoSigla,EstadoNome,EstadoCodIbge,PaisId,Ativo")] Estado estado)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var estado_data_base = await _context.Estados.AsNoTracking().FirstOrDefaultAsync(e => e.EstadoId == id);

                    if (estado_data_base == null)
                    {
                        return NotFound();
                    }

                    var userLogin = await _userIdentity.GetUserAsync(User);

                    if (userLogin != null)
                    {
                        var userId = userLogin.Id;
                    }

                    if (EstadoNomeExists(estado.EstadoNome) && estado.EstadoNome != estado_data_base.EstadoNome)
                    {
                        ModelState.AddModelError("EstadoNome", "Já existe um estado com esse nome registrado. Verifique se não está inativo pela listagem de Estados.");

                        var paisesAtivos = _context.Paises.Where(p => p.Ativo).ToList();

                        var paisAssociado = _context.Paises.FirstOrDefault(p => p.PaisId == estado.PaisId);

                        if (paisAssociado != null && !paisAssociado.Ativo)
                        {
                            paisesAtivos.Add(paisAssociado);
                        }

                        ViewData["PaisId"] = new SelectList(paisesAtivos, "PaisId", "PaisNome", estado.PaisId);

                        return View(estado);
                    }

                    if (EstadoSiglaExists(estado.EstadoSigla) && estado.EstadoNome != estado_data_base.EstadoNome)
                    {
                        ModelState.AddModelError("EstadoSigla", "Já existe uma sigla com esse nome registrado. Verifique se não está inativo pela listagem de Estados.");

                        var paisesAtivos = _context.Paises.Where(p => p.Ativo).ToList();

                        var paisAssociado = _context.Paises.FirstOrDefault(p => p.PaisId == estado.PaisId);

                        if (paisAssociado != null && !paisAssociado.Ativo)
                        {
                            paisesAtivos.Add(paisAssociado);
                        }

                        ViewData["PaisId"] = new SelectList(paisesAtivos, "PaisId", "PaisNome", estado.PaisId);

                        return View(estado);
                    }                    

                    estado.Updated = DateTime.Now;
                    estado.Created = estado_data_base.Created;
                    estado.UserInserted = userLogin.Id;
                    estado.UserUpdated = userLogin.Id;

                    _context.Update(estado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!EstadoExists(estado.EstadoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        TempData["exception"] = ex.ToString();
                        return RedirectToAction(nameof(Index));
                    }
                }  

                TempData["save"] = "O Estado foi atualizado com sucesso!";

                return RedirectToAction(nameof(Index));
            }

            ViewData["PaisId"] = new SelectList(_context.Paises.Where(p => p.Ativo), "PaisId", "PaisNome", estado.PaisId);

            return View(estado);            
        }

        [HttpGet("excluir/{id:int}")]
        [ClaimsAuthorize("Estados", "CR")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _context.Estados
                .Include(e => e.Pais)
                .FirstOrDefaultAsync(m => m.EstadoId == id);

            if (estado == null)
            {
                return NotFound();
            }

            return View(estado);
        }

        [HttpPost("inativar/{id:int}")]
        [ClaimsAuthorize("Estados", "CR")]
        public async Task<IActionResult> Inativar(int id)
        {
            var estado = await _context.Estados                
                .FirstOrDefaultAsync(m => m.EstadoId == id);

            if (estado == null)
            {
                return NotFound();
            }            

            try
            {
                estado.Ativo = false;

                _context.Estados.Update(estado);

                await _context.SaveChangesAsync();

                TempData["delete"] = "O Estado foi desativado com sucesso!";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["exception"] = ex.ToString();
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost("excluir/{id:int}"), ActionName("Delete")]
        [ClaimsAuthorize("Estados", "CR")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estado = await _context.Estados.FindAsync(id);

            if (estado != null)
            {
                _context.Estados.Remove(estado);
            }

            try
            {
                await _context.SaveChangesAsync();

                TempData["delete"] = "O Estado foi excluído com sucesso!";

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

        private bool EstadoExists(int id)
        {
            return _context.Estados.Any(e => e.EstadoId == id);
        }
    }
}
