using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyFakeServer.Controllers
{
    [ApiController]
    [Route("server")]
    public class MyFakeServerController
    {
        [HttpGet]
        [Route("{serverID}/{*url}")]
        public async Task<ContentResult> Get(string serverID, string url)
        {
            bool isValid = Guid.TryParse(serverID, out Guid guidOutput);
            if(!isValid)
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                };
            }

            if(!RegisterController.data.ContainsKey(serverID))
            {
                return new ContentResult()
                {
                    StatusCode = 404,
                    Content = "server id not registered.",
                };
            }

            if (!RegisterController.data[serverID].ContainsKey(url))
            {
                return new ContentResult()
                {
                    StatusCode = 404,
                    Content = "url not registered.",
                };
            }

            if (!RegisterController.data[serverID][url].ContainsKey("GET"))
            {
                return new ContentResult()
                {
                    StatusCode = 404,
                    Content = "METHOD not registered.",
                };
            }


            return new ContentResult()
            {
                StatusCode = 200,
                Content = RegisterController.data[serverID][url]["GET"],
                ContentType = "application/json"
            };
        }

        [HttpPost]
        [Route("{serverID}/{*url}")]
        public async Task<ContentResult> Post(string serverID, string url)
        {
            bool isValid = Guid.TryParse(serverID, out Guid guidOutput);
            if (!isValid)
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                };
            }

            if (!RegisterController.data.ContainsKey(serverID))
            {
                return new ContentResult()
                {
                    StatusCode = 404,
                    Content = "server id not registered.",
                };
            }

            if (!RegisterController.data[serverID].ContainsKey(url))
            {
                return new ContentResult()
                {
                    StatusCode = 404,
                    Content = "url not registered.",
                };
            }

            if (!RegisterController.data[serverID][url].ContainsKey("Post"))
            {
                return new ContentResult()
                {
                    StatusCode = 404,
                    Content = "METHOD not registered.",
                };
            }


            return new ContentResult()
            {
                StatusCode = 200,
                Content = RegisterController.data[serverID][url]["Post"],
                ContentType = "application/json"
            };
        }

        [HttpPatch]
        [Route("{serverID}/{*url}")]
        public async Task<ContentResult> Patch(string serverID, string url)
        {
            bool isValid = Guid.TryParse(serverID, out Guid guidOutput);
            if (!isValid)
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                };
            }

            if (!RegisterController.data.ContainsKey(serverID))
            {
                return new ContentResult()
                {
                    StatusCode = 404,
                    Content = "server id not registered.",
                };
            }

            if (!RegisterController.data[serverID].ContainsKey(url))
            {
                return new ContentResult()
                {
                    StatusCode = 404,
                    Content = "url not registered.",
                };
            }

            if (!RegisterController.data[serverID][url].ContainsKey("Patch"))
            {
                return new ContentResult()
                {
                    StatusCode = 404,
                    Content = "METHOD not registered.",
                };
            }


            return new ContentResult()
            {
                StatusCode = 200,
                Content = RegisterController.data[serverID][url]["Patch"],
                ContentType = "application/json"
            };
        }

        [HttpPut]
        [Route("{serverID}/{*url}")]
        public async Task<ContentResult> Put(string serverID, string url)
        {
            bool isValid = Guid.TryParse(serverID, out Guid guidOutput);
            if (!isValid)
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                };
            }

            if (!RegisterController.data.ContainsKey(serverID))
            {
                return new ContentResult()
                {
                    StatusCode = 404,
                    Content = "server id not registered.",
                };
            }

            if (!RegisterController.data[serverID].ContainsKey(url))
            {
                return new ContentResult()
                {
                    StatusCode = 404,
                    Content = "url not registered.",
                };
            }

            if (!RegisterController.data[serverID][url].ContainsKey("Put"))
            {
                return new ContentResult()
                {
                    StatusCode = 404,
                    Content = "METHOD not registered.",
                };
            }


            return new ContentResult()
            {
                StatusCode = 200,
                Content = RegisterController.data[serverID][url]["Put"],
                ContentType = "application/json"
            };
        }
    }
}
