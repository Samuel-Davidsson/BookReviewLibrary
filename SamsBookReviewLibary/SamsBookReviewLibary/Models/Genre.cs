using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SamsBookReviewLibary.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        [EnumDataType(typeof(GenreType))]
        public GenreType GenreTypes { get; set; }
        public string Description { get; set; }

        public ICollection<BookTitleGenres> BookTitleGenres { get; set; }
        
    }
    public enum GenreType
    {
        Poesi,
        Horror,
        Drama,
        Thriller,
        Fantasy,
        Erotic,
        Action,
        History
    }
}
