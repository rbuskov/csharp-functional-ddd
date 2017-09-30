using Example.Core;

namespace Example.Domain
{
    public interface ILocationRepository
    {
        IResult Find(UnLocode unLocode);

        IResult Find(string unLocode);
        /*
            {
                switch (UnLocode.Create(unLocode))
                {
                    case Failure failure:
                        return failure;
                    case Success<UnLocode> success:
                        return Find(success.Result);
                    case var result:
                        throw new InvalidResultException(result);
                }
            }            
        */
    }
}