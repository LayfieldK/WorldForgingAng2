using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldForgingApi.Migrations
{
    public partial class EntityRelationshipEntityIDsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityRelationships_Entities_Entity1Id",
                table: "EntityRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityRelationships_Entities_Entity2Id",
                table: "EntityRelationships");

            migrationBuilder.AlterColumn<int>(
                name: "Entity2Id",
                table: "EntityRelationships",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Entity1Id",
                table: "EntityRelationships",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityRelationships_Entities_Entity1Id",
                table: "EntityRelationships",
                column: "Entity1Id",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityRelationships_Entities_Entity2Id",
                table: "EntityRelationships",
                column: "Entity2Id",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityRelationships_Entities_Entity1Id",
                table: "EntityRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityRelationships_Entities_Entity2Id",
                table: "EntityRelationships");

            migrationBuilder.AlterColumn<int>(
                name: "Entity2Id",
                table: "EntityRelationships",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "Entity1Id",
                table: "EntityRelationships",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityRelationships_Entities_Entity1Id",
                table: "EntityRelationships",
                column: "Entity1Id",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityRelationships_Entities_Entity2Id",
                table: "EntityRelationships",
                column: "Entity2Id",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
