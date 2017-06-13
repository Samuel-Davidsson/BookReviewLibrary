namespace SamsBookReviewLibary.Models
{
    public class BookTitleGenres
    {
        public int BookTitleGenresID { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
        public int BookTitleID { get; set; }
        public BookTitle BookTitle { get; set; }
    }
}