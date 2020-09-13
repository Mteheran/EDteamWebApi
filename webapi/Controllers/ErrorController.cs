using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiRoutesResponses.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Ha ocurrido un error";
        }
    }
}