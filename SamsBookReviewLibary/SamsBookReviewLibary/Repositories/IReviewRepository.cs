using SamsBookReviewLibary.Models;
using System.Collections.Generic;

namespace SamsBookReviewLibary.Repositories
{
    public interface IReviewRepository
    {
        IEnumerable<Reviews> Reviews { get; }

        Reviews GetReviewById(int reviewId);

        IEnumerable<Reviews> GetAll();

        void Create(Reviews review);

        void Edit(Reviews review);

        void Delete(Reviews review);

        bool Exist(int id);

        Reviews GetByIdIncluded(int id);
    }
}
