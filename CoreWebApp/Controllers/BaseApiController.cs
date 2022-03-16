using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CoreWebApp.Controllers
{
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// Gets the API error.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>API error message</returns>
        public async Task<string> GetAPIError(HttpResponseMessage response)
        {
            var responseHttpError = await response.Content.ReadAsAsync<HttpError>();
            return responseHttpError.Message;
        }
    }
}
