using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JongBrabant.Kantinescherm.Data;
using JongBrabant.Kantinescherm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JongBrabant.Kantinescherm.Controllers
{
    public class PriceListsController : Controller
    {
        private readonly PriceListContext _pricesContext;

        public PriceListsController(PriceListContext pricesContext)
        {
            _pricesContext = pricesContext;
        }

        public async Task<IActionResult> Index(int priceListId, int numberOfColumns = 3)
        {
            var products = await _pricesContext.Products
                .Where(x => x.Group.PriceList.PriceListId == priceListId)
                .OrderBy(x => x.Group.Order)
                .ThenBy(x => x.Order)
                .Include(x => x.Group)
                .ThenInclude(x => x.PriceList)
                .ToListAsync();

            var numberOfProductsPerRow = (int)Math.Floor((products.Count) / (decimal)numberOfColumns);

            var priceList = new PriceListView
            {
                Columns = new List<PriceListColumn>()
            };

            for (int i = 0; i < numberOfColumns; i++)
            {
                priceList.Columns.Add(new PriceListColumn
                {
                    Groups = products.Skip(i * numberOfProductsPerRow).Take(numberOfProductsPerRow)
                        .GroupBy(x => x.Group).ToList(),
                    IsLastColumn = i == numberOfColumns - 1
                });
            }

            return View(priceList);
        }
    }
}
