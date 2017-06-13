using SamsBookReviewLibary.Models;
using System.Collections.Generic;

namespace SamsBookReviewLibary.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> Authors { get; }

        Author GetAuthorById(int authorId);

        IEnumerable<Author> GetAll();

        void Create(Author author);

        void Edit(Author author);

        void Delete(Author author);

        bool Exist(int id);
    }
}
