using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamsBookReviewLibary.Data;
using SamsBookReviewLibary.Models;
using SamsBookReviewLibary.Repositories;

namespace SamsBookReviewLibary.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly AuthorContext _context;
        private readonly IAuthorRepository _authorRepo;
        public AuthorsController(AuthorContext context, IAuthorRepository authorRepo)
        {
            _context = context;
            _authorRepo = authorRepo;
        }

        public IActionResult Index()
        {
            return View(_authorRepo.Authors.ToList());
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var listOfBooks = _context.AuthorBooks.Where(r => r.AuthorID == id).Select(r => r.BookTitle.Title);
            ViewBag.AuthorBooks = listOfBooks;
            var author = _authorRepo.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("AuthorID,FirstName,LastName,BirthDate,Country,ImgThumbNail,Info")] Author author)
        {
            if (ModelState.IsValid)
            {
                _authorRepo.Create(author);
                return RedirectToAction("Index");
            }
            return View(author);
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var author = _authorRepo.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("AuthorID,FirstName,LastName,BirthDate,Country,ImgThumbNail,Info")] Author author)
        {
            if (id != author.AuthorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _authorRepo.Edit(author);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(author.AuthorID))
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
            return View(author);
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var author = _authorRepo.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var author = _authorRepo.Authors.SingleOrDefault(m => m.AuthorID == id);
            _authorRepo.Delete(author);
            return RedirectToAction("Index");
        }

        private bool AuthorExists(int id)
        {
            return _authorRepo.Exist(id);
        }
    }
}
