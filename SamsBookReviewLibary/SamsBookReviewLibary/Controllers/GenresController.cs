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
    public class GenresController : Controller
    {
        private readonly AuthorContext _context;

        public GenresController(AuthorContext context)
        {
            _context = context;    
        }

        public IActionResult Index()
        {
            return View(_context.Genres.ToList());
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var genre = _context.Genres
                .SingleOrDefault(m => m.GenreID == id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        public IActionResult Create()
        {
            var genreTypes = GetGenreTypes();
            
            ViewData["GenreTypes"] = new SelectList(genreTypes, "Id", "Value");
            
            return View();
        }

        private dynamic GetGenreTypes()
        {
            return Enum.GetValues(typeof(GenreType)).Cast<GenreType>().ToList()
                .Select(x => new { Id = x.ToString(), Value = x.ToString() });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenreID,GenreTypes,Description")] Genre genre)
        {

            if (ModelState.IsValid)
            {
                _context.Add(genre);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewData["GenreTypes"] = new SelectList(GetGenreTypes(), "Id", "Value");
            return View(genre);

        }

        public async Task<IActionResult> Edit(int? id)
        {
            var genreTypes = GetGenreTypes();
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _context.Genres.SingleOrDefaultAsync(m => m.GenreID == id);
            if (genre == null)
            {
                return NotFound();
            }
            ViewData["GenreTypes"] = new SelectList(GetGenreTypes(), "Id", "Value");
            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GenreID,GenreTypes,Description")] Genre genre)
        {
            if (id != genre.GenreID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreExists(genre.GenreID))
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
            ViewData["GenreTypes"] = new SelectList(GetGenreTypes(), "Id", "Value");
            return View(genre);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var genreTypes = GetGenreTypes();
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _context.Genres
                .SingleOrDefaultAsync(m => m.GenreID == id);
            if (genre == null)
            {
                return NotFound();
            }
            ViewData["GenreTypes"] = new SelectList(GetGenreTypes(), "Id", "Value");
            return View(genre);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genre = await _context.Genres.SingleOrDefaultAsync(m => m.GenreID == id);
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool GenreExists(int id)
        {
            return _context.Genres.Any(e => e.GenreID == id);
        }
    }
}
