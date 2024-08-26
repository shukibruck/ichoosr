using iChoosr.Domain.Abstract;

namespace iChoosr.Domain.Cameras
{
    public class CameraErrors
    {
        private const string BaseCode = nameof(Camera);
        public static Error NoCameras = new(BaseCode, "There is no cameras");
        public static Error NoPolicies = new(BaseCode, $"There is no policies. Couldn't create {nameof(CameraClassifier)}");
    }
}
