using iChoosr.Domain.Cameras;

namespace iChoosr.Application.CameraHandler;

public record GetCameraClassifierQueryResult
{
    public IReadOnlyList<Camera> DividedByThree { get; set; }
    public IReadOnlyList<Camera> DividedByFive { get; set; }
    public IReadOnlyList<Camera> DividedByThreeAndFive { get; set; }
    public IReadOnlyList<Camera> Undivided { get; set; }
}