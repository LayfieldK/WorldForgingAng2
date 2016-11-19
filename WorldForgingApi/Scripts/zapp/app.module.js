System.register(['@angular/core', '@angular/platform-browser', '@angular/http', './app.component', './dashboard/dashboard.component', './personalCabinet/personalCabinet.component', './worlds/index/worlds.component', './worlds/details/worlddetails.component', './articles/index/articles.component', './articles/details/articleDetails.component', './stories/index/stories.component', './stories/details/storyDetails.component', './app.routing'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, platform_browser_1, http_1, app_component_1, dashboard_component_1, personalCabinet_component_1, worlds_component_1, worlddetails_component_1, articles_component_1, articleDetails_component_1, stories_component_1, storyDetails_component_1, app_routing_1;
    var AppModule;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (platform_browser_1_1) {
                platform_browser_1 = platform_browser_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (app_component_1_1) {
                app_component_1 = app_component_1_1;
            },
            function (dashboard_component_1_1) {
                dashboard_component_1 = dashboard_component_1_1;
            },
            function (personalCabinet_component_1_1) {
                personalCabinet_component_1 = personalCabinet_component_1_1;
            },
            function (worlds_component_1_1) {
                worlds_component_1 = worlds_component_1_1;
            },
            function (worlddetails_component_1_1) {
                worlddetails_component_1 = worlddetails_component_1_1;
            },
            function (articles_component_1_1) {
                articles_component_1 = articles_component_1_1;
            },
            function (articleDetails_component_1_1) {
                articleDetails_component_1 = articleDetails_component_1_1;
            },
            function (stories_component_1_1) {
                stories_component_1 = stories_component_1_1;
            },
            function (storyDetails_component_1_1) {
                storyDetails_component_1 = storyDetails_component_1_1;
            },
            function (app_routing_1_1) {
                app_routing_1 = app_routing_1_1;
            }],
        execute: function() {
            AppModule = (function () {
                function AppModule() {
                }
                AppModule = __decorate([
                    core_1.NgModule({
                        imports: [platform_browser_1.BrowserModule, app_routing_1.routing, http_1.HttpModule, http_1.JsonpModule],
                        declarations: [app_component_1.AppComponent, dashboard_component_1.Dashboard, personalCabinet_component_1.PersonalCabinet, worlds_component_1.Worlds, worlddetails_component_1.WorldDetails, articles_component_1.Articles, articleDetails_component_1.ArticleDetails, stories_component_1.Stories, storyDetails_component_1.StoryDetails],
                        bootstrap: [app_component_1.AppComponent]
                    }), 
                    __metadata('design:paramtypes', [])
                ], AppModule);
                return AppModule;
            }());
            exports_1("AppModule", AppModule);
        }
    }
});
