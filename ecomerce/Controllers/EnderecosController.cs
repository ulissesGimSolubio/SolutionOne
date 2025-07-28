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

namespace Ecomerce.Controllers
{
    [Authorize]
    [Route("clientes/enderecos")]
    public class EnderecosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userIdentity;

        public EnderecosController(ApplicationDbContext context, UserManager<IdentityUser> userIdentity)
        {
            _context = context;
            _userIdentity = userIdentity;
        }

        [Route("listar")]
        [ClaimsAuthorize("ClientesEnderecos", "CL")]
        public async Task<IActionResult> Index(string busca, bool? ativo, int itensPorPagina = 10, int pagina = 1)
        {
            //var applicationDbContext = _context.Enderecos.Include(e => e.Cidade).Include(e => e.Cliente);
            //return View(await applicationDbContext.ToListAsync());

            if (pagina < 1)
            {
                pagina = 1;
            }

            var enderecos = _context.Enderecos
                                .Include(c => c.Cidade)
                                .Include(c => c.Cliente)
                                .AsQueryable();

            if (!string.IsNullOrEmpty(busca))
            {

                enderecos = enderecos.Where(e => e.Cep.Contains(busca)
                                            || e.Logradouro.Contains(busca)
                                            || e.Numero.ToString().Contains(busca)
                                            || e.Complemento.Contains(busca)
                                            || e.InformacaoReferencia.Contains(busca)
                                            || e.Bairro.Contains(busca)
                                            || e.Cidade.CidadeNome.Contains(busca)
                                            || e.Cliente.Nome.Contains(busca)
                                            || e.Cliente.NomeRazaoSoc.Contains(busca));
            }

            // Calcula o total de registros
            var totalRegistros = await enderecos.CountAsync();

            if (ativo.HasValue)
            {
                enderecos = enderecos.Where(c => c.Ativo == ativo);
            }
            else
            {
                enderecos = enderecos.Where(c => c.Ativo == true);
            }

            ViewData["count"] = enderecos.Count();
            ViewData["itensPorPagina"] = itensPorPagina;
            ViewData["pagina"] = pagina;
            ViewData["totalPaginas"] = Math.Ceiling((double)enderecos.Count() / itensPorPagina);
            ViewData["ativo"] = ativo;
            ViewData["totalRegistros"] = totalRegistros;

            return View(await enderecos.Skip((pagina - 1) * itensPorPagina).Take(itensPorPagina).ToListAsync());
        }

        private bool EnderecoExists(string cep, string logradouro, string numero, string complemento, string cpfCnpj)
        {
            cep = cep.Replace("-", "").Replace(".", "").Trim();

            var enderecos = _context.Enderecos.Include(c => c.Cliente).AsQueryable();            

            enderecos = enderecos.Where(e => e.Cep == cep
                                        && e.Logradouro == logradouro
                                        && e.Numero.ToString() == numero
                                        && e.Complemento == complemento
                                        && e.Cliente.CpfCnpj == cpfCnpj);

            var totalRegistros = enderecos.Count();

            if (enderecos.Count() > 0)
            {
                return true;
            }

            return false;
        }

        /*
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
        */

        [Route("detalhes")]
        [ClaimsAuthorize("ClientesEnderecos", "CD")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Enderecos
                .Include(e => e.Cidade)
                .Include(e => e.Cliente)
                .Include(e => e.Cidade.Estado)
                .FirstOrDefaultAsync(m => m.EnderecoId == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }
       
        [Route("criar")]
        [ClaimsAuthorize("ClientesEnderecos", "CA")]
        public IActionResult Create()
        {
            ViewData["CidadeId"] = new SelectList(_context.Cidades, "CidadeId", "CidadeNome");
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "CpfCnpj", "Nome");
            return View();
        }

