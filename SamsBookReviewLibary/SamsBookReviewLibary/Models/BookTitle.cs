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

        public ICollection<AuthorBooks> AuthorBooks { get; set; }
        public ICollection<BookTitleGenres> BookTitleGenres { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
    }
}
