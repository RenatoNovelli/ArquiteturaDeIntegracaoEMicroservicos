using GeekBurger.Dashboard.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GeekBurger.Dashboard.Controllers
{
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        public readonly Sales _sales;
        public readonly List<UserRestrictions> _usersRestrictions;

        public DashboardController()
        {
            _sales = new Sales { StoredId = 1111, Total = 1000, Value = "59385.00" };
            var userRestriction1 = new UserRestrictions { Restrictions = "soy, dairy, peanut", Users = 2 };
            var userRestriction2 = new UserRestrictions { Restrictions = "soy, dairy", Users = 1 };

            _usersRestrictions = new List<UserRestrictions> { userRestriction1, userRestriction2 };
        }

        //test
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
