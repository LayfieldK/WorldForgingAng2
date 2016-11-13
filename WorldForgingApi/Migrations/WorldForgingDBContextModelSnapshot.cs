using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WorldForgingApi.Models;

namespace WorldForgingApi.Migrations
{
    [DbContext(typeof(WorldForgingDBContext))]
    partial class WorldForgingDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WorldForging.Models.Belief", b =>
                {
                    b.Property<int>("BeliefId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("SubjectId");

                    b.HasKey("BeliefId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Beliefs");
                });

            modelBuilder.Entity("WorldForging.Models.BeliefEntity", b =>
                {
                    b.Property<int>("BeliefEntityId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BeliefId");

                    b.Property<int?>("EntityId");

                    b.HasKey("BeliefEntityId");

                    b.HasIndex("BeliefId");

                    b.HasIndex("EntityId");

                    b.ToTable("BeliefEntity");
                });

            modelBuilder.Entity("WorldForging.Models.BeliefSubject", b =>
                {
                    b.Property<int>("BeliefSubjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BeliefId");

                    b.Property<int?>("SubjectId");

                    b.HasKey("BeliefSubjectId");

                    b.HasIndex("BeliefId");

                    b.HasIndex("SubjectId");

                    b.ToTable("BeliefSubject");
                });

            modelBuilder.Entity("WorldForging.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EntityId");

                    b.HasKey("CharacterId");

                    b.HasIndex("EntityId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("WorldForging.Models.Convention", b =>
                {
                    b.Property<int>("ConventionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SubjectId");

                    b.HasKey("ConventionId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Conventions");
                });

            modelBuilder.Entity("WorldForging.Models.Culture", b =>
                {
                    b.Property<int>("CultureId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupId");

                    b.HasKey("CultureId");

                    b.HasIndex("GroupId");

                    b.ToTable("Cultures");
                });

