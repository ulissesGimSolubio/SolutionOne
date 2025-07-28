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
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Ecomerce.Extensions;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Ecomerce.Controllers
{
    [Authorize]
    [Route("cliente")]
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userIdentity;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public ClientesController(ApplicationDbContext context, UserManager<IdentityUser> userIdentity, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _userIdentity = userIdentity;
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("listar")]
        [ClaimsAuthorize("Cliente", "CL")]
        public async Task<IActionResult> Index(string busca, bool? ativo, int itensPorPagina = 10, int pagina = 1)
        {
            if (pagina < 1)
            {
                pagina = 1;
            }

            var clientes = _context.Clientes.AsQueryable();

            if (!string.IsNullOrEmpty(busca))
            {
                DateTime dataBusca;
                if (DateTime.TryParse(busca, out dataBusca))
                {
                    clientes = clientes.Where(c => c.DataNascimento.Date == dataBusca.Date);
                }
                else
                {
                    clientes = clientes.Where(c => c.Nome.Contains(busca)
                                                || c.NomeRazaoSoc.Contains(busca)
                                                || c.Email.Contains(busca)
                                                || c.Apelido.Contains(busca)
                                                || c.CpfCnpj.Contains(busca)
                                                || c.TelefoneFixo.Contains(busca)
                                                || c.Celular.Contains(busca)
                                                || c.DataNascimento.Year.ToString() == busca
                                                || c.DataNascimento.Month.ToString() == busca
                                                || c.DataNascimento.Day.ToString() == busca);
                }
            }

            // Calcula o total de registros
            var totalRegistros = await clientes.CountAsync();

            if (ativo.HasValue)
            {
                clientes = clientes.Where(c => c.Ativo == ativo);
            }
            else
            {
                clientes = clientes.Where(c => c.Ativo == true);
            }

            ViewData["count"] = clientes.Count();
            ViewData["itensPorPagina"] = itensPorPagina;
            ViewData["pagina"] = pagina;
            ViewData["totalPaginas"] = Math.Ceiling((double)clientes.Count() / itensPorPagina);
            ViewData["ativo"] = ativo;
            ViewData["totalRegistros"] = totalRegistros;

            return View(await clientes.Skip((pagina - 1) * itensPorPagina).Take(itensPorPagina).ToListAsync());
        }

        [Route("detalhes")]
        [ClaimsAuthorize("Cliente", "CD")]
        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.Enderecos).ThenInclude(c => c.Cidade).ThenInclude(e => e.Estado).FirstOrDefaultAsync(m => m.CpfCnpj == id);               

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [Route("criar")]
        [ClaimsAuthorize("Cliente", "CA")]
        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        [Route("criar")]
        [ClaimsAuthorize("Cliente", "CA")]
        // POST: Clientes/Create        
        [HttpPost]
        public async Task<IActionResult> Create([Bind("TPessoa,CpfCnpj,Email,Nome,NomeRazaoSoc,Apelido,Genero,DataNascimento,Celular,TelefoneFixo,UpImage,Info")] Cliente cliente)
        {
            ModelState.Remove("Image"); // Remove a entrada para o campo Image do ModelState
            ModelState.Remove("UpImage"); // Remove a entrada para o campo Image do ModelState

            cliente.CpfCnpj = Helpers.DesformatarCpfCnpj(cliente.CpfCnpj);
            cliente.Celular = Helpers.DesformatarTelefone(cliente.Celular);
            cliente.TelefoneFixo = Helpers.DesformatarTelefone(cliente.TelefoneFixo);

            if (ModelState.IsValid)
            {
                // Obtém o usuário atualmente logado
                var userLogin = await _userIdentity.GetUserAsync(User);

                if (userLogin != null)
                {
                    // Faça o que precisa com o usuário
                    var userId = userLogin.Id;
                }

                if (ClienteExists(cliente.CpfCnpj))
                {
                    // Se existir, retorna à View de criação com uma mensagem de erro
                    ModelState.AddModelError("CpfCnpj", "Já existe um parceiro de negócios com este CNPJ.");
                    return View(cliente);
                }

                if (!IsCpfCnpj(cliente.CpfCnpj))
                {
                    // Se existir, retorna à View de criação com uma mensagem de erro
                    ModelState.AddModelError("CpfCnpj", "Informe um tipo de documento válido, para CPF são (11) caracteres e para CNPJ são (14) caracteres.");
                    return View(cliente);
                }

                cliente.Ativo = true;

                if (cliente.UpImage != null && cliente.UpImage.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images/cliente-images");
                    var nomeArquivo = cliente.CpfCnpj + Path.GetExtension(cliente.UpImage.FileName);
                    var caminhoArquivo = Path.Combine(uploadsFolder, nomeArquivo);

                    using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                    {
                        await cliente.UpImage.CopyToAsync(stream);
                        cliente.Image = nomeArquivo;
                    }
                }

                cliente.Updated = DateTime.Now;
                cliente.Created = DateTime.Now;
                cliente.UserInserted = userLogin.Id;
                cliente.UserUpdated = userLogin.Id;

                _context.Add(cliente);
                await _context.SaveChangesAsync();

                TempData["save"] = "O Parceiro de Negócios foi criado com sucesso!";

                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        [HttpGet("editar/{id:length(11,14)}")]
        [ClaimsAuthorize("Cliente", "CA")]
        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente != null)
            {
                cliente.TelefoneFixo = Helpers.FormatPhone(cliente.TelefoneFixo);
                cliente.Celular = Helpers.FormatCellPhone(cliente.Celular);
            }

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Edit/5       
        [HttpPost("editar/{id:length(11,14)}")]
        [ClaimsAuthorize("Cliente", "CE")]
        public async Task<IActionResult> Edit(string id, [Bind("TPessoa,CpfCnpj,Email,Nome,NomeRazaoSoc,Apelido,Genero,DataNascimento,Celular,TelefoneFixo,UpImage,Info,Ativo")] Cliente cliente)
        {
            ModelState.Remove("Image"); // Remove a entrada para o campo Image do ModelState
            ModelState.Remove("UpImage"); // Remove a entrada para o campo Image do ModelState

            cliente.CpfCnpj = Helpers.DesformatarCpfCnpj(cliente.CpfCnpj);
            cliente.Celular = Helpers.DesformatarTelefone(cliente.Celular);
            cliente.TelefoneFixo = Helpers.DesformatarTelefone(cliente.TelefoneFixo);

            if (id != cliente.CpfCnpj)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Obtém o usuário atualmente logado
                    var userLogin = await _userIdentity.GetUserAsync(User);

                    if (userLogin != null)
                    {
                        // Faça o que precisa com o usuário
                        var userId = userLogin.Id;
                    }

                    Cliente cliente_data_base = await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.CpfCnpj == id);

                    if (cliente_data_base == null)
                    {
                        return NotFound();
                    }

                    if (cliente.UpImage != null && cliente.UpImage.Length > 0)
                    {
                        var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images/cliente-images");
                        var nomeArquivo = cliente.CpfCnpj + Path.GetExtension(cliente.UpImage.FileName);
                        var caminhoArquivo = Path.Combine(uploadsFolder, nomeArquivo);

                        using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                        {
                            await cliente.UpImage.CopyToAsync(stream);
                            cliente.Image = nomeArquivo;
                        }
                    }
                    else
                    {
                        cliente.Image = cliente_data_base.Image;
                    }


                    cliente.TPessoa = cliente_data_base.TPessoa;
                    cliente.UserUpdated = userLogin.Id;
                    cliente.Updated = DateTime.Now;
                    cliente.Created = cliente_data_base.Created;
                    cliente.UserInserted = cliente_data_base.UserInserted;

                    _context.Update(cliente);

                    await _context.SaveChangesAsync();

                    TempData["update"] = "O Parceiro de Negócios foi atualizado com sucesso!";

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.CpfCnpj))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(cliente);
        }

        [ClaimsAuthorize("Cliente", "CR")]
        [HttpGet("excluir/{id:length(11,14)}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.CpfCnpj == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [ClaimsAuthorize("Cliente", "CR")]
        [HttpPost("excluir/{id:length(11,14)}"), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente != null)
            {
                if (!string.IsNullOrEmpty(cliente.Image))
                {
                    ExcluirImagemCliente(cliente.Image);
                }

                _context.Clientes.Remove(cliente);
            }

            await _context.SaveChangesAsync();

            TempData["delete"] = "O Parceiro de Negócios foi excluído com sucesso!";            

            return RedirectToAction(nameof(Index));
        }

        [ClaimsAuthorize("Cliente", "CE")]
        [HttpPost("excluir-foto/{id:length(11,14)}")]
        public async Task<IActionResult> DeleteFoto(string id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            var pictureExists = false;

            if (cliente != null)
            {
                if (!string.IsNullOrEmpty(cliente.Image))
                {
                    pictureExists = true;
                    ExcluirImagemCliente(cliente.Image);
                    cliente.Image = null;
                }

                _context.Clientes.Update(cliente);
            }

            await _context.SaveChangesAsync();

            if(pictureExists)
            {
                TempData["delete"] = "A imagem do Parceiro de Negócios foi excluída com sucesso!";
            }
            else
            {
                TempData["delete"] = "Não existe imagem para ser excluída!";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(string id)
        {
            return _context.Clientes.Any(e => e.CpfCnpj == id);
        }

        private bool IsCpfCnpj(string cpfCnpj)
        {
            return Helpers.IsCpfCnpj(cpfCnpj);
        }

        private void ExcluirImagemCliente(string nomeArquivo)
        {
            var caminhoArquivo = Path.Combine(_hostingEnvironment.WebRootPath, "images/cliente-images", nomeArquivo);

            if (System.IO.File.Exists(caminhoArquivo)) // Corrigido para System.IO.File
            {
                System.IO.File.Delete(caminhoArquivo); // Corrigido para System.IO.File
            }
        }
    }
}
