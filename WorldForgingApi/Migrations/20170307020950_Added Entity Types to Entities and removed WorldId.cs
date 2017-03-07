using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldForgingApi.Migrations
{
    public partial class AddedEntityTypestoEntitiesandremovedWorldId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityTypes_Entities_EntityId",
                table: "EntityTypes");

            migrationBuilder.DropIndex(
                name: "IX_EntityTypes_EntityId",
                table: "EntityTypes");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "EntityTypes");

            migrationBuilder.AddColumn<int>(
                name: "EntityTypeId",
                table: "Entities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entities_EntityTypeId",
                table: "Entities",
                column: "EntityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entities_EntityTypes_EntityTypeId",
                table: "Entities",
                column: "EntityTypeId",
                principalTable: "EntityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entities_EntityTypes_EntityTypeId",
                table: "Entities");

            migrationBuilder.DropIndex(
                name: "IX_Entities_EntityTypeId",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "EntityTypeId",
                table: "Entities");

            migrationBuilder.AddColumn<int>(
                name: "EntityId",
                table: "EntityTypes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntityTypes_EntityId",
                table: "EntityTypes",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityTypes_Entities_EntityId",
                table: "EntityTypes",
                column: "EntityId",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
