using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Sample_UsingSerilogInWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {


        [HttpGet]
        public string Get()
        {
            Log.Information("Test...");
            return DateTime.Now.ToString();
        }
    }
}