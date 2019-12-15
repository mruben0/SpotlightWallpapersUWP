using RestSharp;
using System.Threading.Tasks;

namespace Core.Base
{
    public abstract class BaseHttpService
    {
        protected async Task<IRestResponse> ExecuteAsync(RestClient client, RestRequest request)
        {
            try
            {
                IRestResponse response = await client.ExecuteTaskAsync(request);
                return response;
            }
            catch (System.Exception)
            {
                return new RestResponse() { StatusCode = System.Net.HttpStatusCode.ServiceUnavailable };
            }        
        }
    }
}