using System.Collections.Generic;
using System.Linq;
using SamsBookReviewLibary.Models;
using SamsBookReviewLibary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;

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

        public void Create(Author author)
        {
            _context.Add(author);
            _context.SaveChanges();
        }

        public IEnumerable<Author> GetAll()
        {
            var authors = _context.Authors.Select(a => a);
            return (authors);
        }

        public void Edit(Author author)
        {
            _context.Update(author);
            _context.SaveChanges();
        }

        public void Delete(Author author)
        {
            _context.Remove(author);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {           
           return _context.Authors.Any(a => a.AuthorID == id);
            
        }
    }
}
