using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication.EndPoints.Admin.Infrastructures
{
    public class PermissionCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(context.HttpContext.User.Identity.IsAuthenticated)
            {
                //var roleService = 
                //    (IRoleService)context.HttpContext.RequestServices.GetService(typeof(IRoleService));
            }
            else
            {
                context.Result = new RedirectResult("/Login");
            }
        }
    }
}
