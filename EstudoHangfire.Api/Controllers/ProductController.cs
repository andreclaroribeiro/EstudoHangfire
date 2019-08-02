using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using EstudoHangfire.Api.Models;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstudoHangfire.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        [HttpPost("Insert")]
        public void Post([FromBody] ProductDto product)
        {
            var client = new HttpClient();

            var job = BackgroundJob.Enqueue(() =>
                        client.GetAsync($"http://localhost:5002/api/values")
            );
        }

        public void TestMethod(int id)
        {
            if (id == 2)
            {
                throw new NotImplementedException();
            }

            return;
        }
    }
}