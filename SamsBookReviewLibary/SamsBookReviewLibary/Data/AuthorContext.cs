using Microsoft.EntityFrameworkCore;
using SamsBookReviewLibary.Models;

namespace SamsBookReviewLibary.Data
{
    public class AuthorContext : DbContext
    {
        public AuthorContext(DbContextOptions<AuthorContext> options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<BookTitle> BookTitles { get; set; }
        public DbSet<AuthorBooks> AuthorBooks { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookTitleGenres> BookTitleGenres { get; set; }
        public DbSet<Reviews> Reviews { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //              "Server = (localdb)\\mssqllocaldb; Database = SamsBooks; Trusted_Connection = True; ");
        //}
    }
}
