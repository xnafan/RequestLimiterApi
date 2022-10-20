using RequestLimiterClassLibrary;
using RequestLimiterClassLibrary.CreditCheckers;

namespace RequestCounterWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddControllers();
            builder.Services.AddSingleton<ICreditChecker, SpecificAmountOfRequestsAllowedCreditChecker>();
            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseMiddleware<RequestLimiterMiddleware>();
            app.UseAuthorization();

            app.MapControllers();
            app.MapControllerRoute(
                "Default",                                              // Route name
                "{controller=Home}/{action=Index}/{id}",                // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

            app.Run();
        }
    }
}