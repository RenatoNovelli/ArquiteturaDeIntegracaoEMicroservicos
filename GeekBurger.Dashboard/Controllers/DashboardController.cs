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
                new ConsolidatedSales { StoredId = Guid.NewGuid(), Total = 1320, Value = 72278 },
                new ConsolidatedSales { StoredId = Guid.NewGuid(), Total = 1120, Value = 65278 },
                new ConsolidatedSales { StoredId = Guid.NewGuid(), Total = 1330, Value = 22548 },
                new ConsolidatedSales { StoredId = Guid.NewGuid(), Total = 1457, Value = 88728 }
            };

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
