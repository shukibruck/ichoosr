using iChoosr.Domain.Abstract;

namespace iChoosr.Application.Abstract;

public interface IQuery<T>
{
    public Result<T> Handle();
}