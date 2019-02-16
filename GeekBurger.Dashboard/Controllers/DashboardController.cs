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
        public readonly List<ConsolidatedSales> _sales;
        public readonly List<UserRestrictions> _usersRestrictions;

        public DashboardController(ISalesService salesService)
        {
            _salesService = salesService;

            _sales = new List<ConsolidatedSales> {
                new ConsolidatedSales { StoredId = Guid.NewGuid(), Total = 1000, Value = 59385 },
                new ConsolidatedSales { StoredId = Guid.NewGuid(), Total = 1320, Value = 72278 }
            };

            _usersRestrictions = new List<UserRestrictions> {
                new UserRestrictions { Restrictions = "soy, dairy, peanut", UserId = Guid.NewGuid() },
                new UserRestrictions { Restrictions = "soy, dairy", UserId = Guid.NewGuid() }
            };
        }

        //test
        [HttpGet("sales")]
        public IActionResult GetSales([FromQuery] Interval? per, [FromQuery] int? value)
        {
            var sales = _salesService.GetSales(per, value);
            return Ok(_sales);
        }

        [HttpGet("usersWithLessOffer")]
        public IActionResult GetUsersWithLessOffer()
        {
            return Ok(_usersRestrictions);
        }
    }
}
