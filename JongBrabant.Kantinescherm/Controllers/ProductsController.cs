﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JongBrabant.Kantinescherm.Data;
using JongBrabant.Kantinescherm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace JongBrabant.Kantinescherm.Controllers
{
    public class ProductsController : Controller
    {
        private readonly PriceListContext _context;
        private readonly IMemoryCache _cache;

        public ProductsController(PriceListContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        // GET: Prices
        public async Task<IActionResult> Index()
        {
            var products = new List<ProductEntry>();

            // This allows the home page to load if migrations have not been run yet.
            try
            {
                products = await _context.Products.OrderBy(x => x.Group.Order).ThenBy(x => x.Order).Include(x => x.Group).ToListAsync();
            }
            catch (Exception)
            {
                return View(products);
            }

            return View(products);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            var selectedGroup = _cache.Get<int>("Group");
            ViewData["Groups"] = await _context.Groups.OrderBy(x => x.Order).Select(x => new SelectListItem(x.GroupName, x.GroupId.ToString(), selectedGroup == x.GroupId)).ToListAsync();

            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,Group,GroupId,Order")] ProductEntry entry)
        {
            if (ModelState.IsValid)
            {
                if (entry.Order == 0)
                {
                    entry.Order = _context.Products.Where(x => x.GroupId == entry.GroupId).OrderByDescending(x => x.Order).Select(x => x.Order)
                        .FirstOrDefault() + 10;
                }

                _cache.Set("Group", entry.GroupId);

                _context.Add(entry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(entry);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["Groups"] = await _context.Groups.OrderBy(x => x.Order).Select(x => new SelectListItem(x.GroupName, x.GroupId.ToString())).ToListAsync();

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Price,ProductId,GroupId,Order")] ProductEntry productEntry)
        {
            if (id != productEntry.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriceExists(productEntry.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productEntry);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PriceExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        // POST: P
        public async Task<IActionResult> Order()
        {
            int groupOrder = 0;
            foreach (var group in _context.Groups.OrderBy(x => x.Order).Include(x => x.Products))
            {
                group.Order = groupOrder += 10;
                int productOrder = 0;
                foreach (var product in group.Products.OrderBy(x => x.Order))
                {
                    product.Order = productOrder += 10;
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
