using GeekBurger.Dashboard.Contract;
using GeekBurger.Dashboard.Interfaces.Service;
using GeekBurger.Dashboard.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GeekBurger.Dashboard.Controllers
{
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        public readonly ISalesService _salesService;
        public readonly List<UserRestrictions> _usersRestrictions;

        public DashboardController(ISalesService salesService)
        {
            _salesService = salesService;

            _usersRestrictions = new List<UserRestrictions> {
                new UserRestrictions { Restrictions = "soy, dairy, peanut", Users = 2 },
                new UserRestrictions { Restrictions = "soy, dairy", Users = 4 }
            };
        }

        [HttpGet("sales")]
        public IActionResult GetSales([FromQuery] Interval? per, [FromQuery] int? value)
        {
            var sales = _salesService.GetSales(per, value);
            return Ok(sales);
        }

        [HttpGet("usersWithLessOffer")]
        public IActionResult GetUsersWithLessOffer()
        {
            return Ok(_usersRestrictions);
        }
    }
}
