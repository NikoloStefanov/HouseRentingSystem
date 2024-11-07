using System.Security.Claims;
using HouseRentingSystem.Core.Contracts.House;
using HouseRentingSystem.Core.Services;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static System.Net.Mime.MediaTypeNames;

namespace HouseRentingSystem.Models.Atributes
{
    public class NotAnAgent : ActionFilterAttribute
    {
       
        
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            IAgentService? service = context.HttpContext.RequestServices.GetService<IAgentService>();

            if (service == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (service!=null 
                && service.ExistsByIdAsync(context.HttpContext.User.Id()).Result) 
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            
           
          
        }
    }
}
