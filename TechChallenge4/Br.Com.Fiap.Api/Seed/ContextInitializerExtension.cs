using Br.Com.Fiap.Infra.Data;

namespace Br.Com.Fiap.Api.Seed
{
    internal static class ContextInitializerExtension
    {
        public static IApplicationBuilder ContextSeed(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ApiContext>();
                ContextInitializer.Initialize(context);
            }
            catch (Exception)
            {

                throw;
            }

            return app;
        }
    }
}
