using iChoosr.Application.Abstract;
using iChoosr.Infrastructure.ApplicationContext;
using iChoosr.Infrastructure.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace iChoosr.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICameraRepository, CameraRepository>();
            serviceCollection.AddSingleton<CameraIdService>();

            return serviceCollection;
        }
    }
}
