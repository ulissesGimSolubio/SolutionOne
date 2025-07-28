using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ecomerce.Components
{
    public class PaginationViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int pagina, int totalPaginas, int itensPorPagina)
        {
            ViewData["pagina"] = pagina;
            ViewData["totalPaginas"] = totalPaginas;
            ViewData["itensPorPagina"] = itensPorPagina;

            return View();
        }
    }
}
