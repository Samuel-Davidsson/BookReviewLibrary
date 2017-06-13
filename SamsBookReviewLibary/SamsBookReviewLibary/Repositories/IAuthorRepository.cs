using SamsBookReviewLibary.Models;
using System.Collections.Generic;

namespace SamsBookReviewLibary.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> Authors { get; }

        Author GetAuthorById(int authorId);
    }
}
