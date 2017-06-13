using System.Collections.Generic;
using System.Linq;
using SamsBookReviewLibary.Models;
using SamsBookReviewLibary.Data;
using Microsoft.EntityFrameworkCore;

namespace SamsBookReviewLibary.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AuthorContext _context;

        public AuthorRepository(AuthorContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> Authors => _context.Authors.Include(x => x.AuthorBooks).ToList();

        public Author GetAuthorById(int authorId)
        {
          var author = _context.Authors.SingleOrDefault(a => a.AuthorID == authorId);
            return author;
        }
        
    }
}
