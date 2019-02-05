using Microsoft.AspNetCore.Mvc;

namespace GeekBurger.Dashboard.Controllers
{
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        [HttpGet("sales")]
        public IActionResult GetSales()
        {
            return Ok();
        }

        [HttpGet("sales")]
        public IActionResult GetSales(string per, int value)
        {
            return Ok();
        }

        [HttpGet("usersWithLessOffer")]
        public IActionResult GetUsersWithLessOffer()
        {
            return Ok();
        }
        
    }
}
