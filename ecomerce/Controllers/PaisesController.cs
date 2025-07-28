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
using AppSemTemplate.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;

namespace Ecomerce.Controllers
{
    [Authorize]
    [Route("paises")]
    public class PaisesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userIdentity;

        public PaisesController(ApplicationDbContext context, UserManager<IdentityUser> userIdentity)
        {
            _context = context;
            _userIdentity = userIdentity;
        }

        [Route("listar")]
        [ClaimsAuthorize("Paises", "CL")]
        // GET: Paises
        public async Task<IActionResult> Index(string busca, bool? ativo, int itensPorPagina = 10, int pagina = 1)
        {
           
            if (pagina < 1)
            {
                pagina = 1;
            }

            var paises = _context.Paises.AsQueryable();

            if (!string.IsNullOrEmpty(busca))
            {

                paises = paises.Where(p => p.PaisNome.Contains(busca)
                                            || p.PaisNomeIngles.Contains(busca)
                                            || p.PaisIsoCodigo.Contains(busca)
                                            || p.PaisCodigo.Contains(busca)
                                            || p.PaisMoeda.Contains(busca)
                                            || p.PaisMoedaAbrev.Contains(busca));
            }

            
            var totalRegistros = await paises.CountAsync();

            if (ativo.HasValue)
            {
                paises = paises.Where(c => c.Ativo == ativo);
            }
            else
            {
                paises = paises.Where(c => c.Ativo == true);
            }

            ViewData["count"] = paises.Count();
            ViewData["itensPorPagina"] = itensPorPagina;
            ViewData["pagina"] = pagina;
            ViewData["totalPaginas"] = Math.Ceiling((double)paises.Count() / itensPorPagina);
            ViewData["ativo"] = ativo;
            ViewData["totalRegistros"] = totalRegistros;

            return View(await paises.Skip((pagina - 1) * itensPorPagina).Take(itensPorPagina).ToListAsync());           
        }

        [Route("detalhes")]
        [ClaimsAuthorize("Paises", "CD")]
        // GET: Paises/Details/5
        public async Task<IActionResult> Details(int? id)
        {            
            if (id == null)
            {
                return NotFound();
            }

            var pais = await _context.Paises
                .FirstOrDefaultAsync(m => m.PaisId == id);
            if (pais == null)
            {
                return NotFound();
            }

            return View(pais);
        }

        [Route("criar")]
        [ClaimsAuthorize("Paises", "CA")]
        // GET: Paises/Create
        public IActionResult Create()
        {
            return View();
        }
               

        [Route("criar")]
        [ClaimsAuthorize("Paises", "CA")]
        // POST: Paises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("PaisId,PaisNome,PaisNomeIngles,PaisIsoCodigo,PaisCodigo,PaisMoeda,PaisMoedaAbrev")] Pais pais)
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

                    if (PaisNomeExists(pais.PaisNome))
                    {
                        ModelState.AddModelError("PaisNome", "Já existe um pais com esse nome registrado.");
                        return View(pais);
                    }

                    pais.Ativo = true;

                    pais.Updated = DateTime.Now;
                    pais.Created = DateTime.Now;
                    pais.UserInserted = userLogin.Id;
                    pais.UserUpdated = userLogin.Id;

                    _context.Add(pais);
                    await _context.SaveChangesAsync();

                    TempData["save"] = "O País foi criado com sucesso!";

                    return RedirectToAction(nameof(Index));
                }
            }
            catch(Exception ex)
            {
                TempData["exception"] = ex.ToString();
                return RedirectToAction(nameof(Index));
            }
            
            return View(pais);
        }

        
        [HttpGet("editar/{id:int}")]
        [ClaimsAuthorize("Paises", "CA")]
        // GET: Paises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pais = await _context.Paises.FindAsync(id);
            if (pais == null)
            {
                return NotFound();
            }
            return View(pais);
        }

        
        [HttpPost("editar/{id:int}")]
        [ClaimsAuthorize("Paises", "CE")]
        // POST: Paises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("PaisId,PaisNome,PaisNomeIngles,PaisIsoCodigo,PaisCodigo,PaisMoeda,PaisMoedaAbrev,Ativo")] Pais pais)
        {
            if (id != pais.PaisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var userLogin = await _userIdentity.GetUserAsync(User);

                    if (userLogin != null)
                    {                       
                        var userId = userLogin.Id;
                    }

                    Pais pais_data_base = await _context.Paises.AsNoTracking().FirstOrDefaultAsync(c => c.PaisId == id);

                    if (pais_data_base == null)
                    {
                        return NotFound();
                    }

                    pais.Updated = DateTime.Now;
                    pais.Created = pais_data_base.Created; 
                    pais.UserUpdated = userLogin.Id;

                    _context.Update(pais);
                    await _context.SaveChangesAsync();

                    TempData["save"] = "O País foi atualizado com sucesso!";
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!PaisExists(pais.PaisId))
                    {
                        TempData["Exception"] = "Houve uma concorrência de solicitação ao banco de dados, tente novamente.";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["exception"] = ex.ToString();
                        return RedirectToAction(nameof(Index));
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pais);
        }

        
        [HttpGet("excluir/{id:int}")]
        [ClaimsAuthorize("Paises", "CR")]
        // GET: Paises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pais = await _context.Paises
                .FirstOrDefaultAsync(m => m.PaisId == id);

            if (pais == null)
            {
                return NotFound();
            }

            return View(pais);
        }

        
        [HttpPost("excluir/{id:int}"), ActionName("Delete")]
        [ClaimsAuthorize("Paises", "CR")]
        // POST: Paises/Delete/5        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pais = await _context.Paises.FindAsync(id);

            try
            {
                if (pais != null)
                {
                    _context.Paises.Remove(pais);

                    await _context.SaveChangesAsync();

                    TempData["delete"] = "O País foi removido com sucesso!";

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }                

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

        [HttpPost("inativar/{id:int}")]
        [ClaimsAuthorize("Paises", "CR")]
        // POST: Paises/Delete/5        
        public async Task<IActionResult> Inativar(int id)
        {    
            var pais = await _context.Paises.FindAsync(id);

            if (pais == null)
            {
                return NotFound();
            }

            try
            {
                pais.Ativo = false;

                _context.Paises.Update(pais);

                await _context.SaveChangesAsync();

                TempData["delete"] = "O País foi desativado com sucesso!";

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                TempData["exception"] = ex.ToString();
                return RedirectToAction(nameof(Index));
            }

           
        }

        private bool PaisExists(int id)
        {
            return _context.Paises.Any(e => e.PaisId == id);
        }

        private bool PaisNomeExists(string nomePais)
        {
            return _context.Paises.Any(e => e.PaisNome == nomePais);
        }
    }
}
