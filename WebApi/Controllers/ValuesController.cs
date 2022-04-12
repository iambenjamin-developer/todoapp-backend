using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Value 1", "Value 2", "Value 3" };
        }

        [HttpGet("/api/datetime")]
        public string GetDatetime()
        {
            return DateTime.Now.ToLongDateString() + " - " + DateTime.Now.ToLongTimeString();
        }


        [HttpGet("/api/settings")]
        public string GetVariables()
        {
            return _configuration["ConnectionStrings:DefaultConnection"];
        }

        [HttpGet("/api/variablesDeEntorno")]
        public List<string> GetVariablesDeEntorno()
        {
            string uno = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            string dos = Environment.GetEnvironmentVariable("MiVariableDeEntorno");
            string tres = Environment.GetEnvironmentVariable("ASPNETCORE_URLS");
            string cuatro = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
            return new List<string> { uno, dos, tres, cuatro };
        }
    }
}
