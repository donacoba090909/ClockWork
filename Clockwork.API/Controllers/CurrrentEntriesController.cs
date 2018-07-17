using System;
using Microsoft.AspNetCore.Mvc;
using Clockwork.API.Models;
using System.Linq;

namespace Clockwork.API.Controllers
{
    [Route("api/[controller]")]
    public class CurrentEntriesController : Controller
    {
        // GET api/currententries
        [HttpGet]
        public IActionResult Get()
        {
            var result = new ClockworkContext();
            var data = result.CurrentTimeQueries.OrderByDescending(a => a.CurrentTimeQueryId).ToList();

            return Ok(data);
        }

    }
}
