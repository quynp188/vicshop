namespace VicShop.Api.Common;

public static class PrepareDatabase
{
    public static void InitDatabase(IApplicationBuilder application)
    {
        using (var scope = application.ApplicationServices.CreateScope())
        {
            try
            {
                var dataInit = scope.ServiceProvider.GetService<DataInitializer>();
                dataInit!.Seed().Wait();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
