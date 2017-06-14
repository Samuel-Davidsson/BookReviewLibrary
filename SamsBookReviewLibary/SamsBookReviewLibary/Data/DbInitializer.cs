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
            
            var author1 = new Author {FirstName = "Joanne", LastName = "Rowling", BirthDate = DateTime.Parse("1965-07-31"), Country = "England", Info = "Born in Yate, England, on July 31, 1965, J.K. Rowling came from humble economic means before writing Harry Potter and the Sorcerer's Stone, a children's fantasy novel. The work was an international hit and Rowling wrote six more books in the series, which sold hundreds of millions of copies and was adapted into a blockbuster film franchise. In 2012, Rowling released the novel The Casual Vacancy." };
            var author2 = new Author {FirstName = "Lillen", LastName = "Eriksson", BirthDate = DateTime.Parse("2001-10-10"), Country = "Sweden", Info = "Cool kis", ImgThumbNail="https://i.ytimg.com/vi/dhjx7iyQduI/maxresdefault.jpg"};

            var authors = new Author[]
            {
               author1, author2
            };
            context.Authors.AddRange(authors);
            context.SaveChanges();

            var book1 = new BookTitle {Title = "Harry Potter and the Sorcerer's Stone", Language = "English", Sypnosis = "Rescued from the outrageous neglect of his aunt and uncle, a young boy with a great destiny proves his worth while attending Hogwarts School of Witchcraft and Wizardry.", ReleaseDate = DateTime.Parse("2001-04-11") };
            var book2 = new BookTitle { Title = "Harry Potter and the chamber of secrets", Language = "English", Sypnosis = "Harry Potter returns to Hogwarts", ReleaseDate = DateTime.Parse("2003-03-11") };

            var books = new BookTitle[]
            {
                book1, book2
            };
            context.BookTitles.AddRange(books);
            context.SaveChanges();


            var authorBooks = new AuthorBooks[]
            {
                new AuthorBooks{Author=author1, BookTitle=book1}
            };
            context.AuthorBooks.AddRange(authorBooks);
            context.SaveChanges();

            var genre1 = new Genre {GenreType = GenreType.Fantasy, Description = "Dragons magic trolls and orcs" };
            var genre2 = new Genre {GenreType = GenreType.Thriller, Description = "Folkets favorit" };
            var genres = new Genre[]
            {
               genre1, genre2
            };
            context.Genres.AddRange(genres);
            context.SaveChanges();


            var bookTitleGenres = new BookTitleGenres[]
            {
                new BookTitleGenres{BookTitle=book1, Genre=genre1}
            };
            context.BookTitleGenres.AddRange(bookTitleGenres);
            context.SaveChanges();


            var review1 = new Reviews {BookTitle = book1, Rating = Rating.Outstanding, Summary = "A very good book exciting and loads of magic" };
            var review2 = new Reviews { BookTitle = book1, Rating = Rating.Excellent, Summary = "Love it epic story" };
            var reviews = new Reviews[]
            {
               review1, review2             
            };
            context.Reviews.AddRange(reviews);
            context.SaveChanges();

        }

    }
}
