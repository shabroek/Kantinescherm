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
            var products = await _pricesContext.Products.OrderBy(x => x.Group.Order).ThenBy(x => x.Order).Include(x => x.Group).ToListAsync();
            var numberOfProductsPerRow = (int)Math.Floor((products.Count) / 3m);
            var rest = (products.Count) % 3;

            var column1Count = numberOfProductsPerRow + (rest > 0 ? 1 : 0);
            var column2Count = numberOfProductsPerRow + (rest > 1 ? 1 : 0);
            var priceList = new PriceList
            {
                Columns1 = new PriceListColumn { Groups = products.Take(column1Count).GroupBy(x => x.Group).ToList() },
                Columns2 = new PriceListColumn { Groups = products.Skip(column1Count).Take(column2Count).GroupBy(x => x.Group).ToList() },
                Columns3 = new PriceListColumn { Groups = products.Skip(column1Count).Skip(column2Count).GroupBy(x => x.Group).ToList() }

            };

            return View(priceList);
        }
    }
}
