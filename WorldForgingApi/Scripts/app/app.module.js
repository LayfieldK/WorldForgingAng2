System.register(["@angular/core", "@angular/platform-browser", "@angular/http", "@angular/forms", "@angular/router", "rxjs/Rx", "./about.component", "./app.component", "./home.component", "./article-detail-view.component", "./article-detail-edit.component", "./entity-relationship-edit.component", "./article-list.component", "./story-detail-view.component", "./story-detail-edit.component", "./story-list.component", "./login.component", "./page-not-found.component", "./user-edit.component", "./search.component", "./dummy.component", "./app.routing", "./auth.http", "./auth.service", "./article.service", "./story.service", "./relationship.service", "./entity.service"], function (exports_1, context_1) {
    "use strict";
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __moduleName = context_1 && context_1.id;
    var core_1, platform_browser_1, http_1, forms_1, router_1, about_component_1, app_component_1, home_component_1, article_detail_view_component_1, article_detail_edit_component_1, entity_relationship_edit_component_1, article_list_component_1, story_detail_view_component_1, story_detail_edit_component_1, story_list_component_1, login_component_1, page_not_found_component_1, user_edit_component_1, search_component_1, dummy_component_1, app_routing_1, auth_http_1, auth_service_1, article_service_1, story_service_1, relationship_service_1, entity_service_1, AppModule;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (platform_browser_1_1) {
                platform_browser_1 = platform_browser_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (forms_1_1) {
                forms_1 = forms_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (_1) {
            },
            function (about_component_1_1) {
                about_component_1 = about_component_1_1;
            },
            function (app_component_1_1) {
                app_component_1 = app_component_1_1;
            },
            function (home_component_1_1) {
                home_component_1 = home_component_1_1;
            },
            function (article_detail_view_component_1_1) {
                article_detail_view_component_1 = article_detail_view_component_1_1;
            },
            function (article_detail_edit_component_1_1) {
                article_detail_edit_component_1 = article_detail_edit_component_1_1;
            },
            function (entity_relationship_edit_component_1_1) {
                entity_relationship_edit_component_1 = entity_relationship_edit_component_1_1;
            },
            function (article_list_component_1_1) {
                article_list_component_1 = article_list_component_1_1;
            },
            function (story_detail_view_component_1_1) {
                story_detail_view_component_1 = story_detail_view_component_1_1;
            },
            function (story_detail_edit_component_1_1) {
                story_detail_edit_component_1 = story_detail_edit_component_1_1;
            },
            function (story_list_component_1_1) {
                story_list_component_1 = story_list_component_1_1;
            },
            function (login_component_1_1) {
                login_component_1 = login_component_1_1;
            },
            function (page_not_found_component_1_1) {
                page_not_found_component_1 = page_not_found_component_1_1;
            },
            function (user_edit_component_1_1) {
                user_edit_component_1 = user_edit_component_1_1;
            },
            function (search_component_1_1) {
                search_component_1 = search_component_1_1;
            },
            function (dummy_component_1_1) {
                dummy_component_1 = dummy_component_1_1;
            },
            function (app_routing_1_1) {
                app_routing_1 = app_routing_1_1;
            },
            function (auth_http_1_1) {
                auth_http_1 = auth_http_1_1;
            },
            function (auth_service_1_1) {
                auth_service_1 = auth_service_1_1;
            },
            function (article_service_1_1) {
                article_service_1 = article_service_1_1;
            },
            function (story_service_1_1) {
                story_service_1 = story_service_1_1;
            },
            function (relationship_service_1_1) {
                relationship_service_1 = relationship_service_1_1;
            },
            function (entity_service_1_1) {
                entity_service_1 = entity_service_1_1;
            }
        ],
        execute: function () {
            AppModule = (function () {
                function AppModule() {
                }
                return AppModule;
            }());
            AppModule = __decorate([
                core_1.NgModule({
                    // directives, components, and pipes
                    declarations: [
                        about_component_1.AboutComponent,
                        app_component_1.AppComponent,
                        home_component_1.HomeComponent,
                        article_list_component_1.ArticleListComponent,
                        article_detail_view_component_1.ArticleDetailViewComponent,
                        article_detail_edit_component_1.ArticleDetailEditComponent,
                        entity_relationship_edit_component_1.EntityRelationshipEditComponent,
                        story_list_component_1.StoryListComponent,
                        story_detail_view_component_1.StoryDetailViewComponent,
                        story_detail_edit_component_1.StoryDetailEditComponent,
                        login_component_1.LoginComponent,
                        page_not_found_component_1.PageNotFoundComponent,
                        user_edit_component_1.UserEditComponent,
                        search_component_1.SearchComponent,
                        dummy_component_1.DummyComponent
                    ],
                    // modules
                    imports: [
                        platform_browser_1.BrowserModule,
                        http_1.HttpModule,
                        forms_1.FormsModule,
                        forms_1.ReactiveFormsModule,
                        router_1.RouterModule,
                        app_routing_1.AppRouting
                    ],
                    // providers
                    providers: [
                        auth_http_1.AuthHttp,
                        article_service_1.ArticleService,
                        story_service_1.StoryService,
                        relationship_service_1.RelationshipService,
                        entity_service_1.EntityService,
                        auth_service_1.AuthService
                    ],
                    bootstrap: [
                        app_component_1.AppComponent
                    ]
                })
            ], AppModule);
            exports_1("AppModule", AppModule);
        }
    };
});
