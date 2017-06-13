using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SamsBookReviewLibary.Data;
using SamsBookReviewLibary.Models;

namespace SamsBookReviewLibary.Controllers
{
    public class BookTitlesController : Controller
    {
        private readonly AuthorContext _context;

        public BookTitlesController(AuthorContext context)
        {
            _context = context;    
        }

        // GET: BookTitles
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookTitles.ToListAsync());
        }

        // GET: BookTitles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTitle = await _context.BookTitles
                .SingleOrDefaultAsync(m => m.BookTitleID == id);
            if (bookTitle == null)
            {
                return NotFound();
            }

            return View(bookTitle);
        }

        // GET: BookTitles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookTitles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookTitleID,Title,ReleaseDate,Language,Sypnosis,ImgThumbNail")] BookTitle bookTitle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookTitle);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bookTitle);
        }

        // GET: BookTitles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTitle = await _context.BookTitles.SingleOrDefaultAsync(m => m.BookTitleID == id);
            if (bookTitle == null)
            {
                return NotFound();
            }
            return View(bookTitle);
        }

        // POST: BookTitles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookTitleID,Title,ReleaseDate,Language,Sypnosis,ImgThumbNail")] BookTitle bookTitle)
        {
            if (id != bookTitle.BookTitleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookTitle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookTitleExists(bookTitle.BookTitleID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(bookTitle);
        }

        // GET: BookTitles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTitle = await _context.BookTitles
                .SingleOrDefaultAsync(m => m.BookTitleID == id);
            if (bookTitle == null)
            {
                return NotFound();
            }

            return View(bookTitle);
        }

        // POST: BookTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookTitle = await _context.BookTitles.SingleOrDefaultAsync(m => m.BookTitleID == id);
            _context.BookTitles.Remove(bookTitle);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BookTitleExists(int id)
        {
            return _context.BookTitles.Any(e => e.BookTitleID == id);
        }
    }
}
