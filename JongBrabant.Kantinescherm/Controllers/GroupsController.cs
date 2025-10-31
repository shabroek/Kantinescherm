using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JongBrabant.Kantinescherm.Data;
using JongBrabant.Kantinescherm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JongBrabant.Kantinescherm.Controllers
{
    public class GroupsController : Controller
    {
        private readonly PriceListContext _context;
        private const string EditPassword = "OrjanGame";
        private const string SessionKey = "IsEditor";

        public GroupsController(PriceListContext context)
        {
            _context = context;
            ViewData["IsManagement"] = true;
        }

        private bool IsEditor()
        {
            return HttpContext.Session.GetString(SessionKey) == "true";
        }

        private IActionResult PasswordPrompt(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View("PasswordPrompt");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PasswordPrompt(string password, string returnUrl)
        {
            if (password == EditPassword)
            {
                HttpContext.Session.SetString(SessionKey, "true");
                return Redirect(returnUrl);
            }
            ViewData["ReturnUrl"] = returnUrl;
            ViewData["Error"] = "Wachtwoord onjuist.";
            return View();
        }

        // GET: Groups
        public async Task<IActionResult> Index()
        {
            var groups = new List<GroupEntry>();
            try
            {
                groups = await _context.Groups.OrderBy(x => x.Order).Include(x => x.PriceList).ToListAsync();
            }
            catch (Exception)
            {
                return View(groups);
            }
            return View(groups);
        }

        // GET: Groups/Create
        public IActionResult Create()
        {
            if (!IsEditor())
                return PasswordPrompt(Url.Action("Create", "Groups"));
            return View();
        }

        // POST: Groups/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupName,Order,ShowHeader")] GroupEntry group)
        {
            if (!IsEditor())
                return PasswordPrompt(Url.Action("Create", "Groups"));

            if (ModelState.IsValid)
            {
                if (group.Order == 0)
                {
                    group.Order = _context.Groups.Max(x => x.Order) + 10;
                }

                _context.Add(group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(group);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!IsEditor())
                return PasswordPrompt(Url.Action("Edit", "Groups", new { id }));

            if (id == null)
            {
                return NotFound();
            }

            ViewData["PriceLists"] = await _context.PriceLists.OrderBy(x => x.PriceListId)
                .Select(x => new SelectListItem(x.Name, x.PriceListId.ToString()))
                .ToListAsync();

            var group = await _context.Groups.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }
            return View(group);
        }

        // POST: Groups/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupName,Group,PriceListId,GroupId,Order,ShowHeader")] GroupEntry group)
        {
            if (!IsEditor())
                return PasswordPrompt(Url.Action("Edit", "Groups", new { id }));

            if (id != group.GroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(group);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(group.GroupId))
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
            return View(group);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!IsEditor())
                return PasswordPrompt(Url.Action("Delete", "Groups", new { id }));

            if (id == null)
            {
                return NotFound();
            }

            var group = await _context.Groups
                .FirstOrDefaultAsync(m => m.GroupId == id);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!IsEditor())
                return PasswordPrompt(Url.Action("Delete", "Groups", new { id }));

            var group = await _context.Groups.FindAsync(id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.GroupId == id);
        }
    }
}