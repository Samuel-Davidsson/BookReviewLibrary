using SamsBookReviewLibary.Models;
using System.Collections.Generic;

namespace SamsBookReviewLibary.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<BookTitle> BookTitles { get; set; }
    }
}
