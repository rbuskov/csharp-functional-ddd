using Example.Core;

namespace Example.Domain
{
    public interface ICargoRepository
    {
        IResult Store(Cargo cargo);
    }
}