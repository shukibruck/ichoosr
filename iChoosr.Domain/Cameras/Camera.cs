using CsvHelper.Configuration.Attributes;

namespace iChoosr.Domain.Cameras;

public sealed class Camera
{
    [Ignore]
    public int Id { get; set; }

    [Name("Camera")]
    public string Name { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }
}