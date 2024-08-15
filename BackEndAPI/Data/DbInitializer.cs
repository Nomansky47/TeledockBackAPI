using TeledockBackAPI.Model;

namespace TeledokBackendAPI.Data
{
    public static class DbInitializer
    {
        public static void CreateDb(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services=scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<Context>();
                    context.Database.EnsureCreated();
                }
                catch (Exception exception)
                {
                   var Logger= services.GetRequiredService<ILogger<Program>>();
                    Logger.LogError(exception, "Db creating error");
                }
            }
        }
    }
}
