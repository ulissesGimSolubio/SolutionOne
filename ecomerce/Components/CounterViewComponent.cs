using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Components
{
    public class CounterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int modelCount)
        {           
            return View(modelCount);                
        }
    }
}
