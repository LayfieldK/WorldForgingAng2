﻿using CryptoHelper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using OpenIddict;
using System;
using System.Linq;
using System.Threading.Tasks;
using WorldForging.Models.Comments;
using WorldForging.Models.Users;
using WorldForgingApi.Models;
using WorldForging.Models;
using System.Collections.Generic;

public class DbSeeder
{
    #region Private Members
    private WorldForgingDBContext DbContext;
    private RoleManager<IdentityRole> RoleManager;
    private UserManager<ApplicationUser> UserManager;
    private IConfiguration Configuration;
    #endregion Private Members

    #region Constructor
    public DbSeeder(WorldForgingDBContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IConfiguration configuration)
    {
        DbContext = dbContext;
        RoleManager = roleManager;
        UserManager = userManager;
        Configuration = configuration;
    }
    #endregion Constructor

    #region Public Methods
    public async Task SeedAsync()
    {
        // Create the Db if it doesn’t exist
        DbContext.Database.EnsureCreated();
        // Create default Application
        if (!DbContext.Applications.Any()) CreateApplication();
        // Create default Users
        if (await DbContext.Users.CountAsync() == 0) await CreateUsersAsync();
        // Create default Items (if there are none) and Comments
        if (await DbContext.Entities.CountAsync() == 0) CreateEntities();

        if (await DbContext.Stories.CountAsync() == 0) CreateStories();
    }
    #endregion Public Methods

    #region Seed Methods
    private void CreateApplication()
    {
        DbContext.Applications.Add(new OpenIddictApplication
        {
            Id = Configuration["Authentication:OpenIddict:ApplicationId"],
            DisplayName = Configuration["Authentication:OpenIddict:DisplayName"],
            RedirectUri = Configuration["Authentication:OpenIddict:TokenEndPoint"],
            LogoutRedirectUri = "/",
            ClientId = Configuration["Authentication:OpenIddict:ClientId"],
            ClientSecret = Crypto.HashPassword(Configuration["Authentication:OpenIddict:ClientSecret"]),
            Type = OpenIddictConstants.ClientTypes.Public
        });
        DbContext.SaveChanges();
    }

    private async Task CreateUsersAsync()
    {
        // local variables
        DateTime createdDate = new DateTime(2016, 03, 01, 12, 30, 00);
        DateTime lastModifiedDate = DateTime.Now;
        string role_Administrators = "Administrators";
        string role_Registered = "Registered";

        //Create Roles (if they doesn't exist yet)
        if (!await RoleManager.RoleExistsAsync(role_Administrators)) await RoleManager.CreateAsync(new IdentityRole(role_Administrators));
        if (!await RoleManager.RoleExistsAsync(role_Registered)) await RoleManager.CreateAsync(new IdentityRole(role_Registered));

        // Create the "Admin" ApplicationUser account (if it doesn't exist already)
        var user_Admin = new ApplicationUser()
        {
            UserName = "Admin",
            Email = "admin@worldforging.com",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate
        };

        // Insert "Admin" into the Database and also assign the "Administrator" role to him.
        if (await UserManager.FindByIdAsync(user_Admin.Id) == null)
        {
            await UserManager.CreateAsync(user_Admin, "password");
            await UserManager.AddToRoleAsync(user_Admin, role_Administrators);
            // Remove Lockout and E-Mail confirmation.
            user_Admin.EmailConfirmed = true;
            user_Admin.LockoutEnabled = false;
        }

#if DEBUG
        // Create some sample registered user accounts (if they don't exist already)
        var user1 = new ApplicationUser()
        {
            UserName = "User1",
            Email = "User1@worldforging.com",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate,
            EmailConfirmed = true,
            LockoutEnabled = false
        };
        var user2 = new ApplicationUser()
        {
            UserName = "User2",
            Email = "User2@worldforging.com",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate,
            EmailConfirmed = true,
            LockoutEnabled = false
        };
        var user3 = new ApplicationUser()
        {
            UserName = "User3",
            Email = "User3@worldforging.com",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate,
            EmailConfirmed = true,
            LockoutEnabled = false
        };

        // Insert sample registered users into the Database and also assign the "Registered" role to him.
        if (await UserManager.FindByIdAsync(user1.Id) == null)
        {
            await UserManager.CreateAsync(user1, "password");
            await UserManager.AddToRoleAsync(user1, role_Registered);
            // Remove Lockout and E-Mail confirmation.
            user1.EmailConfirmed = true;
            user1.LockoutEnabled = false;
        }
        if (await UserManager.FindByIdAsync(user2.Id) == null)
        {
            await UserManager.CreateAsync(user2, "password");
            await UserManager.AddToRoleAsync(user2, role_Registered);
            // Remove Lockout and E-Mail confirmation.
            user2.EmailConfirmed = true;
            user2.LockoutEnabled = false;
        }
        if (await UserManager.FindByIdAsync(user3.Id) == null)
        {
            await UserManager.CreateAsync(user3, "password");
            await UserManager.AddToRoleAsync(user3, role_Registered);
            // Remove Lockout and E-Mail confirmation.
            user3.EmailConfirmed = true;
            user3.LockoutEnabled = false;
        }
#endif
        await DbContext.SaveChangesAsync();
    }

