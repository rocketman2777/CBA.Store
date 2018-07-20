using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using CBA.Store.Api.Client.Exceptions;

namespace CBA.Store.Api.Client
{
    /// <summary>
    /// Base class with basic API client excpetion handling which standardises API calls.
    /// Could potentially handle security authentication if required.
    /// </summary>
    public class ClientBase
    {
        protected IRestClient _restClient;

        public ClientBase(IRestClient restClient)
        {
            _restClient = restClient;
        }

        protected T Execute<T>(string resource, Method method) where T : new()
        {
            var request = new RestRequest(resource, method);
            var response = _restClient.Execute<T>(request);

            // some pretty basic exception handling for now, prefer to throw an error
            // than use return codes because we exception handling anyway for unexpected 
            // errors so easier to handle unexpected API errors in the same way.
            if (response.IsSuccessful)
            {
                return response.Data;
            }
            if (response.ErrorException != null)
            {
                throw new ApiClientException(response.ErrorMessage, response.ErrorException);
            }
            throw new ApiClientException(response.ErrorMessage);
        }
    }
}
