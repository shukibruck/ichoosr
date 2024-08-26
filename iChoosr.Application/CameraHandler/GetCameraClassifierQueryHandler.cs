using iChoosr.Application.Abstract;
using iChoosr.Domain.Abstract;
using iChoosr.Domain.Cameras;
using iChoosr.Domain.Policies;

namespace iChoosr.Application.CameraHandler
{
    public class GetCameraClassifierQueryHandler : IQuery<GetCameraClassifierQueryResult>
    {
        private readonly IEnumerable<IDivisionStrategy> _divisionStrategies;
        private readonly ICameraRepository _cameraRepository;

        public GetCameraClassifierQueryHandler(
            IEnumerable<IDivisionStrategy> divisionStrategies,
            ICameraRepository cameraRepository)
        {
            _divisionStrategies = divisionStrategies;
            _cameraRepository = cameraRepository;
        }

        public Result<GetCameraClassifierQueryResult> Handle()
        {
            var cameras = _cameraRepository.GetAll();

            if (cameras is null || !cameras.Any())
            {
                return Result.Failure<GetCameraClassifierQueryResult>(CameraErrors.NoCameras);
            }

            var cameraClassifier = CameraClassifier.Create(cameras, _divisionStrategies);

            var result = new GetCameraClassifierQueryResult()
            {
                DividedByThree = cameraClassifier.GetCamerasByStrategy(typeof(DivisibleByThree)),
                DividedByFive = cameraClassifier.GetCamerasByStrategy(typeof(DivisibleByFive)),
                DividedByThreeAndFive = cameraClassifier.GetCamerasByStrategy(typeof(DivisibleByThreeAndFive)),
                Undivided = cameraClassifier.UndividedCameras
            };

            return Result.Success(result);
        }
    }
}
