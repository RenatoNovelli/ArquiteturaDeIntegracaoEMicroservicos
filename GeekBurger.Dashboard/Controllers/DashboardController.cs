using GeekBurger.Dashboard.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GeekBurger.Dashboard.Controllers
{
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        public readonly Sales _sales;
        
        //test
        [HttpGet("sales")]
        public IActionResult GetSales()
        {
            var a = 1;
            return Ok(_sales);
        }

        [HttpGet("sales")]
        public IActionResult GetSales(string per, int value)
        {
            return Ok(_sales);
        }

        [HttpGet("usersWithLessOffer")]
        public IActionResult GetUsersWithLessOffer()
        {
            return Ok(_usersRestrictions);
        }
    }
}
