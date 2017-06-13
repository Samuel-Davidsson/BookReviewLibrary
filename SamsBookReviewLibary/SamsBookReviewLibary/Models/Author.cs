using System;
using System.Collections.Generic;

namespace SamsBookReviewLibary.Models
{
    public class Author
    {       
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string ImgThumbNail { get; set; }
        public string Info { get; set; }

        public ICollection<AuthorBooks> AuthorBooks { get; set; }
        

    }
}
