using iChoosr.Application.Abstract;
using iChoosr.Domain.Cameras;
using iChoosr.Infrastructure.Helpers;
using Microsoft.Extensions.Configuration;

namespace iChoosr.Infrastructure.ApplicationContext
{
    internal class CameraRepository : CsvContext<Camera>, ICameraRepository
    {
        public CameraRepository(
            IConfiguration configuration,
            CameraIdService cameraIdService)
            : base(configuration["CameraCsvFilePath"] ?? throw new InvalidOperationException("CameraCsvFilePath configuration is missing."))
        {
            cameraIdService.SetCamerasId(DataSet?.ToList() ?? new List<Camera>());
        }

        public IEnumerable<Camera> GetAll() => DataSet;

        public IEnumerable<Camera> FindByName(string name) => DataSet.Where(c => c.Name.Contains(name));
    }
}