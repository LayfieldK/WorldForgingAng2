using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WorldForgingApi.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Worlds",
                columns: table => new
                {
                    WorldId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worlds", x => x.WorldId);
                });

            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    EntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    WorldId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Entities_Worlds_WorldId",
                        column: x => x.WorldId,
                        principalTable: "Worlds",
                        principalColumn: "WorldId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityRelationships",
                columns: table => new
                {
                    EntityRelationshipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    WorldId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityRelationships", x => x.EntityRelationshipId);
                    table.ForeignKey(
                        name: "FK_EntityRelationships_Worlds_WorldId",
                        column: x => x.WorldId,
                        principalTable: "Worlds",
                        principalColumn: "WorldId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WorldId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_Subjects_Worlds_WorldId",
                        column: x => x.WorldId,
                        principalTable: "Worlds",
                        principalColumn: "WorldId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Characters_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Groups_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescriptionShort = table.Column<string>(nullable: true),
                    EntityId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    WorldEventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.WorldEventId);
                    table.ForeignKey(
                        name: "FK_Events_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Beliefs",
                columns: table => new
                {
                    BeliefId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beliefs", x => x.BeliefId);
                    table.ForeignKey(
                        name: "FK_Beliefs_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conventions",
                columns: table => new
                {
                    ConventionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conventions", x => x.ConventionId);
                    table.ForeignKey(
                        name: "FK_Conventions_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Desires",
                columns: table => new
                {
                    DesireId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desires", x => x.DesireId);
                    table.ForeignKey(
                        name: "FK_Desires_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reasons",
                columns: table => new
                {
                    ReasonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reasons", x => x.ReasonId);
                    table.ForeignKey(
                        name: "FK_Reasons_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cultures",
                columns: table => new
                {
                    CultureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultures", x => x.CultureId);
                    table.ForeignKey(
                        name: "FK_Cultures_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    FactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescriptionShort = table.Column<string>(nullable: true),
                    GroupId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.FactionId);
                    table.ForeignKey(
                        name: "FK_Factions_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    RaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.RaceId);
                    table.ForeignKey(
                        name: "FK_Races_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Religions",
                columns: table => new
                {
                    ReligionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religions", x => x.ReligionId);
                    table.ForeignKey(
                        name: "FK_Religions_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeliefEntity",
                columns: table => new
                {
                    BeliefEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeliefId = table.Column<int>(nullable: false),
                    EntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeliefEntity", x => x.BeliefEntityId);
                    table.ForeignKey(
                        name: "FK_BeliefEntity_Beliefs_BeliefId",
                        column: x => x.BeliefId,
                        principalTable: "Beliefs",
                        principalColumn: "BeliefId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeliefEntity_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BeliefSubject",
                columns: table => new
                {
                    BeliefSubjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeliefId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeliefSubject", x => x.BeliefSubjectId);
                    table.ForeignKey(
                        name: "FK_BeliefSubject_Beliefs_BeliefId",
                        column: x => x.BeliefId,
                        principalTable: "Beliefs",
                        principalColumn: "BeliefId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeliefSubject_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                });

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
                        principalColumn: "EntityId",
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
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DesireEntity",
                columns: table => new
                {
                    DesireEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesireId = table.Column<int>(nullable: false),
                    EntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesireEntity", x => x.DesireEntityId);
                    table.ForeignKey(
                        name: "FK_DesireEntity_Desires_DesireId",
                        column: x => x.DesireId,
                        principalTable: "Desires",
                        principalColumn: "DesireId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DesireEntity_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DesireSubject",
                columns: table => new
                {
                    DesireSubjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesireId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesireSubject", x => x.DesireSubjectId);
                    table.ForeignKey(
                        name: "FK_DesireSubject_Desires_DesireId",
                        column: x => x.DesireId,
                        principalTable: "Desires",
                        principalColumn: "DesireId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DesireSubject_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityDesire",
                columns: table => new
                {
                    EntityDesireId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesireId = table.Column<int>(nullable: false),
                    EntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityDesire", x => x.EntityDesireId);
                    table.ForeignKey(
                        name: "FK_EntityDesire_Desires_DesireId",
                        column: x => x.DesireId,
                        principalTable: "Desires",
                        principalColumn: "DesireId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityDesire_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReasonEntity",
                columns: table => new
                {
                    ReasonEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityId = table.Column<int>(nullable: true),
                    ReasonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonEntity", x => x.ReasonEntityId);
                    table.ForeignKey(
                        name: "FK_ReasonEntity_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReasonEntity_Reasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "Reasons",
                        principalColumn: "ReasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReasonSubject",
                columns: table => new
                {
                    ReasonSubjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReasonId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonSubject", x => x.ReasonSubjectId);
                    table.ForeignKey(
                        name: "FK_ReasonSubject_Reasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "Reasons",
                        principalColumn: "ReasonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReasonSubject_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityDesireReason",
                columns: table => new
                {
                    EntityDesireReasonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityDesireId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityDesireReason", x => x.EntityDesireReasonId);
                    table.ForeignKey(
                        name: "FK_EntityDesireReason_EntityDesire_EntityDesireId",
                        column: x => x.EntityDesireId,
                        principalTable: "EntityDesire",
                        principalColumn: "EntityDesireId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beliefs_SubjectId",
                table: "Beliefs",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_BeliefEntity_BeliefId",
                table: "BeliefEntity",
                column: "BeliefId");

            migrationBuilder.CreateIndex(
                name: "IX_BeliefEntity_EntityId",
                table: "BeliefEntity",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_BeliefSubject_BeliefId",
                table: "BeliefSubject",
                column: "BeliefId");

            migrationBuilder.CreateIndex(
                name: "IX_BeliefSubject_SubjectId",
                table: "BeliefSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_EntityId",
                table: "Characters",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Conventions_SubjectId",
                table: "Conventions",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Cultures_GroupId",
                table: "Cultures",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Desires_SubjectId",
                table: "Desires",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DesireEntity_DesireId",
                table: "DesireEntity",
                column: "DesireId");

            migrationBuilder.CreateIndex(
                name: "IX_DesireEntity_EntityId",
                table: "DesireEntity",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DesireSubject_DesireId",
                table: "DesireSubject",
                column: "DesireId");

            migrationBuilder.CreateIndex(
                name: "IX_DesireSubject_SubjectId",
                table: "DesireSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_WorldId",
                table: "Entities",
                column: "WorldId");

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

            migrationBuilder.CreateIndex(
                name: "IX_EntityDesire_DesireId",
                table: "EntityDesire",
                column: "DesireId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityDesire_EntityId",
                table: "EntityDesire",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityDesireReason_EntityDesireId",
                table: "EntityDesireReason",
                column: "EntityDesireId");

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
                name: "IX_EntityRelationships_WorldId",
                table: "EntityRelationships",
                column: "WorldId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityRelationshipReason_EntityRelationshipId",
                table: "EntityRelationshipReason",
                column: "EntityRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Factions_GroupId",
                table: "Factions",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_EntityId",
                table: "Groups",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_EntityId",
                table: "Items",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_EntityId",
                table: "Locations",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_GroupId",
                table: "Races",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Reasons_SubjectId",
                table: "Reasons",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonEntity_EntityId",
                table: "ReasonEntity",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonEntity_ReasonId",
                table: "ReasonEntity",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonSubject_ReasonId",
                table: "ReasonSubject",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonSubject_SubjectId",
                table: "ReasonSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Religions_GroupId",
                table: "Religions",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_WorldId",
                table: "Subjects",
                column: "WorldId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EntityId",
                table: "Events",
                column: "EntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeliefEntity");

            migrationBuilder.DropTable(
                name: "BeliefSubject");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Cultures");

            migrationBuilder.DropTable(
                name: "DesireEntity");

            migrationBuilder.DropTable(
                name: "DesireSubject");

            migrationBuilder.DropTable(
                name: "EntityBelief");

            migrationBuilder.DropTable(
                name: "EntityConvention");

            migrationBuilder.DropTable(
                name: "EntityDesireReason");

            migrationBuilder.DropTable(
                name: "EntityEntities");

            migrationBuilder.DropTable(
                name: "EntityRelationshipReason");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "ReasonEntity");

            migrationBuilder.DropTable(
                name: "ReasonSubject");

            migrationBuilder.DropTable(
                name: "Religions");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Beliefs");

            migrationBuilder.DropTable(
                name: "Conventions");

            migrationBuilder.DropTable(
                name: "EntityDesire");

            migrationBuilder.DropTable(
                name: "EntityRelationships");

            migrationBuilder.DropTable(
                name: "Reasons");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Desires");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Worlds");
        }
    }
}
