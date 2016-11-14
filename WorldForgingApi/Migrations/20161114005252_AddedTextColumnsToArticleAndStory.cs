using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldForgingApi.Migrations
{
    public partial class AddedTextColumnsToArticleAndStory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Stories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Stories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrlAffix",
                table: "Stories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrlAffix",
                table: "Articles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "UrlAffix",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "UrlAffix",
                table: "Articles");
        }
    }
}
