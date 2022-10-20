using Microsoft.AspNetCore.Http;
using RequestLimiterClassLibrary.CreditCheckers;
using System.Net.Http;

namespace RequestLimiterClassLibrary
{
    public class RequestLimiterMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ICreditChecker _creditChecker;
        private const string USER_HEADER_NAME = "Client-Authentication-Key";


        public RequestLimiterMiddleware(RequestDelegate next, ICreditChecker creditChecker)
        {
            _next = next;
            _creditChecker = creditChecker;
        }

        public async Task Invoke(HttpContext context)
        {
            // First, check if the header is provided
            if (!context.Request.Headers.TryGetValue(USER_HEADER_NAME, out var providedUserKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Client authentication missing from http header ('Client-Authentication-Key')");
                return;
            }
            if (!_creditChecker.ChargeOneCredit(providedUserKey))
            {
                context.Response.StatusCode = StatusCodes.Status402PaymentRequired;
                await context.Response.WriteAsync("You're out of credits (using RequestLimiterMiddleWare)");
                return;
            }

            await _next(context);
        }
    }
}