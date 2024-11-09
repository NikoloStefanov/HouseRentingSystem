using HouseRentingSystem.Core.Contracts.House;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using HouseRentingSystem.Controllers;

namespace HouseRentingSystem.Models.Atributes
{
    public class MustBeAgent : ActionFilterAttribute
    {


        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            IAgentService? service = context.HttpContext.RequestServices.GetService<IAgentService>();

            if (service == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (service != null
                && service.ExistsByIdAsync(context.HttpContext.User.Id()).Result == false)
            {
                context.Result = new RedirectToActionResult(nameof(AgentController.Become), "Agent", null);
            }



        }
    }
}
