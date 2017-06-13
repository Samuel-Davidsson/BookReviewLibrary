using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SamsBookReviewLibary.Data;
using SamsBookReviewLibary.Models;

namespace SamsBookReviewLibary.Migrations
{
    [DbContext(typeof(AuthorContext))]
    [Migration("20170613122106_init2")]
    partial class init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SamsBookReviewLibary.Models.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Country");

                    b.Property<string>("FirstName");

                    b.Property<string>("ImgThumbNail");

                    b.Property<string>("Info");

                    b.Property<string>("LastName");

                    b.HasKey("AuthorID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("SamsBookReviewLibary.Models.AuthorBooks", b =>
                {
                    b.Property<int>("AuthorBooksID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorID");

                    b.Property<int>("BookTitleID");

                    b.HasKey("AuthorBooksID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("BookTitleID");

                    b.ToTable("AuthorBooks");
                });

            modelBuilder.Entity("SamsBookReviewLibary.Models.BookTitle", b =>
                {
                    b.Property<int>("BookTitleID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImgThumbNail");

                    b.Property<string>("Language");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Sypnosis");

                    b.Property<string>("Title");

                    b.HasKey("BookTitleID");

                    b.ToTable("BookTitles");
                });

            modelBuilder.Entity("SamsBookReviewLibary.Models.BookTitleGenres", b =>
                {
                    b.Property<int>("BookTitleGenresID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookTitleID");

                    b.Property<int>("GenreID");

                    b.HasKey("BookTitleGenresID");

                    b.HasIndex("BookTitleID");

                    b.HasIndex("GenreID");

                    b.ToTable("BookTitleGenres");
                });

            modelBuilder.Entity("SamsBookReviewLibary.Models.Genre", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("GenreType");

                    b.HasKey("GenreID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("SamsBookReviewLibary.Models.Reviews", b =>
                {
                    b.Property<int>("ReviewsID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookTitleID");

                    b.Property<int>("Rating");

                    b.Property<string>("Summary");

                    b.HasKey("ReviewsID");

                    b.HasIndex("BookTitleID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("SamsBookReviewLibary.Models.AuthorBooks", b =>
                {
                    b.HasOne("SamsBookReviewLibary.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SamsBookReviewLibary.Models.BookTitle", "BookTitle")
                        .WithMany()
                        .HasForeignKey("BookTitleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SamsBookReviewLibary.Models.BookTitleGenres", b =>
                {
                    b.HasOne("SamsBookReviewLibary.Models.BookTitle", "BookTitle")
                        .WithMany()
                        .HasForeignKey("BookTitleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SamsBookReviewLibary.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SamsBookReviewLibary.Models.Reviews", b =>
                {
                    b.HasOne("SamsBookReviewLibary.Models.BookTitle", "BookTitle")
                        .WithMany()
                        .HasForeignKey("BookTitleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
