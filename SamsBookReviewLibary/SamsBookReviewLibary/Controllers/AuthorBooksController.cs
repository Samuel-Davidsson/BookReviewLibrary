using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SamsBookReviewLibary.Data;
using SamsBookReviewLibary.Models;
using SamsBookReviewLibary.Repositories;

namespace SamsBookReviewLibary.Controllers
{
    public class AuthorBooksController : Controller
    {
        private readonly AuthorContext _context;

        public AuthorBooksController(AuthorContext context)
        {
            _context = context;    
        }

        public async Task<IActionResult> Index()
        {
            var authorContext = _context.AuthorBooks.Include(a => a.Author).Include(a => a.BookTitle);
            return View(await authorContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorBooks = await _context.AuthorBooks
                .Include(a => a.Author)
                .Include(a => a.BookTitle)
                .SingleOrDefaultAsync(m => m.AuthorBooksID == id);
            if (authorBooks == null)
            {
                return NotFound();
            }

            return View(authorBooks);
        }

        public IActionResult Create()
        {
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "AuthorID");
            ViewData["BookTitleID"] = new SelectList(_context.BookTitles, "BookTitleID", "BookTitleID");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorBooksID,AuthorID,BookTitleID")] AuthorBooks authorBooks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authorBooks);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "AuthorID", authorBooks.AuthorID);
            ViewData["BookTitleID"] = new SelectList(_context.BookTitles, "BookTitleID", "BookTitleID", authorBooks.BookTitleID);
            return View(authorBooks);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorBooks = await _context.AuthorBooks.SingleOrDefaultAsync(m => m.AuthorBooksID == id);
            if (authorBooks == null)
            {
                return NotFound();
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "AuthorID", authorBooks.AuthorID);
            ViewData["BookTitleID"] = new SelectList(_context.BookTitles, "BookTitleID", "BookTitleID", authorBooks.BookTitleID);
            return View(authorBooks);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorBooksID,AuthorID,BookTitleID")] AuthorBooks authorBooks)
        {
            if (id != authorBooks.AuthorBooksID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authorBooks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorBooksExists(authorBooks.AuthorBooksID))
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
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "AuthorID", authorBooks.AuthorID);
            ViewData["BookTitleID"] = new SelectList(_context.BookTitles, "BookTitleID", "BookTitleID", authorBooks.BookTitleID);
            return View(authorBooks);
        }

        // GET: AuthorBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorBooks = await _context.AuthorBooks
                .Include(a => a.Author)
                .Include(a => a.BookTitle)
                .SingleOrDefaultAsync(m => m.AuthorBooksID == id);
            if (authorBooks == null)
            {
                return NotFound();
            }

            return View(authorBooks);
        }

        // POST: AuthorBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authorBooks = await _context.AuthorBooks.SingleOrDefaultAsync(m => m.AuthorBooksID == id);
            _context.AuthorBooks.Remove(authorBooks);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AuthorBooksExists(int id)
        {
            return _context.AuthorBooks.Any(e => e.AuthorBooksID == id);
        }
    }
}
