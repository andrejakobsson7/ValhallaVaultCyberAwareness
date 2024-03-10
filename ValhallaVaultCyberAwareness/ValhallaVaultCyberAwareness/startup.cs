using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace ValhallaVaultCyberAwareness
{

        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                // Configure services here
            }

            public void Configure(IApplicationBuilder app)
            {
                // Configure middleware pipeline here
                app.UseRouting();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapBlazorHub();
                    endpoints.MapFallbackToPage("/_Host");
                });
            }
        }

}
