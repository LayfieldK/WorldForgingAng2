using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WorldForgingApi.Models;
using Microsoft.EntityFrameworkCore;
using WorldForging.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WorldForging.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WorldForging.Classes;
using Microsoft.IdentityModel.Tokens;
using WorldForging.Models;

namespace WorldForgingApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                //builder.AddApplicationInsightsSettings(developerMode: true);

                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();

            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add a reference to the Configuration object for DI
            services.AddSingleton<IConfiguration>(
                c => { return Configuration; }
                );


            // Add framework services.
            //services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            // Add EntityFramework's Identity support.
            services.AddEntityFramework();

            // Add Identity Services & Stores
            services.AddIdentity<ApplicationUser, IdentityRole>(config => {
                config.User.RequireUniqueEmail = true;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireDigit = false;
                config.Cookies.ApplicationCookie.AutomaticChallenge = false;
            })
                .AddEntityFrameworkStores<WorldForgingDBContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<WorldForgingDBContext>(options => options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            // Register the OpenIddict services, including the default Entity Framework stores.
            services.AddOpenIddict<ApplicationUser, WorldForgingDBContext>()
                // Integrate with EFCore
                .AddEntityFramework<WorldForgingDBContext>()
                // Use Json Web Tokens (JWT)
                .UseJsonWebTokens()
                // Set a custom token endpoint (default is /connect/token)
                .EnableTokenEndpoint(Configuration["Authentication:OpenIddict:TokenEndPoint"])
                // Set a custom auth endpoint (default is /connect/authorize)
                .EnableAuthorizationEndpoint(Configuration["Authentication:OpenIddict:AuthorizationEndPoint"])
                // Allow client applications to use the grant_type=password flow.
                .AllowPasswordFlow()
                // Enable support for both authorization & implicit flows
                .AllowAuthorizationCodeFlow()
                .AllowImplicitFlow()
                // Allow the client to refresh tokens.
                .AllowRefreshTokenFlow()
                // Disable the HTTPS requirement (not recommended in production)
                .DisableHttpsRequirement()
                // Register a new ephemeral key for development.
                // We will register a X.509 certificate in production.
                .AddEphemeralSigningKey();

            // Add ApplicationDbContext's DbSeeder
            services.AddSingleton<DbSeeder>();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

                        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, DbSeeder dbSeeder)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //app.UseApplicationInsightsRequestTelemetry();

            //app.UseApplicationInsightsExceptionTelemetry();

            // Configure a rewrite rule to auto-lookup for standard default files such as index.html. 
            app.UseDefaultFiles();

            // Serve static files (html, css, js, images & more). See also the following URL:
            // https://docs.asp.net/en/latest/fundamentals/static-files.html for further reference.
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = (context) =>
                {
                    // Disable caching for all static files.
                    context.Context.Response.Headers["Cache-Control"] = Configuration["StaticFiles:Headers:Cache-Control"];
                    context.Context.Response.Headers["Pragma"] = Configuration["StaticFiles:Headers:Pragma"];
                    context.Context.Response.Headers["Expires"] = Configuration["StaticFiles:Headers:Expires"];
                }
            });

            //// Add a custom Jwt Provider to generate Tokens
            //app.UseJwtProvider();

            // Add the AspNetCore.Identity middleware (required for external auth providers)
            // IMPORTANT: This must be placed *BEFORE* OpenIddict and any external provider's middleware
            app.UseIdentity();

            // Add external authentication middleware below. 
            // To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715
            app.UseFacebookAuthentication(new FacebookOptions()
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                AppId = Configuration["FacebookAppId"],
                AppSecret = Configuration["FacebookAppSecret"],
                CallbackPath = "/signin-facebook",
                Scope = { "email" }
            });

            app.UseGoogleAuthentication(new GoogleOptions()
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                ClientId = Configuration["GoogleClientId"],
                ClientSecret = Configuration["GoogleClientSecret"],
                CallbackPath = "/signin-google",
                Scope = { "email" }
            });

            app.UseTwitterAuthentication(new TwitterOptions()
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                ConsumerKey = Configuration["TwitterConsumerKey"],
                ConsumerSecret = Configuration["TwitterConsumerSecret"],
                CallbackPath = "/signin-twitter"
            });

            // Add OpenIddict middleware
            // Note: UseOpenIddict() must be registered after app.UseIdentity() and the external social providers.
            app.UseOpenIddict();

            // Add the Jwt Bearer Header Authentication to validate Tokens
            app.UseJwtBearerAuthentication(new JwtBearerOptions()
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                RequireHttpsMetadata = false,
                Authority = Configuration["Authentication:OpenIddict:Authority"],
                TokenValidationParameters = new TokenValidationParameters()
                {
                    //IssuerSigningKey = JwtProvider.SecurityKey,
                    //ValidateIssuerSigningKey = true,
                    //ValidIssuer = JwtProvider.Issuer,
                    ValidateIssuer = false,
                    ValidateAudience = false
                }
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            // Seed the Database (if needed)
            try
            {
                dbSeeder.SeedAsync().Wait();
            }
            catch (AggregateException e)
            {
                throw new Exception(e.ToString());
            }

            Mapper.Initialize(cfg =>
            {
                var articleClientModelMap = cfg.CreateMap<Article, ArticleViewModel>()
                    .ForMember(dest=>dest.EntityRelationships, source => source.MapFrom(x => x.Entity.EntityRelationships))
                    //.ForMember(dest => dest.EntityRelationships., opt => opt.Ignore())
                //ForMember(dest => dest.Id, source => source.MapFrom(x => x.ClientId))
                .ReverseMap();

                cfg.CreateMap<EntityRelationship, EntityRelationshipDTO>()
                    .ForMember(dest => dest.Entity1Name, source => source.MapFrom(x => x.Entity1.Name))
                    .ForMember(dest => dest.Entity2Name, source => source.MapFrom(x => x.Entity2.Name))
                    .ForMember(dest => dest.RelationshipDescription, source => source.MapFrom(x => x.Relationship.Description))
                    .ForMember(dest => dest.RelationshipId, source => source.MapFrom(x => x.Relationship.Id));
                //cfg.CreateMap<FlatEntity, Entity>().ReverseMap();

                cfg.CreateMap<Relationship, RelationshipDTO>();

                cfg.CreateMap<Story, StoryViewModel>().ReverseMap();
                
            });
            
            //ItemViewModel ivm = Mapper.Map<ItemViewModel>(Article);
            //AutoMapper.Bind<Article, ItemViewModel>();
        }
    }
}
