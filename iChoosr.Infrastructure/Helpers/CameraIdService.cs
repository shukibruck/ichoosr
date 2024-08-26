using System.Text.RegularExpressions;
using iChoosr.Application.Helpers;
using iChoosr.Domain.Cameras;

namespace iChoosr.Infrastructure.Helpers;

internal sealed class CameraIdService 
{
    internal IList<Camera> SetCamerasId(IList<Camera> cameras)
    {
        if (cameras == null)
        {
            throw new ArgumentNullException(nameof(cameras));
        }

        var modelRegex = new Regex(@"UTR-CM-\d+");
        var idRegex = new Regex(@"\d+");

        for (var index = 0; index < cameras.Count; index++)
        {
            var camera = cameras[index];
            var model = modelRegex.Match(camera.Name);
            var idStr = idRegex.Match(model.Value);

            if (!int.TryParse(idStr.Value, out var id))
            {
                PrintHelper.PrintError($"Can't get id from camera: {camera.Name}");
                cameras.Remove(camera);
                index -= 1;

                continue;
            }

            camera.Id = id;
        }

        return cameras;
    }
}