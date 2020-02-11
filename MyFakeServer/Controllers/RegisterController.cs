using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyFakeServer.Controllers
{
    [ApiController]
    [Route("register")]
    public class RegisterController
    {
        public static IDictionary<string, IDictionary<string, IDictionary<string, string>>> data = new Dictionary<string, IDictionary<string, IDictionary<string, string>>>(StringComparer.OrdinalIgnoreCase);

        [HttpPost]
        [Route("{serverID}/{*url}")]
        public async Task<ContentResult> Post(string serverID, string url, [FromBody] dynamic input, [FromQuery] string method)
        {
            bool isValid = Guid.TryParse(serverID, out Guid guidOutput);
            if (!isValid)
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = "server id should be guid"
                };
            }

            if(string.IsNullOrEmpty(method))
            {
                method = "GET";
            }

            if(!(method.Equals("GET", StringComparison.OrdinalIgnoreCase) || method.Equals("PUT", StringComparison.OrdinalIgnoreCase) || method.Equals("PATCH", StringComparison.OrdinalIgnoreCase)) || method.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = "supported method is only get, put, post, patch"
                };
            }

            if(!data.ContainsKey(serverID))
            {
                data[serverID] = new Dictionary<string, IDictionary<string, string>>(StringComparer.OrdinalIgnoreCase);
            }

            if(!data[serverID].ContainsKey(url))
            {
                data[serverID][url] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            }

            data[serverID][url][method] = Convert.ToString(input);
            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = data[serverID][url][method]
            };
        }
    }
}
