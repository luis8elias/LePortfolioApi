using LePortfolioApi.Seeders;

namespace LePortfolioApi.Extensions
{
    public static class DbInitializerExtension
    {
        public static IApplicationBuilder DbInitialize(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var dbInitializer = services.GetRequiredService<IDatabaseSeeder>();
                dbInitializer.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[AppException]:" + ex.Message);
                throw;
            }

            return app;
        }
    }
}
