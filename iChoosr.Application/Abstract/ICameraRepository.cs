using iChoosr.Domain;
using iChoosr.Domain.Cameras;

namespace iChoosr.Application.Abstract;

public interface ICameraRepository
{
    IEnumerable<Camera> GetAll();
    IEnumerable<Camera> FindByName(string name);
}