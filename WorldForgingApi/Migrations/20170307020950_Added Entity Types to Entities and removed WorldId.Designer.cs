using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WorldForgingApi.Models;

namespace WorldForgingApi.Migrations
{
    [DbContext(typeof(WorldForgingDBContext))]
    [Migration("20170307020950_Added Entity Types to Entities and removed WorldId")]
    partial class AddedEntityTypestoEntitiesandremovedWorldId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OpenIddict.OpenIddictApplication", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ClientId");

                    b.Property<string>("ClientSecret");

                    b.Property<string>("DisplayName");

                    b.Property<string>("LogoutRedirectUri");

                    b.Property<string>("RedirectUri");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("OpenIddictApplications");
                });

            modelBuilder.Entity("OpenIddict.OpenIddictAuthorization", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Scope");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("OpenIddictAuthorizations");
                });

            modelBuilder.Entity("OpenIddict.OpenIddictScope", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("OpenIddictScopes");
                });

            modelBuilder.Entity("OpenIddict.OpenIddictToken", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ApplicationId");

                    b.Property<string>("AuthorizationId");

                    b.Property<string>("Type");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("AuthorizationId");

                    b.HasIndex("UserId");

                    b.ToTable("OpenIddictTokens");
                });

            modelBuilder.Entity("WorldForging.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<int?>("EntityId");

                    b.Property<int>("Flags");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("Notes");

                    b.Property<string>("Text");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<int>("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.HasIndex("UserId");

                    b.ToTable("Articles");
                });

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

            modelBuilder.Entity("WorldForging.Models.Comments.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("Flags");

                    b.Property<int>("ItemId");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<int?>("ParentId");

                    b.Property<int?>("StoryId");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("ParentId");

                    b.HasIndex("StoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("EntityTypeId");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<int?>("WorldId");

                    b.HasKey("Id");

                    b.HasIndex("EntityTypeId");

                    b.HasIndex("UserId");

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

            modelBuilder.Entity("WorldForging.Models.EntityRelationship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<int?>("Entity1Id");

                    b.Property<int?>("Entity2Id");

                    b.Property<int?>("InverseEntityRelationshipId");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<int?>("RelationshipId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Entity1Id");

                    b.HasIndex("Entity2Id");

                    b.HasIndex("InverseEntityRelationshipId");

                    b.HasIndex("RelationshipId");

                    b.HasIndex("UserId");

                    b.ToTable("EntityRelationships");
                });

            modelBuilder.Entity("WorldForging.Models.EntityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("QueryCode")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EntityTypes");
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

            modelBuilder.Entity("WorldForging.Models.Relationship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int?>("InverseRelationshipId");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("InverseRelationshipId");

                    b.HasIndex("UserId");

                    b.ToTable("Relationships");
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

            modelBuilder.Entity("WorldForging.Models.Story", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<int?>("EntityId");

                    b.Property<int>("Flags");

                    b.Property<string>("Genre");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("Notes");

                    b.Property<string>("Text");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<int>("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.HasIndex("UserId");

                    b.ToTable("Stories");
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

            modelBuilder.Entity("WorldForging.Models.Users.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DisplayName");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int>("Flags");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Notes");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<int>("Type");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("Users");
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WorldForging.Models.Users.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WorldForging.Models.Users.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WorldForging.Models.Users.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpenIddict.OpenIddictAuthorization", b =>
                {
                    b.HasOne("WorldForging.Models.Users.ApplicationUser")
                        .WithMany("Authorizations")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("OpenIddict.OpenIddictToken", b =>
                {
                    b.HasOne("OpenIddict.OpenIddictApplication")
                        .WithMany("Tokens")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("OpenIddict.OpenIddictAuthorization")
                        .WithMany("Tokens")
                        .HasForeignKey("AuthorizationId");

                    b.HasOne("WorldForging.Models.Users.ApplicationUser")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WorldForging.Models.Article", b =>
                {
                    b.HasOne("WorldForging.Models.Entity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId");

                    b.HasOne("WorldForging.Models.Users.ApplicationUser", "Author")
                        .WithMany("Articles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
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

            modelBuilder.Entity("WorldForging.Models.Comments.Comment", b =>
                {
                    b.HasOne("WorldForging.Models.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WorldForging.Models.Comments.Comment", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.HasOne("WorldForging.Models.Story")
                        .WithMany("Comments")
                        .HasForeignKey("StoryId");

                    b.HasOne("WorldForging.Models.Users.ApplicationUser", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");
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
                    b.HasOne("WorldForging.Models.EntityType", "EntityType")
                        .WithMany()
                        .HasForeignKey("EntityTypeId");

                    b.HasOne("WorldForging.Models.Users.ApplicationUser", "Author")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WorldForging.Models.World")
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

            modelBuilder.Entity("WorldForging.Models.EntityRelationship", b =>
                {
                    b.HasOne("WorldForging.Models.Entity", "Entity1")
                        .WithMany()
                        .HasForeignKey("Entity1Id");

                    b.HasOne("WorldForging.Models.Entity", "Entity2")
                        .WithMany()
                        .HasForeignKey("Entity2Id");

                    b.HasOne("WorldForging.Models.EntityRelationship", "InverseEntityRelationship")
                        .WithMany()
                        .HasForeignKey("InverseEntityRelationshipId");

                    b.HasOne("WorldForging.Models.Relationship", "Relationship")
                        .WithMany()
                        .HasForeignKey("RelationshipId");

                    b.HasOne("WorldForging.Models.Users.ApplicationUser", "Author")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.EntityType", b =>
                {
                    b.HasOne("WorldForging.Models.Users.ApplicationUser", "Author")
                        .WithMany()
                        .HasForeignKey("UserId")
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

            modelBuilder.Entity("WorldForging.Models.Relationship", b =>
                {
                    b.HasOne("WorldForging.Models.Relationship", "InverseRelationship")
                        .WithMany()
                        .HasForeignKey("InverseRelationshipId");

                    b.HasOne("WorldForging.Models.Users.ApplicationUser", "Author")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.Religion", b =>
                {
                    b.HasOne("WorldForging.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldForging.Models.Story", b =>
                {
                    b.HasOne("WorldForging.Models.Entity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId");

                    b.HasOne("WorldForging.Models.Users.ApplicationUser", "Author")
                        .WithMany()
                        .HasForeignKey("UserId")
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
