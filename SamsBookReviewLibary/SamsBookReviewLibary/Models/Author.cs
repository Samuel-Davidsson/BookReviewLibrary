using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SamsBookReviewLibary.Models
{
    public class Author
    {


        public int AuthorID { get; set; }

        [Required]
        [StringLength(50, MinimumLength =3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        public string Country { get; set; }
        public string ImgThumbNail { get; set; }
        public string Info { get; set; }

        public ICollection<AuthorBooks> AuthorBooks { get; set; }
        

    }
}
