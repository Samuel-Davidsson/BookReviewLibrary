using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SamsBookReviewLibary.Models
{
    public class BookTitle
    {
        public int BookTitleID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public string Language { get; set; }
        public string Sypnosis { get; set; }
        public string ImgThumbNail { get; set; }

        public ICollection<AuthorBooks> AuthorBooks { get; set; }
        public ICollection<BookTitleGenres> BookTitleGenres { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
    }
}
