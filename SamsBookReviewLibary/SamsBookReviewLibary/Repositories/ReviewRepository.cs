using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SamsBookReviewLibary.Models;
using SamsBookReviewLibary.Data;
using Microsoft.EntityFrameworkCore;

namespace SamsBookReviewLibary.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AuthorContext _context;

        public ReviewRepository(AuthorContext context)
        {
            _context = context;
        }
        public IEnumerable<Reviews> Reviews => _context.Reviews.Include(r => r.BookTitle).ToList();

        public void Create(Reviews review)
        {
            _context.Add(review);
            _context.SaveChanges();
        }

        public void Delete(Reviews review)
        {
            _context.Remove(review);
            _context.SaveChanges();
        }

        public void Edit(Reviews review)
        {
            _context.Update(review);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Reviews.Any(r => r.ReviewsID == id);
        }

        public IEnumerable<Reviews> GetAll()
        {
            var reviews = _context.Reviews.Select(r => r);
            return (reviews);
        }

        public Reviews GetReviewById(int reviewId)
        {
            var review = _context.Reviews.SingleOrDefault(r => r.ReviewsID == reviewId);
            return review;
        }
    }
}
