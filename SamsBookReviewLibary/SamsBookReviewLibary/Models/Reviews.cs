namespace SamsBookReviewLibary.Models
{
    public class Reviews
    {
        public int ReviewsID { get; set; }
        public int BookTitleID { get; set; }
        public BookTitle BookTitle { get; set; }
        public Rating Rating { get; set; }
        public string Summary { get; set; }
    }
    public enum Rating
    {
        Bad,
        Decent,
        Good,
        Excellent,
        Outstanding
    }
}