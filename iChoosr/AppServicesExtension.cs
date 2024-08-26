using System.Diagnostics;
using iChoosr.Application.Abstract;
using iChoosr.Application.Helpers;
using iChoosr.Domain.Cameras;

namespace iChoosr.Api
{
    public static class AppServicesExtension
    {
        public static void UseCLICameraSearchService(
            this IApplicationBuilder applicationBuilder,
            IConfiguration configuration,
            IServiceProvider serviceProvider)
        {

            var cameraName = configuration.GetValue<string>("name");

            if (HandleSearchParameters(cameraName))
            {
                return;
            }

            var result = SearchCameras(serviceProvider, cameraName);

            if (!result.Any())
            {
                PrintHelper.PrintError($"Can not find cameras with name: '{cameraName}'");
            }

            PrintHelper.PrintCameras(result);
            Process.GetCurrentProcess().Kill();
        }

        private static List<Camera> SearchCameras(IServiceProvider serviceProvider, string cameraName)
        {
            using var scope = serviceProvider.CreateScope();
            var cameraRepository = scope.ServiceProvider.GetRequiredService<ICameraRepository>();
            var result = cameraRepository.FindByName(cameraName).ToList();

            return result;
        }

        private static bool HandleSearchParameters(string cameraName)
        {
            switch (cameraName)
            {
                case null:
                    PrintHelper.PrintError("No search parameters");
                    return true;
                case "":
                    PrintHelper.PrintError("Parameter 'Name' can not be empty");
                    Process.GetCurrentProcess().Kill();
                    break;
            }

            return false;
        }
    }
}