        [Route("criar")]
        [ClaimsAuthorize("ClientesEnderecos", "CA")]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("EnderecoId,Cep,Logradouro,Numero,Complemento,InformacaoReferencia,Bairro,CidadeId,EnderecoPrincipal,ClienteId,EnderecoPrincipal")] Endereco endereco)
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

                    if(EnderecoExists(endereco.Cep, endereco.Logradouro, endereco.Numero.ToString(), endereco.Complemento, endereco.ClienteId))
                    {
                        ModelState.AddModelError("Complemento", "Já existe um endereço com estas informaçãoes para o cliente selecionado, tente informar algo direferente para a chave (Cep + Logradouro + Numero + Complemento de Informações + Cliente).");

                        ViewData["CidadeId"] = new SelectList(_context.Cidades, "CidadeId", "CidadeNome");
                        ViewData["ClienteId"] = new SelectList(_context.Clientes, "CpfCnpj", "Nome");

                        return View(endereco);
                    }

                    endereco.Ativo = true;
                    endereco.Cep = endereco.Cep.Replace("-", "").Replace(".", "").Trim();
                    endereco.Updated = DateTime.Now;
                    endereco.Created = DateTime.Now;
                    endereco.UserInserted = userLogin.Id;
                    endereco.UserUpdated = userLogin.Id;

                    _context.Add(endereco);
                    await _context.SaveChangesAsync();

                    TempData["save"] = "O Endereço foi criado com sucesso!";

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                TempData["exception"] = ex.ToString();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CidadeId"] = new SelectList(_context.Cidades, "CidadeId", "CidadeNome");
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "CpfCnpj", "Nome");

            return View(endereco);
        }

        [HttpGet("editar/{id:int}")]
        [ClaimsAuthorize("ClientesEnderecos", "CE")]
        public async Task<IActionResult> Edit(int? id)
        {     
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Enderecos.FindAsync(id);

            endereco.Cep = Ecomerce.Extensions.Helpers.FormatarCep(endereco.Cep);

            if (endereco == null)
            {
                return NotFound();
            }

            //Cidade
            var cidadeAtivas = _context.Cidades.Where(c => c.Ativo).ToList();
            var cidadeAssociada = _context.Cidades.FirstOrDefault(c => c.CidadeId == endereco.CidadeId);
            if (cidadeAssociada != null && !cidadeAssociada.Ativo)
            {
                cidadeAtivas.Add(cidadeAssociada);
            }
            ViewData["CidadeId"] = new SelectList(cidadeAtivas, "CidadeId", "CidadeNome", endereco.CidadeId);

            //ViewData["CidadeId"] = new SelectList(_context.Cidades, "CidadeId", "CidadeNome");

            //Cliente
            var clientesAtivos = _context.Clientes.Where(c => c.Ativo).ToList();
            var clientesAssociados = _context.Clientes.FirstOrDefault(c => c.CpfCnpj == endereco.ClienteId);
            if (clientesAssociados != null && !clientesAssociados.Ativo)
            {
                clientesAtivos.Add(clientesAssociados);
            }
            ViewData["ClienteId"] = new SelectList(clientesAtivos, "CpfCnpj", "Nome", endereco.ClienteId);

            //ViewData["ClienteId"] = new SelectList(_context.Clientes, "CpfCnpj", "Nome");

            return View(endereco);
        }

        [HttpPost("editar/{id:int}")]
        [ClaimsAuthorize("ClientesEnderecos", "CE")]
        public async Task<IActionResult> Edit(int id, [Bind("EnderecoId,Ativo,Cep,Logradouro,Numero,Complemento,InformacaoReferencia,Bairro,CidadeId,EnderecoPrincipal,ClienteId,EnderecoPrincipal")] Endereco endereco)
        {
            var appRedirect = TempData["app"] as string;
            
            if (ModelState.IsValid)
            {
                try
                {  
                    if (id != endereco.EnderecoId)
                    {
                        return NotFound();
                    }

                    var userLogin = await _userIdentity.GetUserAsync(User);

                    if (userLogin != null)
                    {
                        var userId = userLogin.Id;
                    }

                    var endereco_data_base = await _context.Enderecos.AsNoTracking().FirstOrDefaultAsync(e => e.EnderecoId == endereco.EnderecoId);

                    var endPrincipal = endereco.EnderecoPrincipal;

                    if (EnderecoExists(endereco.Cep, endereco.Logradouro, endereco.Numero.ToString(), endereco.Complemento, endereco.ClienteId) && endereco.EnderecoId != endereco_data_base.EnderecoId)
                    {
                        ModelState.AddModelError("Complemento", "Já existe um endereço com estas informaçãoes para o cliente selecionado, tente informar algo direferente para a chave (Cep + Logradouro + Numero + Complemento de Informações + Cliente).");

                        //Cidade
                        var cidadeAtivas2 = _context.Cidades.Where(c => c.Ativo).ToList();
                        var cidadeAssociada2 = _context.Cidades.FirstOrDefault(c => c.CidadeId == endereco.CidadeId);
                        if (cidadeAssociada2 != null && !cidadeAssociada2.Ativo)
                        {
                            cidadeAtivas2.Add(cidadeAssociada2);
                        }
                        ViewData["CidadeId"] = new SelectList(cidadeAtivas2, "CidadeId", "CidadeNome", endereco.CidadeId);

                        //Cliente
                        var clientesAtivos2 = _context.Clientes.Where(c => c.Ativo).ToList();
                        var clientesAssociados2 = _context.Clientes.FirstOrDefault(c => c.CpfCnpj == endereco.ClienteId);
                        if (clientesAssociados2 != null && !clientesAssociados2.Ativo)
                        {
                            clientesAtivos2.Add(clientesAssociados2);
                        }
                        ViewData["ClienteId"] = new SelectList(clientesAtivos2, "CpfCnpj", "Nome", endereco.ClienteId);

                        return View(endereco);
                    }                   

                    endereco.Cep = endereco.Cep.Replace("-", "").Replace(".", "").Trim();
                    endereco.Created = endereco_data_base.Created;
                    endereco.UserInserted = endereco_data_base.UserInserted;
                    endereco.Updated = DateTime.Now;
                    endereco.UserUpdated = userLogin.Id;

                    _context.Update(endereco);
                    await _context.SaveChangesAsync();

                    if(endPrincipal == true)
                    {
                        // Obter todos os endereços associados ao cliente
                        var enderecosDoCliente = await _context.Enderecos.Where(e => e.ClienteId == endereco.ClienteId).ToListAsync();

                        // Iterar sobre todos os endereços do cliente
                        foreach (var enderecoCliente in enderecosDoCliente)
                        {
                            // Define o "Endereço Principal" como false para todos os endereços do cliente, exceto o endereço atual
                            if (enderecoCliente.EnderecoId != endereco.EnderecoId)
                            {
                                enderecoCliente.EnderecoPrincipal = false;
                                _context.Update(enderecoCliente);
                            }
                            else
                            {
                                enderecoCliente.EnderecoPrincipal = true;
                                _context.Update(enderecoCliente);
                            }
                        }
                        await _context.SaveChangesAsync();
                    }

                    TempData["update"] = "O Endereco foi atualizado com sucesso!";

                    switch(appRedirect)
                    {
                        case "DetailsClientes":
                            return RedirectToAction("Details", "Clientes", new { id = endereco.ClienteId });
                        case "IndexEndereços":
                            return RedirectToAction(nameof(Index));
                        default:
                            return RedirectToAction(nameof(Index));
                    }   
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!EnderecoExists(endereco.EnderecoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        TempData["exception"] = ex.ToString();
                        switch (appRedirect)
                        {
                            case "DetailsClientes":
                                return RedirectToAction("Details", "Clientes", new { id = endereco.ClienteId });
                            case "IndexEndereços":
                                return RedirectToAction(nameof(Index));
                            default:
                                return RedirectToAction(nameof(Index));
                        }
                    }
                }
                
            }

            //Cidade
            var cidadeAtivas = _context.Cidades.Where(c => c.Ativo).ToList();
            var cidadeAssociada = _context.Cidades.FirstOrDefault(c => c.CidadeId == endereco.CidadeId);
            if (cidadeAssociada != null && !cidadeAssociada.Ativo)
            {
                cidadeAtivas.Add(cidadeAssociada);
            }
            ViewData["CidadeId"] = new SelectList(cidadeAtivas, "CidadeId", "CidadeNome", endereco.CidadeId);

            //Cliente
            var clientesAtivos = _context.Clientes.Where(c => c.Ativo).ToList();
            var clientesAssociados = _context.Clientes.FirstOrDefault(c => c.CpfCnpj == endereco.ClienteId);
            if (clientesAssociados != null && !clientesAssociados.Ativo)
            {
                clientesAtivos.Add(clientesAssociados);
            }
            ViewData["ClienteId"] = new SelectList(clientesAtivos, "CpfCnpj", "Nome", endereco.ClienteId);

            return View(endereco);
        }

        [HttpGet("excluir/{id:int}")]
        [ClaimsAuthorize("ClientesEnderecos", "CR")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Enderecos
                .Include(e => e.Cidade)
                .Include(e => e.Cliente)
                .Include(e => e.Cidade.Estado)
                .FirstOrDefaultAsync(m => m.EnderecoId == id);

            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        [HttpPost("excluir/{id:int}"), ActionName("Delete")]
        [ClaimsAuthorize("ClientesEnderecos", "CR")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appRedirect = TempData["app"] as string;

            var endereco = await _context.Enderecos.FindAsync(id);

            if (endereco == null)
            {
                return NotFound();
            }

            try
            {
                endereco.Ativo = false;

                _context.Enderecos.Remove(endereco);

                await _context.SaveChangesAsync();

                TempData["delete"] = "O Endereco foi Removido com sucesso!";

                switch (appRedirect)
                {
                    case "DetailsClientes":
                        return RedirectToAction("Details", "Clientes", new { id = endereco.ClienteId });
                    case "IndexEndereços":
                        return RedirectToAction(nameof(Index));
                    default:
                        return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                TempData["exception"] = ex.ToString();

                switch (appRedirect)
                {
                    case "DetailsClientes":
                        return RedirectToAction("Details", "Clientes", new { id = endereco.ClienteId });
                    case "IndexEndereços":
                        return RedirectToAction(nameof(Index));
                    default:
                        return RedirectToAction(nameof(Index));
                }
            }
        }

        private bool EnderecoExists(int id)
        {
            return _context.Enderecos.Any(e => e.EnderecoId == id);
        }

        [HttpPost("inativar/{id:int}")]
        [ClaimsAuthorize("ClientesEnderecos", "CE")]
        public async Task<IActionResult> Inativar(int id)
        {
            var appRedirect = TempData["app"] as string;

            var endereco = await _context.Enderecos.FindAsync(id);

            if (endereco == null)
            {
                return NotFound();
            }

            try
            {
                endereco.Ativo = false;

                _context.Enderecos.Update(endereco);

                await _context.SaveChangesAsync();

                TempData["delete"] = "O Endereco foi desativado com sucesso!";

                switch (appRedirect)
                {
                    case "DetailsClientes":
                        return RedirectToAction("Details", "Clientes", new { id = endereco.ClienteId });
                    case "IndexEndereços":
                        return RedirectToAction(nameof(Index));
                    default:
                        return RedirectToAction(nameof(Index));
                }                
            }
            catch (Exception ex)
            {
                TempData["exception"] = ex.ToString();

                switch (appRedirect)
                {
                    case "DetailsClientes":
                        return RedirectToAction("Details", "Clientes", new { id = endereco.ClienteId });
                    case "IndexEndereços":
                        return RedirectToAction(nameof(Index));
                    default:
                        return RedirectToAction(nameof(Index));
                }
            }
        }
    }
}
