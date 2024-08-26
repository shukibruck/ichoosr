using iChoosr.Domain.Cameras;

namespace iChoosr.Application.Helpers
{
    public static class PrintHelper
    {
        private const string LineSeparator = "--------------------------------------";

        public static void PrintError(string errorMessage)
        {
            if (string.IsNullOrEmpty(errorMessage))
            {
                throw new ArgumentNullException(nameof(errorMessage));
            }

            Console.WriteLine(LineSeparator);
            Console.WriteLine($"---- {errorMessage} ----");
            Console.WriteLine(LineSeparator);
        }

        public static void PrintCameras(IEnumerable<Camera> cameraModels)
        {
            if (cameraModels == null)
            {
                throw new ArgumentNullException(nameof(cameraModels));
            }

            foreach (var cameraModel in cameraModels)
            {
                PrintCamera(cameraModel);
            }

            Console.WriteLine(LineSeparator);
        }

        public static void PrintCamera(Camera cameraModel)
        {
            if (cameraModel == null)
            {
                throw new ArgumentNullException(nameof(cameraModel));
            }

            Console.WriteLine($"{cameraModel.Id} | {cameraModel.Name} | {cameraModel.Latitude} | {cameraModel.Longitude}");
        }
    }
}
