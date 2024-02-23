using System.Security.Claims;
using Serilog.Context;

namespace BloodBankWebAPI.Middlewares
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public LoggerMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var loggedUser= context.User.FindFirstValue(ClaimTypes.Name);
            if (loggedUser != null)
            {
                LogContext.PushProperty("AdminName", loggedUser);              
            }
            else
            {
                LogContext.PushProperty("AdminName", "System");
            }
            await _requestDelegate(context);


        }
    }
}
