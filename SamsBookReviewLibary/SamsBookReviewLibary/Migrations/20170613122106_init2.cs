using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SamsBookReviewLibary.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BookTitleGenres_BookTitleID",
                table: "BookTitleGenres",
                column: "BookTitleID");

            migrationBuilder.CreateIndex(
                name: "IX_BookTitleGenres_GenreID",
                table: "BookTitleGenres",
                column: "GenreID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTitleGenres_BookTitles_BookTitleID",
                table: "BookTitleGenres",
                column: "BookTitleID",
                principalTable: "BookTitles",
                principalColumn: "BookTitleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookTitleGenres_Genres_GenreID",
                table: "BookTitleGenres",
                column: "GenreID",
                principalTable: "Genres",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTitleGenres_BookTitles_BookTitleID",
                table: "BookTitleGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_BookTitleGenres_Genres_GenreID",
                table: "BookTitleGenres");

            migrationBuilder.DropIndex(
                name: "IX_BookTitleGenres_BookTitleID",
                table: "BookTitleGenres");

            migrationBuilder.DropIndex(
                name: "IX_BookTitleGenres_GenreID",
                table: "BookTitleGenres");
        }
    }
}
