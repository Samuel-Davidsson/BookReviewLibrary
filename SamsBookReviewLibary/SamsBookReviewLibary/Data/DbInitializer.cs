using Microsoft.EntityFrameworkCore;
using SamsBookReviewLibary.Models;
using System;
using System.Linq;

namespace SamsBookReviewLibary.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AuthorContext context)
        {
            context.Database.EnsureCreated();

            if (context.Authors.Any() && context.Reviews.Any())
            {
                return;
            }
            
            var author1 = new Author {FirstName = "Joanne", LastName = "Rowling", BirthDate = DateTime.Parse("1965-07-31"), Country = "England", Info = "Born in Yate, England, on July 31, 1965, J.K. Rowling came from humble economic means before writing Harry Potter and the Sorcerer's Stone, a children's fantasy novel. The work was an international hit and Rowling wrote six more books in the series, which sold hundreds of millions of copies and was adapted into a blockbuster film franchise. In 2012, Rowling released the novel The Casual Vacancy.", ImgThumbNail= "http://www.telegraph.co.uk/content/dam/theatre/2016/08/01/104442168_Outside_of_UK_subscription_deals__Mandatory_Credit_Photo_by_Dan_Wooller-REX-Shuttersto-large_trans_NvBQzQNjv4BqG3y1or8MxYrMaTAK0-JyORaB5T4I2cSG1TNx90iUDX0.jpg" };
            var author2 = new Author {FirstName = "Lillen", LastName = "Eriksson", BirthDate = DateTime.Parse("2001-10-10"), Country = "Sweden", Info = "Cool kis", ImgThumbNail= "http://www.wargardaihs.se/globalassets/wargarda-idrottshistoriska-sallskap/bilder/var-idrottshistorik/profiler/profiler/bernt-lillen-helgesson.jpg" };
            var author3 = new Author { FirstName = "David", LastName = "Gemmell", BirthDate = DateTime.Parse("1948-08-1"), Country = "England", Info = "A British author of heroic fantasy, best known for his debut, Legend. A former journalist and newspaper editor, Gemmell had his first work of fiction published in 1984. He went on to write over thirty novels. Gemmell's works display violence", ImgThumbNail = "http://static.hitek.fr/img/actualite/2015/12/21/david-gemmell-1926602.jpg" };
            var author4 = new Author {FirstName="Thomas", LastName="Harris", BirthDate=DateTime.Parse("1940-04-11"), Country="United States", Info= "A American writer, best known for a series of suspense novels about his most famous character, Hannibal Lecter. All of his works have been made into films, the most notable being the multi-Oscar-winning The Silence of the Lambs, which became only the third film in Academy Award history to sweep the Oscars in major categories", ImgThumbNail= "http://www.famousauthors.org/famous-authors/thomas-harris.jpg" };
            var authors = new Author[]
            {
               author1, author2, author3, author4
            };
            context.Authors.AddRange(authors);
            context.SaveChanges();

            var book1 = new BookTitle { Title = "Harry Potter and the Sorcerer's Stone", Language = "English", Sypnosis = "Rescued from the outrageous neglect of his aunt and uncle, a young boy with a great destiny proves his worth while attending Hogwarts School of Witchcraft and Wizardry.", ReleaseDate = DateTime.Parse("2001-04-11"), ImgThumbNail= "http://bookriotcom.c.presscdn.com/wp-content/uploads/2014/08/HP_swedish_1.png" };
            var book2 = new BookTitle { Title = "Harry Potter and the chamber of secrets", Language = "English", Sypnosis = "Harry Potter returns to Hogwarts", ReleaseDate = DateTime.Parse("2002-03-11"), ImgThumbNail= "https://bilder.akademibokhandeln.se/images_akb/9789129675559_383/harry-potter-och-hemligheternas-kammare" };
            var book3 = new BookTitle { Title = "Legend", Language = "English", Sypnosis = "Druss, Captain of the Axe, whose fame was legendary, had chosen to wait for death in a mountain hideaway. But mighty Dros Delnoch, the last stronghold of the Drenai Empire, was under threat from Nadir hordes who had destroyed everything else in their path. All hope rests on the skills of one man.", ReleaseDate = DateTime.Parse("1984-07-10"), ImgThumbNail = "https://upload.wikimedia.org/wikipedia/en/3/3e/Legend_Book_Cover.jpg" };
            var book4 = new BookTitle { Title = "Harry Potter and the Prisoner of Azkaban", Language="English", Sypnosis= "Harry is back at the Dursleys, where he sees on Muggle television that a prisoner named Sirius Black has escaped. Harry involuntarily inflates Aunt Marge when she comes to visit after she insults Harry and his parents. This leads to his running away and getting picked up by the Knight Bus. He travels to the Leaky Cauldron.", ReleaseDate=DateTime.Parse("2004-10-20"), ImgThumbNail= "https://bilder.akademibokhandeln.se/images_akb/9789188877444_383/harry-potter-och-fangen-fran-azkaban" };
            var book5 = new BookTitle { Title = "Harry Potter and the Goblet of Fire", Language="English", Sypnosis= "Harry Potter dreams of Frank Bryce, who is killed after overhearing Lord Voldemort discussing plans with Peter Pettigrew and another man. Harry attends the Quidditch World Cup between Ireland and Bulgaria with the Weasleys, but after the game Death Eaters terrorise the spectators, and the man who appeared in Harry's dream summons the Dark Mark.", ReleaseDate=DateTime.Parse("2005-02-10"), ImgThumbNail= "https://cdn3.cdnme.se/cdn/8-1/3540498/images/2012/hp-och-den-flammande-bagaren_502379b2ddf2b31d48000000.jpg" };
            var book6 = new BookTitle { Title = "The Silence of the Lambs", Language = "English", Sypnosis = "Clarice Starling, a young FBI trainee, is asked to carry out an errand by Jack Crawford, the head of the FBI division that draws up psychological profiles of serial killers. Starling is to present a questionnaire to the brilliant forensic psychiatrist and cannibalistic serial killer, Hannibal Lecter. Lecter is serving nine consecutive life sentences in a Maryland mental institution for a series of murders.", ReleaseDate=DateTime.Parse("1988-01-10"), ImgThumbNail= "https://images-na.ssl-images-amazon.com/images/I/615WItilpgL._SX322_BO1,204,203,200_.jpg" };
            var book7 = new BookTitle { Title = "The Legend of Deathwalker", Language="English", Sypnosis= "The novel begins during the events in the book Legend, During the defense of the fortress Dros Delnoch from the Nadir, Druss begins to tell a young warrior a story from his past. He tells how he and his friend Sieben travelled to the land of the Gothir and how he became involved in the political affairs there.", ReleaseDate=DateTime.Parse("1995-05-10"), ImgThumbNail= "http://images.gr-assets.com/books/1359618215l/568106.jpg" };
            var book8 = new BookTitle { Title="Red Dragon", Language="English", Sypnosis= "In 1978, a serial killer nicknamed The Tooth Fairy stalks and murders seemingly random families during sequential full moons. He first kills the Jacobi family in Birmingham, Alabama, then the Leeds family in Atlanta, Georgia. Two days after the Leeds murders, FBI agent Jack Crawford seeks out his protégé,", ReleaseDate=DateTime.Parse("1981-05-05"), ImgThumbNail= "https://images-na.ssl-images-amazon.com/images/I/51CEI9BTW5L._SX280_BO1,204,203,200_.jpg" };
            var books = new BookTitle[]
            {
                book1, book2, book3, book4, book5, book6, book7, book8
            };
            context.BookTitles.AddRange(books);
            context.SaveChanges();


            var authorBooks = new AuthorBooks[]
            {
                new AuthorBooks {Author=author1, BookTitle=book1},
                new AuthorBooks {Author=author1, BookTitle=book2 },
                new AuthorBooks {Author=author3, BookTitle=book3},
                new AuthorBooks {Author=author1, BookTitle=book4},
                new AuthorBooks {Author=author1, BookTitle=book5},
                new AuthorBooks {Author=author4, BookTitle=book6},
                new AuthorBooks {Author=author3, BookTitle=book7},
                new AuthorBooks {Author=author4, BookTitle=book8}
            };
            context.AuthorBooks.AddRange(authorBooks);
            context.SaveChanges();

            var genre1 = new Genre {GenreType = GenreType.Fantasy, Description = "Dragons magic trolls and orcs" };
            var genre2 = new Genre {GenreType = GenreType.Thriller, Description = "Folkets favorit" };
            var genre3 = new Genre { GenreType = GenreType.Horror, Description = "Scary!" };
            var genres = new Genre[]
            {
               genre1, genre2, genre3
            };
            context.Genres.AddRange(genres);
            context.SaveChanges();


            var bookTitleGenres = new BookTitleGenres[]
            {
                new BookTitleGenres{BookTitle=book1, Genre=genre1},
                new BookTitleGenres{BookTitle=book2, Genre=genre1},
                new BookTitleGenres{BookTitle=book3, Genre=genre1},
                new BookTitleGenres{BookTitle=book4, Genre=genre1},
                new BookTitleGenres{BookTitle=book5, Genre=genre1},
                new BookTitleGenres{BookTitle=book6, Genre=genre2},
                new BookTitleGenres{BookTitle=book7, Genre=genre1},
                new BookTitleGenres{BookTitle=book8, Genre=genre3},

            };
            context.BookTitleGenres.AddRange(bookTitleGenres);
            context.SaveChanges();


            var review1 = new Reviews { BookTitle = book1, Rating = Rating.Outstanding, Summary = "A very good book exciting and loads of magic" };
            var review2 = new Reviews { BookTitle = book1, Rating = Rating.Excellent, Summary = "Love it epic story" };
            var review3 = new Reviews { BookTitle = book8, Rating = Rating.Excellent, Summary = "Great book scare and really makes me tingle" };
            var review4 = new Reviews { BookTitle = book5, Rating = Rating.Bad, Summary = "Didnt like this book at all slow pacing and didnt make alot of sense at the end" };
            var reviews = new Reviews[]
            {
               review1, review2, review3, review4             
            };
            context.Reviews.AddRange(reviews);
            context.SaveChanges();

        }

    }
}
