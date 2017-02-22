using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WorldForgingApi.Migrations
{
    public partial class StoryChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Worlds_WorldId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Articles_ItemId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Worlds_WorldId",
                table: "Stories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stories",
                table: "Stories");

            migrationBuilder.DropIndex(
                name: "IX_Stories_WorldId",
                table: "Stories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_WorldId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "StoryId",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "UrlAffix",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "WorldId",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "UrlAffix",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "WorldId",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Stories",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Stories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Stories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Flags",
                table: "Stories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Stories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Stories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Stories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Stories",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Stories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StoryId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Articles",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Flags",
                table: "Articles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Articles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Articles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Articles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Stories",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stories",
                table: "Stories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stories_UserId",
                table: "Stories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StoryId",
                table: "Comments",
                column: "StoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "Articles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_UserId",
                table: "Articles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Articles_ItemId",
                table: "Comments",
                column: "ItemId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Stories_StoryId",
                table: "Comments",
                column: "StoryId",
                principalTable: "Stories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Users_UserId",
                table: "Stories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Users_UserId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Articles_ItemId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Stories_StoryId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Users_UserId",
                table: "Stories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stories",
                table: "Stories");

            migrationBuilder.DropIndex(
                name: "IX_Stories_UserId",
                table: "Stories");

            migrationBuilder.DropIndex(
                name: "IX_Comments_StoryId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_UserId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "Flags",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "StoryId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Flags",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Articles");

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Flags = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    ViewCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<int>(
                name: "StoryId",
                table: "Stories",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "UrlAffix",
                table: "Stories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorldId",
                table: "Stories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Entities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Articles",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "UrlAffix",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorldId",
                table: "Articles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Stories",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stories",
                table: "Stories",
                column: "StoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Stories_WorldId",
                table: "Stories",
                column: "WorldId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "Articles",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_WorldId",
                table: "Articles",
                column: "WorldId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Worlds_WorldId",
                table: "Articles",
                column: "WorldId",
                principalTable: "Worlds",
                principalColumn: "WorldId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Articles_ItemId",
                table: "Comments",
                column: "ItemId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Worlds_WorldId",
                table: "Stories",
                column: "WorldId",
                principalTable: "Worlds",
                principalColumn: "WorldId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
