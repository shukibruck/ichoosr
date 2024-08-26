using iChoosr.Domain.Abstract;

namespace iChoosr.Domain.Cameras
{
    public sealed class CameraClassifier
    {
        public Dictionary<Type, List<Camera>> ClassifiedCameras { get; } = new();
        public List<Camera> UndividedCameras { get; } = new();

        private CameraClassifier()
        {
        }

        public static CameraClassifier Create(IEnumerable<Camera>? cameras, IEnumerable<IDivisionStrategy>? divisionStrategies)
        {
            var cameraClassification = new CameraClassifier();

            foreach (var camera in cameras)
            {
                if (camera.Id == 0)
                {
                    cameraClassification.AddUndividedCamera(camera);
                    continue;
                }

                var classified = false;
                foreach (var strategy in divisionStrategies)
                {
                    if (strategy.IsDivisible(camera.Id))
                    {
                        cameraClassification.AddCamera(strategy.GetType(), camera);
                        classified = true;
                    }
                }

                if (!classified)
                {
                    cameraClassification.AddUndividedCamera(camera);
                }
            }

            return cameraClassification;
        }

        private void AddCamera(Type strategyType, Camera camera)
        {
            if (!ClassifiedCameras.ContainsKey(strategyType))
            {
                ClassifiedCameras[strategyType] = new List<Camera>();
            }

            ClassifiedCameras[strategyType].Add(camera);
        }

        private void AddUndividedCamera(Camera camera)
        {
            UndividedCameras.Add(camera);
        }

        public IReadOnlyList<Camera> GetCamerasByStrategy(Type strategyType)
        {
            return ClassifiedCameras.TryGetValue(strategyType, out var cameras)
                ? cameras.AsReadOnly()
                : new List<Camera>().AsReadOnly();
        }
    }
}
