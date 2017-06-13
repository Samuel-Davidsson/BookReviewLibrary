using SamsBookReviewLibary.Models;
using System.Collections.Generic;

namespace SamsBookReviewLibary.Repositories
{
    public interface IBookTitleRepository
    {
        IEnumerable<BookTitle> BookTitles { get; }

        BookTitle GetBookTitleById(int booktitleId);

        IEnumerable<BookTitle> GetAll();

        void Create(BookTitle bookTitle);

        void Edit(BookTitle bookTitle);

        void Delete(BookTitle bookTitle);

        bool Exist(int id);
    }
}