    private void CreateEntities()
    {
        // local variables
        DateTime createdDate = new DateTime(2016, 03, 01, 12, 30, 00);
        DateTime lastModifiedDate = DateTime.Now;

        var authorId = DbContext.Users.Where(u => u.UserName == "Admin").FirstOrDefault().Id;

        //add entity types
        EntityEntry<EntityType> type1 = DbContext.EntityTypes.Add(new EntityType()
        {
            UserId = authorId,
            Name = "Location",
            QueryCode = "location",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate
        });

        EntityEntry<EntityType> type2 = DbContext.EntityTypes.Add(new EntityType()
        {
            UserId = authorId,
            Name = "Character",
            QueryCode = "character",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate
        });

        EntityEntry<EntityType> type3 = DbContext.EntityTypes.Add(new EntityType()
        {
            UserId = authorId,
            Name = "Group",
            QueryCode = "group",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate
        });

        EntityEntry<EntityType> type4 = DbContext.EntityTypes.Add(new EntityType()
        {
            UserId = authorId,
            Name = "Item",
            QueryCode = "item",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate
        });

        //add relationships
        EntityEntry<Relationship> rel1 = DbContext.Relationships.Add(new Relationship()
        {
            UserId = authorId,
            Title = "Relationship 1",
            Description = "Relationship 1",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate
        });

        EntityEntry<Relationship> rel2 = DbContext.Relationships.Add(new Relationship()
        {
            UserId = authorId,
            Title = "Relationship 2",
            Description = "Relationship 2",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate,
            InverseRelationship = rel1.Entity
        });

        EntityEntry<Relationship> rel3 = DbContext.Relationships.Add(new Relationship()
        {
            UserId = authorId,
            Title = "Relationship 3",
            Description = "Relationship 3",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate
        });

        EntityEntry<Relationship> rel4 = DbContext.Relationships.Add(new Relationship()
        {
            UserId = authorId,
            Title = "Relationship 4",
            Description = "Relationship 4",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate,
            InverseRelationship = rel3.Entity
        });

        DbContext.SaveChanges();

        rel1.Entity.InverseRelationship = rel2.Entity;
        rel3.Entity.InverseRelationship = rel4.Entity;

        DbContext.SaveChanges();

        //add entities
        EntityEntry<Entity> ent1 = DbContext.Entities.Add(new Entity()
        {
            UserId = authorId,
            Name = "Earth",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate,
            EntityType = type1.Entity
            //EntityTypes = new List<EntityType>() { type1.Entity}
        });

        EntityEntry<Entity> ent2 = DbContext.Entities.Add(new Entity()
        {
            UserId = authorId,
            Name = "Faction 1",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate,
            EntityType = type3.Entity
            //EntityTypes = new List<EntityType>() { type3.Entity }
        });

        EntityEntry<Entity> ent3 = DbContext.Entities.Add(new Entity()
        {
            UserId = authorId,
            Name = "Character 1",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate,
            EntityType = type2.Entity
            //EntityTypes = new List<EntityType>() { type2.Entity }
        });

        EntityEntry<Entity> ent4 = DbContext.Entities.Add(new Entity()
        {
            UserId = authorId,
            Name = "Ship 1",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate,
            EntityType = type4.Entity
            //EntityTypes = new List<EntityType>() { type4.Entity }
        });

        EntityEntry<Entity> ent5 = DbContext.Entities.Add(new Entity()
        {
            UserId = authorId,
            Name = "Species 2",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate,
            EntityType = type3.Entity
            //EntityTypes = new List<EntityType>() { type3.Entity }
        });

        //add EntityRelationships
        EntityEntry<EntityRelationship> er1 = DbContext.EntityRelationships.Add(new EntityRelationship()
        {
            UserId = authorId,
            Description = "Entity Relationship 1",
            Entity1 = ent1.Entity,
            Entity2 = ent2.Entity,
            Relationship = rel1.Entity,
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate
        });

        EntityEntry<EntityRelationship> er2 = DbContext.EntityRelationships.Add(new EntityRelationship()
        {
            UserId = authorId,
            Description = "Entity Relationship 2",
            Entity1 = ent2.Entity,
            Entity2 = ent1.Entity,
            Relationship = rel2.Entity,
            InverseEntityRelationship = er1.Entity,
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate
        });

        DbContext.SaveChanges();

        er1.Entity.InverseEntityRelationship = er2.Entity;

        DbContext.SaveChanges();

#if DEBUG
        var num = 1000;  // create 1000 sample articles
        for (int id = 1; id <= num; id++)
        {
            DbContext.Articles.Add(GetSampleArticle(id, authorId, num - id, new DateTime(2015, 12, 31).AddDays(-num)));
        }
#endif
        //create articles for existing entities
        EntityEntry<Article> e1 = DbContext.Articles.Add(new Article()
        {
            UserId = authorId,
            Title = "Earth",
            Description = "Humanity's home planet.",
            Text = @"Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  ",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate,
            Entity=ent1.Entity
        });

        EntityEntry<Article> e2 = DbContext.Articles.Add(new Article()
        {
            UserId = authorId,
            Title = "Faction 1",
            Description = "One of the factions in the story.",
            Text = @"Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  ",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate,
            Entity = ent2.Entity
        });

        EntityEntry<Article> e3 = DbContext.Articles.Add(new Article()
        {
            UserId = authorId,
            Title = "Character 1",
            Description = "A character who serves on Ship 1 and is a part of Faction 1.",
            Text = @"Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  ",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate,
            Entity = ent3.Entity
        });

        EntityEntry<Article> e4 = DbContext.Articles.Add(new Article()
        {
            UserId = authorId,
            Title = "Ship 1",
            Description = "The flagship of Faction 1.",
            Text = @"Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  ",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate,
            Entity = ent4.Entity
        });

        EntityEntry<Article> e5 = DbContext.Articles.Add(new Article()
        {
            UserId = authorId,
            Title = "Species 2",
            Description = "A primitive race discovered by Faction 1.",
            Text = @"Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  ",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate,
            Entity = ent5.Entity
        });

        // Create default Comments (if there are none)
        if (DbContext.Comments.Count() == 0)
        {
            int numComments = 10;   // comments per item
            for (int i = 1; i <= numComments; i++) DbContext.Comments.Add(GetSampleComment(i, e1.Entity.Id, authorId, createdDate.AddDays(i)));
            for (int i = 1; i <= numComments; i++) DbContext.Comments.Add(GetSampleComment(i, e2.Entity.Id, authorId, createdDate.AddDays(i)));
            for (int i = 1; i <= numComments; i++) DbContext.Comments.Add(GetSampleComment(i, e3.Entity.Id, authorId, createdDate.AddDays(i)));
            for (int i = 1; i <= numComments; i++) DbContext.Comments.Add(GetSampleComment(i, e4.Entity.Id, authorId, createdDate.AddDays(i)));
            for (int i = 1; i <= numComments; i++) DbContext.Comments.Add(GetSampleComment(i, e5.Entity.Id, authorId, createdDate.AddDays(i)));
        }
        DbContext.SaveChanges();
    }
    private void CreateStories()
    {
        // local variables
        DateTime createdDate = new DateTime(2016, 03, 01, 12, 30, 00);
        DateTime lastModifiedDate = DateTime.Now;

        var authorId = DbContext.Users.Where(u => u.UserName == "Admin").FirstOrDefault().Id;

#if DEBUG
        var num = 1000;  // create 1000 sample items
        for (int id = 1; id <= num; id++)
        {
            DbContext.Stories.Add(GetSampleStory(id, authorId, num - id, new DateTime(2015, 12, 31).AddDays(-num)));
        }
#endif

        EntityEntry<Story> e1 = DbContext.Stories.Add(new Story()
        {
            UserId = authorId,
            Title = "Earth",
            Description = "Humanity's home planet.",
            Text = @"Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  ",
            Genre = "Science Fiction",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate
        });

        EntityEntry<Story> e2 = DbContext.Stories.Add(new Story()
        {
            UserId = authorId,
            Title = "Faction 1",
            Description = "One of the factions in the story.",
            Text = @"Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  ",
            Genre = "Fantasy",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate
        });

        EntityEntry<Story> e3 = DbContext.Stories.Add(new Story()
        {
            UserId = authorId,
            Title = "Character 1",
            Description = "A character who serves on Ship 1 and is a part of Faction 1.",
            Text = @"Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  ",
            Genre = "Science Fiction",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate
        });

        EntityEntry<Story> e4 = DbContext.Stories.Add(new Story()
        {
            UserId = authorId,
            Title = "Ship 1",
            Description = "The flagship of Faction 1.",
            Text = @"Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  ",
            Genre = "Fantasy",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate
        });

        EntityEntry<Story> e5 = DbContext.Stories.Add(new Story()
        {
            UserId = authorId,
            Title = "Species 2",
            Description = "A primitive race discovered by Faction 1.",
            Text = @"Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  Test text.  ",
            Genre = "Science Fiction",
            CreatedDate = createdDate,
            LastModifiedDate = lastModifiedDate
        });

        // Create default Comments (if there are none)
        if (DbContext.Comments.Count() == 0)
        {
            int numComments = 10;   // comments per item
            for (int i = 1; i <= numComments; i++) DbContext.Comments.Add(GetSampleComment(i, e1.Entity.Id, authorId, createdDate.AddDays(i)));
            for (int i = 1; i <= numComments; i++) DbContext.Comments.Add(GetSampleComment(i, e2.Entity.Id, authorId, createdDate.AddDays(i)));
            for (int i = 1; i <= numComments; i++) DbContext.Comments.Add(GetSampleComment(i, e3.Entity.Id, authorId, createdDate.AddDays(i)));
            for (int i = 1; i <= numComments; i++) DbContext.Comments.Add(GetSampleComment(i, e4.Entity.Id, authorId, createdDate.AddDays(i)));
            for (int i = 1; i <= numComments; i++) DbContext.Comments.Add(GetSampleComment(i, e5.Entity.Id, authorId, createdDate.AddDays(i)));
        }
        DbContext.SaveChanges();
    }
    #endregion Seed Methods

