using Company.Intranet.Data;
using Company.Intranet.Models.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Intranet.Controllers
{
    public class NewsController(CompanyIntranetContext context) : Controller
    {
        // GET: NEWS
        public async Task<IActionResult> Index()    
        {
            return View(await context.News.ToListAsync());
        }

        // GET: NEWS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await context.News
                .FirstOrDefaultAsync(m => m.IdNews == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: NEWS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NEWS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LinkTitle,Title,Content,DisplayOrder")] News news)
        {
            if (ModelState.IsValid)
            {
                context.Add(news);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: NEWS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        // POST: NEWS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? idnews, [Bind("id,LinkTitle,Title,Content,DisplayOrder")] News news)
        {
            if (idnews != news.IdNews)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(news);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.IdNews))
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
            return View(news);
        }

        // GET: NEWS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await context.News
                .FirstOrDefaultAsync(m => m.IdNews == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: NEWS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var news = await context.News.FindAsync(id);
            if (news != null)
            {
                context.News.Remove(news);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int? id)
        {
            return context.News.Any(e => e.IdNews == id);
        }
    }
}