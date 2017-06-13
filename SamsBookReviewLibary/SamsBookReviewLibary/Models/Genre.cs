using System.Collections.Generic;

namespace SamsBookReviewLibary.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public GenreType GenreType { get; set; }
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
