using System;
using System.Collections.Generic;

namespace SamsBookReviewLibary.Models
{
    public class BookTitle
    {
        public int BookTitleID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Language { get; set; }
        public string Sypnosis { get; set; }
        public string ImgThumbNail { get; set; }

        ICollection<AuthorBooks> AuthorBooks { get; set; }
        ICollection<BookTitleGenres> BookTitleGenres { get; set; }
        ICollection<Reviews> Reviews { get; set; }
    }
}
