using Company.Data.Data;
using Company.Data.Models.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Intranet.Controllers
{
    public class PageController : Controller
    {
        private readonly CompanyContext _context;

        public PageController(CompanyContext context)
        {
            _context = context;
        }

        // GET: PAGES
        public async Task<IActionResult> Index()    
        {
            return View(await _context.Page.ToListAsync());
        }

        // GET: PAGES/Details/5
        public async Task<IActionResult> Details(int? idpage)
        {
            if (idpage == null)
            {
                return NotFound();
            }

            var page = await _context.Page
                .FirstOrDefaultAsync(m => m.IdPage == idpage);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // GET: PAGES/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PAGES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LinkTitle,Title,Content,DisplayOrder")] Page page)
        {
            if (ModelState.IsValid)
            {
                _context.Add(page);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(page);
        }

        // GET: PAGES/Edit/5
        public async Task<IActionResult> Edit(int? idpage)
        {
            if (idpage == null)
            {
                return NotFound();
            }

            var page = await _context.Page.FindAsync(idpage);
            if (page == null)
            {
                return NotFound();
            }
            return View(page);
        }

        // POST: PAGES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? idpage, [Bind("IdPage,LinkTitle,Title,Content,DisplayOrder")] Page page)
        {
            if (idpage != page.IdPage)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(page);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageExists(page.IdPage))
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
            return View(page);
        }

        // GET: PAGES/Delete/5
        public async Task<IActionResult> Delete(int? idpage)
        {
            if (idpage == null)
            {
                return NotFound();
            }

            var page = await _context.Page
                .FirstOrDefaultAsync(m => m.IdPage == idpage);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // POST: PAGES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? idpage)
        {
            var page = await _context.Page.FindAsync(idpage);
            if (page != null)
            {
                _context.Page.Remove(page);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PageExists(int? idpage)
        {
            return _context.Page.Any(e => e.IdPage == idpage);
        }
    }
}