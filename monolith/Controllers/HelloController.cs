using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace monolith.Controllers
{

    [Produces("application/json")]
    [Route("")]
    public class HelloController : Controller
    {
        [HttpGet]
        public JsonResult Get()
        {
            var obj = new {Message = "Hello"};
            return Json(obj);
        }
    }
}