using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamsBookReviewLibary.Data;
using SamsBookReviewLibary.Models;
using SamsBookReviewLibary.Repositories;
using System;

namespace SamsBookReviewLibary.Controllers
{
    public class BookTitlesController : Controller
    {
        private readonly AuthorContext _context;
        private readonly IBookTitleRepository _bookRepo;
        public BookTitlesController(AuthorContext context, IBookTitleRepository bookRepo)
        {
            _context = context;  
            _bookRepo = bookRepo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.BookTitles.ToListAsync());
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var listOfAuthors = _context.AuthorBooks.Where(r => r.BookTitleID == id).Select(r => r.Author).ToList();
            ViewBag.AuthorBooks = listOfAuthors;

            //var listOfEnum = Enum.GetValues(typeof(Rating)).Cast<Rating>().ToList();

            var listOfReviews = _context.Reviews.Where(r => r.BookTitleID == id).ToList();
            ViewBag.Reviews = listOfReviews;
            //var list = listOfReviews.ToList();
            //ViewBag.Reviews = list;

            var listOfGenre = _context.BookTitleGenres.Where(r => r.BookTitleID == id).Select(r => r.Genre).ToList();
            ViewBag.Genres = listOfGenre;

            var bookTitle = _bookRepo.GetBookTitleById(id);
            if (bookTitle == null)
            {
                return NotFound();
            }

            return View(bookTitle);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("BookTitleID,Title,ReleaseDate,Language,Sypnosis,ImgThumbNail")] BookTitle bookTitle)
        {
            if (ModelState.IsValid)
            {
                _bookRepo.Create(bookTitle);
                return RedirectToAction("Index");
            }
            return View(bookTitle);
        }


        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var bookTitle = _bookRepo.GetBookTitleById(id);
            if (bookTitle == null)
            {
                return NotFound();
            }
            return View(bookTitle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("BookTitleID,Title,ReleaseDate,Language,Sypnosis,ImgThumbNail")] BookTitle bookTitle)
        {
            if (id != bookTitle.BookTitleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bookRepo.Edit(bookTitle);
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

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var bookTitle = _bookRepo.GetBookTitleById(id);
                
            if (bookTitle == null)
            {
                return NotFound();
            }

            return View(bookTitle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var bookTitle = _bookRepo.GetBookTitleById(id);
            _bookRepo.Delete(bookTitle);
            return RedirectToAction("Index");
        }

        private bool BookTitleExists(int id)
        {
            return _bookRepo.Exist(id);
        }
    }
}