            modelBuilder.Entity("WorldForging.Models.Desire", b =>
                {
                    b.Property<int>("DesireId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("SubjectId");

                    b.HasKey("DesireId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Desires");
                });

            modelBuilder.Entity("WorldForging.Models.DesireEntity", b =>
                {
                    b.Property<int>("DesireEntityId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DesireId");

                    b.Property<int?>("EntityId");

                    b.HasKey("DesireEntityId");

                    b.HasIndex("DesireId");

                    b.HasIndex("EntityId");

                    b.ToTable("DesireEntity");
                });

            modelBuilder.Entity("WorldForging.Models.DesireSubject", b =>
                {
                    b.Property<int>("DesireSubjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DesireId");

                    b.Property<int?>("SubjectId");

                    b.HasKey("DesireSubjectId");

                    b.HasIndex("DesireId");

                    b.HasIndex("SubjectId");

                    b.ToTable("DesireSubject");
                });

            modelBuilder.Entity("WorldForging.Models.Entity", b =>
                {
                    b.Property<int>("EntityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("WorldId");

                    b.HasKey("EntityId");

                    b.HasIndex("WorldId");

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("WorldForging.Models.EntityBelief", b =>
                {
                    b.Property<int>("EntityBeliefId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BeliefId");

                    b.Property<int>("EntityId");

                    b.HasKey("EntityBeliefId");

                    b.HasIndex("BeliefId");

                    b.HasIndex("EntityId");

                    b.ToTable("EntityBelief");
                });

            modelBuilder.Entity("WorldForging.Models.EntityConvention", b =>
                {
                    b.Property<int>("EntityConventionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConventionId");

                    b.Property<int>("EntityId");

                    b.HasKey("EntityConventionId");

                    b.HasIndex("ConventionId");

                    b.HasIndex("EntityId");

                    b.ToTable("EntityConvention");
                });

            modelBuilder.Entity("WorldForging.Models.EntityDesire", b =>
                {
                    b.Property<int>("EntityDesireId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DesireId");

                    b.Property<int>("EntityId");

                    b.HasKey("EntityDesireId");

                    b.HasIndex("DesireId");

                    b.HasIndex("EntityId");

                    b.ToTable("EntityDesire");
                });

            modelBuilder.Entity("WorldForging.Models.EntityDesireReason", b =>
                {
                    b.Property<int>("EntityDesireReasonId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EntityDesireId");

                    b.HasKey("EntityDesireReasonId");

                    b.HasIndex("EntityDesireId");

                    b.ToTable("EntityDesireReason");
                });

            modelBuilder.Entity("WorldForging.Models.EntityEntity", b =>
                {
                    b.Property<int>("EntityEntityId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Entity1Id");

                    b.Property<int?>("Entity2Id");

                    b.Property<int>("EntityRelationshipId");

                    b.HasKey("EntityEntityId");

                    b.HasIndex("Entity1Id");

                    b.HasIndex("Entity2Id");

                    b.HasIndex("EntityRelationshipId");

                    b.ToTable("EntityEntities");
                });

            modelBuilder.Entity("WorldForging.Models.EntityRelationship", b =>
                {
                    b.Property<int>("EntityRelationshipId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("WorldId");

                    b.HasKey("EntityRelationshipId");

                    b.HasIndex("WorldId");

                    b.ToTable("EntityRelationships");
                });

            modelBuilder.Entity("WorldForging.Models.EntityRelationshipReason", b =>
                {
                    b.Property<int>("EntityRelationshipReasonId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EntityRelationshipId");

                    b.HasKey("EntityRelationshipReasonId");

                    b.HasIndex("EntityRelationshipId");

                    b.ToTable("EntityRelationshipReason");
                });

            modelBuilder.Entity("WorldForging.Models.Faction", b =>
                {
                    b.Property<int>("FactionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DescriptionShort");

                    b.Property<int>("GroupId");

                    b.Property<string>("Name");

                    b.HasKey("FactionId");

                    b.HasIndex("GroupId");

                    b.ToTable("Factions");
                });

            modelBuilder.Entity("WorldForging.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EntityId");

                    b.HasKey("GroupId");

                    b.HasIndex("EntityId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("WorldForging.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EntityId");

                    b.HasKey("ItemId");

                    b.HasIndex("EntityId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("WorldForging.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DescriptionShort");

                    b.Property<int>("EntityId");

                    b.Property<string>("Name");

                    b.HasKey("LocationId");

                    b.HasIndex("EntityId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("WorldForging.Models.Race", b =>
                {
                    b.Property<int>("RaceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupId");

                    b.HasKey("RaceId");

                    b.HasIndex("GroupId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("WorldForging.Models.Reason", b =>
                {
                    b.Property<int>("ReasonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("SubjectId");

                    b.HasKey("ReasonId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Reasons");
                });

            modelBuilder.Entity("WorldForging.Models.ReasonEntity", b =>
                {
                    b.Property<int>("ReasonEntityId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EntityId");

                    b.Property<int>("ReasonId");

                    b.HasKey("ReasonEntityId");

                    b.HasIndex("EntityId");

                    b.HasIndex("ReasonId");

                    b.ToTable("ReasonEntity");
                });

            modelBuilder.Entity("WorldForging.Models.ReasonSubject", b =>
                {
                    b.Property<int>("ReasonSubjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ReasonId");

                    b.Property<int?>("SubjectId");

                    b.HasKey("ReasonSubjectId");

                    b.HasIndex("ReasonId");

                    b.HasIndex("SubjectId");

                    b.ToTable("ReasonSubject");
                });

            modelBuilder.Entity("WorldForging.Models.Religion", b =>
                {
                    b.Property<int>("ReligionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupId");

                    b.HasKey("ReligionId");

                    b.HasIndex("GroupId");

                    b.ToTable("Religions");
                });

            modelBuilder.Entity("WorldForging.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("WorldId");

                    b.HasKey("SubjectId");

                    b.HasIndex("WorldId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("WorldForging.Models.World", b =>
                {
                    b.Property<int>("WorldId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("UserId");

                    b.HasKey("WorldId");

                    b.ToTable("Worlds");
                });

            modelBuilder.Entity("WorldForging.Models.WorldEvent", b =>
                {
                    b.Property<int>("WorldEventId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EntityId");

                    b.HasKey("WorldEventId");

                    b.HasIndex("EntityId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("WorldForging.Models.Belief", b =>
                {
                    b.HasOne("WorldForging.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.BeliefEntity", b =>
                {
                    b.HasOne("WorldForging.Models.Belief", "Belief")
                        .WithMany("BeliefEntities")
                        .HasForeignKey("BeliefId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WorldForging.Models.Entity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId");
                });

            modelBuilder.Entity("WorldForging.Models.BeliefSubject", b =>
                {
                    b.HasOne("WorldForging.Models.Belief", "Belief")
                        .WithMany("BeliefSubjects")
                        .HasForeignKey("BeliefId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WorldForging.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("WorldForging.Models.Character", b =>
                {
                    b.HasOne("WorldForging.Models.Entity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.Convention", b =>
                {
                    b.HasOne("WorldForging.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.Culture", b =>
                {
                    b.HasOne("WorldForging.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.Desire", b =>
                {
                    b.HasOne("WorldForging.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.DesireEntity", b =>
                {
                    b.HasOne("WorldForging.Models.Desire", "Desire")
                        .WithMany("DesireEntities")
                        .HasForeignKey("DesireId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WorldForging.Models.Entity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId");
                });

            modelBuilder.Entity("WorldForging.Models.DesireSubject", b =>
                {
                    b.HasOne("WorldForging.Models.Desire", "Desire")
                        .WithMany("DesireSubjects")
                        .HasForeignKey("DesireId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WorldForging.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("WorldForging.Models.Entity", b =>
                {
                    b.HasOne("WorldForging.Models.World", "World")
                        .WithMany("Entities")
                        .HasForeignKey("WorldId");
                });

            modelBuilder.Entity("WorldForging.Models.EntityBelief", b =>
                {
                    b.HasOne("WorldForging.Models.Belief", "Belief")
                        .WithMany()
                        .HasForeignKey("BeliefId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WorldForging.Models.Entity", "Entity")
                        .WithMany("EntityBeliefs")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.EntityConvention", b =>
                {
                    b.HasOne("WorldForging.Models.Convention", "Convention")
                        .WithMany()
                        .HasForeignKey("ConventionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WorldForging.Models.Entity", "Entity")
                        .WithMany("EntityConventions")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.EntityDesire", b =>
                {
                    b.HasOne("WorldForging.Models.Desire", "Desire")
                        .WithMany("EntityDesires")
                        .HasForeignKey("DesireId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WorldForging.Models.Entity", "Entity")
                        .WithMany("EntityDesires")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.EntityDesireReason", b =>
                {
                    b.HasOne("WorldForging.Models.EntityDesire", "EntityDesire")
                        .WithMany("EntityDesireReasons")
                        .HasForeignKey("EntityDesireId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.EntityEntity", b =>
                {
                    b.HasOne("WorldForging.Models.Entity", "Entity1")
                        .WithMany()
                        .HasForeignKey("Entity1Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WorldForging.Models.Entity", "Entity2")
                        .WithMany()
                        .HasForeignKey("Entity2Id");

                    b.HasOne("WorldForging.Models.EntityRelationship", "EntityRelationship")
                        .WithMany("EntityEntities")
                        .HasForeignKey("EntityRelationshipId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.EntityRelationship", b =>
                {
                    b.HasOne("WorldForging.Models.World", "World")
                        .WithMany()
                        .HasForeignKey("WorldId");
                });

            modelBuilder.Entity("WorldForging.Models.EntityRelationshipReason", b =>
                {
                    b.HasOne("WorldForging.Models.EntityRelationship", "EntityRelationship")
                        .WithMany("EntityRelationshipReasons")
                        .HasForeignKey("EntityRelationshipId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.Faction", b =>
                {
                    b.HasOne("WorldForging.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.Group", b =>
                {
                    b.HasOne("WorldForging.Models.Entity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.Item", b =>
                {
                    b.HasOne("WorldForging.Models.Entity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.Location", b =>
                {
                    b.HasOne("WorldForging.Models.Entity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.Race", b =>
                {
                    b.HasOne("WorldForging.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.Reason", b =>
                {
                    b.HasOne("WorldForging.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.ReasonEntity", b =>
                {
                    b.HasOne("WorldForging.Models.Entity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId");

                    b.HasOne("WorldForging.Models.Reason", "Reason")
                        .WithMany("ReasonEntities")
                        .HasForeignKey("ReasonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.ReasonSubject", b =>
                {
                    b.HasOne("WorldForging.Models.Reason", "Reason")
                        .WithMany("ReasonSubjects")
                        .HasForeignKey("ReasonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WorldForging.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("WorldForging.Models.Religion", b =>
                {
                    b.HasOne("WorldForging.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.Subject", b =>
                {
                    b.HasOne("WorldForging.Models.World", "World")
                        .WithMany("Subjects")
                        .HasForeignKey("WorldId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.WorldEvent", b =>
                {
                    b.HasOne("WorldForging.Models.Entity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId");
                });
        }
    }
}
