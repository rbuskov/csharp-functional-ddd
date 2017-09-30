using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using Example.Core;

namespace Example.Api.Controllers
{
    public abstract class BaseController : ApiController    
    {
        protected FailureActionResult Failure(IFailure failure) => new FailureActionResult(failure);            
    }
    
    public class FailureActionResult : IHttpActionResult
    {
        private readonly IFailure failure;

        public FailureActionResult(IFailure failure)
        {
            this.failure = failure;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(Json.Encode(failure.ErrorMessages))
            };

            return Task.FromResult(response);
        }
    }
}