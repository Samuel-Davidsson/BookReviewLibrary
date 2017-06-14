using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SamsBookReviewLibary.Data;
using SamsBookReviewLibary.Models;
using SamsBookReviewLibary.Repositories;

namespace SamsBookReviewLibary.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly AuthorContext _context;
        private readonly IReviewRepository _reviewRepo;
        private readonly IBookTitleRepository _bookTitleRepo;

        public ReviewsController(AuthorContext context, IReviewRepository reviewRepo, IBookTitleRepository bookTitleRepo)
        {
            _context = context;
            _reviewRepo = reviewRepo;
            _bookTitleRepo = bookTitleRepo;
        }


        public IActionResult Index()
        {
            var authorRepo = _reviewRepo.Reviews;
            return View(authorRepo.ToList());
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var reviews = _reviewRepo.Reviews.FirstOrDefault(r =>r.ReviewsID == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }


        public IActionResult Create()
        {
            ViewData["BookTitleID"] = new SelectList(_bookTitleRepo.BookTitles, "BookTitleID", "Title");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ReviewsID,BookTitleID,Rating,Summary")] Reviews reviews)
        {
            if (ModelState.IsValid)
            {
                _reviewRepo.Create(reviews);
                return RedirectToAction("Index");
            }
            ViewData["BookTitleID"] = new SelectList(_bookTitleRepo.BookTitles, "BookTitleID", "Title", reviews.BookTitleID);
            return View(reviews);
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var reviews = _reviewRepo.GetReviewById(id);
            if (reviews == null)
            {
                return NotFound();
            }
            ViewData["BookTitleID"] = new SelectList(_bookTitleRepo.BookTitles, "BookTitleID", "Title", reviews.BookTitleID);
            return View(reviews);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ReviewsID,BookTitleID,Rating,Summary")] Reviews reviews)
        {
            if (id != reviews.ReviewsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _reviewRepo.Edit(reviews);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewsExists(reviews.ReviewsID))
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
            ViewData["BookTitleID"] = new SelectList(_bookTitleRepo.BookTitles, "BookTitleID", "Title", reviews.BookTitleID);
            return View(reviews);
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var reviews = _reviewRepo.Reviews
                .SingleOrDefault(m => m.ReviewsID == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var reviews = _reviewRepo.GetReviewById(id);
            _reviewRepo.Delete(reviews);

            return RedirectToAction("Index");
        }

        private bool ReviewsExists(int id)
        {
            return _reviewRepo.Exist(id);
        }
    }
}