    #region Utility Methods
    /// <summary>
    /// Generate a sample item to populate the DB.
    /// </summary>
    /// <param name="userId">the author ID</param>
    /// <param name="id">the item ID</param>
    /// <param name="createdDate">the item CreatedDate</param>
    /// <returns></returns>
    private Article GetSampleArticle(int id, string authorId, int viewCount, DateTime createdDate)
    {
        return new Article()
        {
            UserId = authorId,
            Title = String.Format("Item {0} Title", id),
            Description = String.Format("This is a sample description for item {0}: Lorem ipsum dolor sit amet.", id),
            Notes = "This is a sample record created by the Code-First Configuration class",
            ViewCount = viewCount,
            CreatedDate = createdDate,
            LastModifiedDate = createdDate
        };
    }

    /// <summary>
    /// Generate a sample story to populate the DB.
    /// </summary>
    /// <param name="userId">the author ID</param>
    /// <param name="id">the item ID</param>
    /// <param name="createdDate">the item CreatedDate</param>
    /// <returns></returns>
    private Story GetSampleStory(int id, string authorId, int viewCount, DateTime createdDate)
    {
        return new Story()
        {
            UserId = authorId,
            Title = String.Format("Item {0} Title", id),
            Description = String.Format("This is a sample description for item {0}: Lorem ipsum dolor sit amet.", id),
            Genre = "Science Fiction",
            Notes = "This is a sample record created by the Code-First Configuration class",
            ViewCount = viewCount,
            CreatedDate = createdDate,
            LastModifiedDate = createdDate
        };
    }

    /// <summary>
    /// Generate a sample array of Comments (for testing purposes only).
    /// </summary>
    /// <param name="n"></param>
    /// <param name="item"></param>
    /// <param name="authorID"></param>
    /// <returns></returns>
    private Comment GetSampleComment(int n, int itemId, string authorId, DateTime createdDate)
    {
        return new Comment()
        {
            ItemId = itemId,
            UserId = authorId,
            ParentId = null,
            Text = String.Format("Sample comment #{0} for the item #{1}", n, itemId),
            CreatedDate = createdDate,
            LastModifiedDate = createdDate
        };
    }
    #endregion Utility Methods
}
