using iChoosr.Application.Abstract;
using iChoosr.Application.CameraHandler;
using Microsoft.Extensions.DependencyInjection;

namespace iChoosr.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IQuery<GetCameraClassifierQueryResult>, GetCameraClassifierQueryHandler>();

            return serviceCollection;
        }
    }
}