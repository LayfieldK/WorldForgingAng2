"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
const core_1 = require('@angular/core');
const platform_browser_1 = require('@angular/platform-browser');
const http_1 = require('@angular/http');
const app_component_1 = require('./app.component');
const dashboard_component_1 = require('./dashboard/dashboard.component');
const personalCabinet_component_1 = require('./personalCabinet/personalCabinet.component');
const worlds_component_1 = require('./worlds/index/worlds.component');
const worlddetails_component_1 = require('./worlds/details/worlddetails.component');
const articles_component_1 = require('./articles/index/articles.component');
const articleDetails_component_1 = require('./articles/details/articleDetails.component');
const stories_component_1 = require('./stories/index/stories.component');
const storyDetails_component_1 = require('./stories/details/storyDetails.component');
const app_routing_1 = require('./app.routing');
let AppModule = class AppModule {
};
AppModule = __decorate([
    core_1.NgModule({
        imports: [platform_browser_1.BrowserModule, app_routing_1.routing, http_1.HttpModule, http_1.JsonpModule],
        declarations: [app_component_1.AppComponent, dashboard_component_1.Dashboard, personalCabinet_component_1.PersonalCabinet, worlds_component_1.Worlds, worlddetails_component_1.WorldDetails, articles_component_1.Articles, articleDetails_component_1.ArticleDetails, stories_component_1.Stories, storyDetails_component_1.StoryDetails],
        bootstrap: [app_component_1.AppComponent]
    }), 
    __metadata('design:paramtypes', [])
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map