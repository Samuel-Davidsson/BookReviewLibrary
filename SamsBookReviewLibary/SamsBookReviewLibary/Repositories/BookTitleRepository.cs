using System.Collections.Generic;
using System.Linq;
using SamsBookReviewLibary.Models;
using SamsBookReviewLibary.Data;
using Microsoft.EntityFrameworkCore;

namespace SamsBookReviewLibary.Repositories
{
    public class BookTitleRepository : IBookTitleRepository
    {
        private readonly AuthorContext _context;

        public BookTitleRepository(AuthorContext context)
        {
            _context = context;
        }
        public IEnumerable<BookTitle> BookTitles => _context.BookTitles.Include(b => b.AuthorBooks).Include(b =>b.BookTitleGenres). Include(b => b.Reviews).ToList();

        public void Create(BookTitle bookTitle)
        {
            _context.Add(bookTitle);
            _context.SaveChanges();
        }

        public void Delete(BookTitle bookTitle)
        {
            _context.Remove(bookTitle);
            _context.SaveChanges();
        }

        public void Edit(BookTitle bookTitle)
        {
            _context.Update(bookTitle);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.BookTitles.Any(b => b.BookTitleID == id);
        }

        public IEnumerable<BookTitle> GetAll()
        {
            var authors = _context.BookTitles.Include(b => b.AuthorBooks).Include(b => b.BookTitleGenres).Include(b => b.Reviews).ToList();
            return (authors);
        }

        public BookTitle GetBookTitleById(int booktitleId)
        {
            var author = _context.BookTitles.SingleOrDefault(b => b.BookTitleID == booktitleId);
            return author;
        }
    }
}
