using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WorldForgingApi.Migrations
{
    public partial class Firstdraftofrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityRelationships_Worlds_WorldId",
                table: "EntityRelationships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityRelationships",
                table: "EntityRelationships");

            migrationBuilder.DropIndex(
                name: "IX_EntityRelationships_WorldId",
                table: "EntityRelationships");

            migrationBuilder.DropColumn(
                name: "EntityRelationshipId",
                table: "EntityRelationships");

            migrationBuilder.DropColumn(
                name: "WorldId",
                table: "EntityRelationships");

            migrationBuilder.DropTable(
                name: "EntityEntities");

            migrationBuilder.DropTable(
                name: "EntityRelationshipReason");

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    InverseRelationshipId = table.Column<int>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relationships_Relationships_InverseRelationshipId",
                        column: x => x.InverseRelationshipId,
                        principalTable: "Relationships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relationships_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EntityRelationships",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EntityRelationships",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Entity1EntityId",
                table: "EntityRelationships",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Entity2EntityId",
                table: "EntityRelationships",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InverseEntityRelationshipId",
                table: "EntityRelationships",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "EntityRelationships",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RelationshipId",
                table: "EntityRelationships",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "EntityRelationships",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityRelationships",
                table: "EntityRelationships",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EntityRelationships_Entity1EntityId",
                table: "EntityRelationships",
                column: "Entity1EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityRelationships_Entity2EntityId",
                table: "EntityRelationships",
                column: "Entity2EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityRelationships_InverseEntityRelationshipId",
                table: "EntityRelationships",
                column: "InverseEntityRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityRelationships_RelationshipId",
                table: "EntityRelationships",
                column: "RelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityRelationships_UserId",
                table: "EntityRelationships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_InverseRelationshipId",
                table: "Relationships",
                column: "InverseRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_UserId",
                table: "Relationships",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityRelationships_Entities_Entity1EntityId",
                table: "EntityRelationships",
                column: "Entity1EntityId",
                principalTable: "Entities",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityRelationships_Entities_Entity2EntityId",
                table: "EntityRelationships",
                column: "Entity2EntityId",
                principalTable: "Entities",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityRelationships_EntityRelationships_InverseEntityRelationshipId",
                table: "EntityRelationships",
                column: "InverseEntityRelationshipId",
                principalTable: "EntityRelationships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityRelationships_Relationships_RelationshipId",
                table: "EntityRelationships",
                column: "RelationshipId",
                principalTable: "Relationships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityRelationships_Users_UserId",
                table: "EntityRelationships",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityRelationships_Entities_Entity1EntityId",
                table: "EntityRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityRelationships_Entities_Entity2EntityId",
                table: "EntityRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityRelationships_EntityRelationships_InverseEntityRelationshipId",
                table: "EntityRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityRelationships_Relationships_RelationshipId",
                table: "EntityRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityRelationships_Users_UserId",
                table: "EntityRelationships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityRelationships",
                table: "EntityRelationships");

            migrationBuilder.DropIndex(
                name: "IX_EntityRelationships_Entity1EntityId",
                table: "EntityRelationships");

            migrationBuilder.DropIndex(
                name: "IX_EntityRelationships_Entity2EntityId",
                table: "EntityRelationships");

            migrationBuilder.DropIndex(
                name: "IX_EntityRelationships_InverseEntityRelationshipId",
                table: "EntityRelationships");

            migrationBuilder.DropIndex(
                name: "IX_EntityRelationships_RelationshipId",
                table: "EntityRelationships");

            migrationBuilder.DropIndex(
                name: "IX_EntityRelationships_UserId",
                table: "EntityRelationships");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EntityRelationships");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EntityRelationships");

            migrationBuilder.DropColumn(
                name: "Entity1EntityId",
                table: "EntityRelationships");

            migrationBuilder.DropColumn(
                name: "Entity2EntityId",
                table: "EntityRelationships");

            migrationBuilder.DropColumn(
                name: "InverseEntityRelationshipId",
                table: "EntityRelationships");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "EntityRelationships");

            migrationBuilder.DropColumn(
                name: "RelationshipId",
                table: "EntityRelationships");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EntityRelationships");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.CreateTable(
                name: "EntityEntities",
                columns: table => new
                {
                    EntityEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Entity1Id = table.Column<int>(nullable: false),
                    Entity2Id = table.Column<int>(nullable: true),
                    EntityRelationshipId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityEntities", x => x.EntityEntityId);
                    table.ForeignKey(
                        name: "FK_EntityEntities_Entities_Entity1Id",
                        column: x => x.Entity1Id,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityEntities_Entities_Entity2Id",
                        column: x => x.Entity2Id,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityEntities_EntityRelationships_EntityRelationshipId",
                        column: x => x.EntityRelationshipId,
                        principalTable: "EntityRelationships",
                        principalColumn: "EntityRelationshipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityRelationshipReason",
                columns: table => new
                {
                    EntityRelationshipReasonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityRelationshipId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityRelationshipReason", x => x.EntityRelationshipReasonId);
                    table.ForeignKey(
                        name: "FK_EntityRelationshipReason_EntityRelationships_EntityRelationshipId",
                        column: x => x.EntityRelationshipId,
                        principalTable: "EntityRelationships",
                        principalColumn: "EntityRelationshipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<int>(
                name: "EntityRelationshipId",
                table: "EntityRelationships",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "WorldId",
                table: "EntityRelationships",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityRelationships",
                table: "EntityRelationships",
                column: "EntityRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityRelationships_WorldId",
                table: "EntityRelationships",
                column: "WorldId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityEntities_Entity1Id",
                table: "EntityEntities",
                column: "Entity1Id");

            migrationBuilder.CreateIndex(
                name: "IX_EntityEntities_Entity2Id",
                table: "EntityEntities",
                column: "Entity2Id");

            migrationBuilder.CreateIndex(
                name: "IX_EntityEntities_EntityRelationshipId",
                table: "EntityEntities",
                column: "EntityRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityRelationshipReason_EntityRelationshipId",
                table: "EntityRelationshipReason",
                column: "EntityRelationshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityRelationships_Worlds_WorldId",
                table: "EntityRelationships",
                column: "WorldId",
                principalTable: "Worlds",
                principalColumn: "WorldId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
