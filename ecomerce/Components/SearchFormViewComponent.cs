using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecomerce.Components
{
    public class SearchFormViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int itensPorPagina, List<int> paginas, string busca, bool? ativo)
        {
            ViewData["itensPorPagina"] = itensPorPagina;
            ViewData["paginas"] = paginas;
            ViewData["busca"] = busca;            
            ViewData["ativo"] = ativo;

            return View();
        }
    }
}
