using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Store.Api.Client.Exceptions
{
    /// <summary>
    /// Basic exception for throwing network and other API related exceptions
    /// </summary>
    public class ApiClientException : Exception
    {
        public ApiClientException(string message) : base(message)
        {
        }

        public ApiClientException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
