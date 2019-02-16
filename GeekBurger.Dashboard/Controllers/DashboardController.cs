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

        
        /// <summary>
        /// Retorna as sales agrupadas por loja baseados nos parametros fornecidos      
        /// </summary>
        /// <param name="per">per Time</param>
        /// <param name="value">value which this is going to search</param>
        /// <returns>Somethign</returns>
        [HttpGet("sales")]
        public IActionResult GetSales(string per, int value)
        {            
            return Ok(_sales);
        }

        /// <summary>
        /// usersWithLessOffer: Retorna a lista de usuários que não receberam
        //mais de 2 alternativas de alimento        
        /// </summary>                
        /// <returns>Retorna o que vc pediu</returns>
        [HttpGet("usersWithLessOffer")]
        public IActionResult GetUsersWithLessOffer()
        {
            return Ok(_usersRestrictions);
        }
    }
}
