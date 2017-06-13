namespace SamsBookReviewLibary.Models
{
    public class AuthorBooks
    {
        public int AuthorBooksID { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public int BookTitleID { get; set; }
        public BookTitle BookTitle { get; set; }
    }
}