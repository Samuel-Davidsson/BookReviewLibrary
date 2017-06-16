using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SamsBookReviewLibary.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "GenreType",
                table: "Genres");

            migrationBuilder.AddColumn<int>(
                name: "Ratings",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenreTypes",
                table: "Genres",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ratings",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "GenreTypes",
                table: "Genres");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenreType",
                table: "Genres",
                nullable: false,
                defaultValue: 0);
        }
    }
}
