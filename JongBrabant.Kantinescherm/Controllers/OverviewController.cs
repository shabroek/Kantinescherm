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
            var prices = await _pricesContext.Products.Include(x => x.Group).ToListAsync();
            var numberOfPrices = (int)Math.Floor(prices.Count / 3m);
            var rest = prices.Count % 3;

            var column1count = numberOfPrices + (rest > 0 ? 1 : 0);
            var column2count = numberOfPrices + (rest > 1 ? 1 : 0);
            var priceList = new PriceList
            {
                Columns1 = new PriceListColumn { Groups = prices.Take(column1count).GroupBy(x => x.Group).ToList() },
                Columns2 = new PriceListColumn { Groups = prices.Skip(column1count).Take(column2count).GroupBy(x => x.Group).ToList() },
                Columns3 = new PriceListColumn { Groups = prices.Skip(column1count).Skip(column2count).GroupBy(x => x.Group).ToList() }

            };

            return View(priceList);
        }
    }
}
