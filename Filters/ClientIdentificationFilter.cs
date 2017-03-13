using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using GoMapsCloudAPI.Consts;

namespace GoMapsCloudAPI.Filters
{
    public class ClientIdentificationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string client_secret = context.HttpContext.Request.Headers["Authorization"];
            if (client_secret != Secrets.CLIENT_SECRET)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}