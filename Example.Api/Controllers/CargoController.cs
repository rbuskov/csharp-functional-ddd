using System.Web.Http;
using Example.Application;
using Example.Core;
using Example.Domain;

namespace Example.Api.Controllers
{
    [Route("api/cargo")]
    public class CargoController : BaseController
    {
        private readonly BookCargoCommand.Handler bookCargoCommandHandler;

        public CargoController()
        {
            bookCargoCommandHandler = new BookCargoCommand.Handler(default(ILocationRepository), default(ICargoRepository));
        }

        [HttpPost, Route("book")]
        public IHttpActionResult Book(BookCargoCommand command)
        {
            switch (bookCargoCommandHandler.Execute(command)) 
            {
                case Success<string> success :
                    return Ok(success.Result);
                case Failure failure :
                    return Failure(failure);
                case var result :
                    throw new InvalidResultException(result);
            }
        }
    }
}