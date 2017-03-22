using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WorldForgingApi.Migrations
{
    public partial class FixedTypoInEntityRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityRelationships_Entities_Entity1Id",
                table: "EntityRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityRelationships_Entities_Entity2Id",
                table: "EntityRelationships");

            migrationBuilder.DropTable(
                name: "EntityBelief");

            migrationBuilder.DropTable(
                name: "EntityConvention");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityRelationships_Entities_Entity1Id",
                table: "EntityRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityRelationships_Entities_Entity2Id",
                table: "EntityRelationships");

            migrationBuilder.CreateTable(
                name: "EntityBelief",
                columns: table => new
                {
                    EntityBeliefId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeliefId = table.Column<int>(nullable: false),
                    EntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityBelief", x => x.EntityBeliefId);
                    table.ForeignKey(
                        name: "FK_EntityBelief_Beliefs_BeliefId",
                        column: x => x.BeliefId,
                        principalTable: "Beliefs",
                        principalColumn: "BeliefId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityBelief_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityConvention",
                columns: table => new
                {
                    EntityConventionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConventionId = table.Column<int>(nullable: false),
                    EntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityConvention", x => x.EntityConventionId);
                    table.ForeignKey(
                        name: "FK_EntityConvention_Conventions_ConventionId",
                        column: x => x.ConventionId,
                        principalTable: "Conventions",
                        principalColumn: "ConventionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityConvention_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AlterColumn<int>(
                name: "Entity2Id",
                table: "EntityRelationships",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Entity1Id",
                table: "EntityRelationships",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntityBelief_BeliefId",
                table: "EntityBelief",
                column: "BeliefId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityBelief_EntityId",
                table: "EntityBelief",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityConvention_ConventionId",
                table: "EntityConvention",
                column: "ConventionId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityConvention_EntityId",
                table: "EntityConvention",
                column: "EntityId");

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
    }
}
