using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApiRoutesResponses.Services;

namespace WebApiRoutesResponses.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserDataService userDataService;

        public UserController(IUserDataService userData)
        {
            userDataService = userData;
        }
       
        public ActionResult<IEnumerable<string>> Get([FromServices] IUserDataService dataService)
        {
            return userDataService.GetValues().Union(dataService.GetValues()).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
           if(id > 0)
           {
               return "Value";
           }
           else if(id < 0)
           {
               return BadRequest();
           }
           else
           {
               return NotFound();
           }
        }

        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}