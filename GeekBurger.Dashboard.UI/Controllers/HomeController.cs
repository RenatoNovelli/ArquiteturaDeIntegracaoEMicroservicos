using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeekBurger.Dashboard.UI.Models;

namespace GeekBurger.Dashboard.UI.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// Mostra os gráficos la        
        /// </summary>                
        /// <returns>Retorna os gráficos</returns>   
        public IActionResult Index()
        {
            return View();
        }     
    }
}
