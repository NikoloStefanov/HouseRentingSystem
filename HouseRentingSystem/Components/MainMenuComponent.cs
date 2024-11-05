using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Components
{
    public class MainMenuComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokesAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View()); 
        }
    }
}
