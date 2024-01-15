using System;
using System.Linq;
using System.Threading.Tasks;
using JongBrabant.Kantinescherm.Data;
using JongBrabant.Kantinescherm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JongBrabant.Kantinescherm.Controllers
{
    public class OverviewController : Controller
    {
        private readonly PriceListContext _pricesContext;

        public OverviewController(PriceListContext pricesContext)
        {
            _pricesContext = pricesContext;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _pricesContext.PriceLists.ToListAsync();
            return View(result);
        }
        
    }
}
