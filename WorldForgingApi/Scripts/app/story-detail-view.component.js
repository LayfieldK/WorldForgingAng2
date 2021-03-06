System.register(["@angular/core", "@angular/router", "./auth.service", "./story.service"], function (exports_1, context_1) {
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
    var __moduleName = context_1 && context_1.id;
    var core_1, router_1, auth_service_1, story_service_1, StoryDetailViewComponent;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (auth_service_1_1) {
                auth_service_1 = auth_service_1_1;
            },
            function (story_service_1_1) {
                story_service_1 = story_service_1_1;
            }
        ],
        execute: function () {
            StoryDetailViewComponent = (function () {
                function StoryDetailViewComponent(authService, storyService, router, activatedRoute) {
                    this.authService = authService;
                    this.storyService = storyService;
                    this.router = router;
                    this.activatedRoute = activatedRoute;
                }
                StoryDetailViewComponent.prototype.ngOnInit = function () {
                    var _this = this;
                    var id; // = +this.activatedRoute.snapshot.params["id"];
                    this.activatedRoute.params.subscribe(function (params) {
                        id = params['id'];
                        console.log(params);
                    });
                    if (id) {
                        this.storyService.get(id).subscribe(function (story) { return _this.story = story; });
                    }
                    else if (id === 0) {
                        console.log("id is 0: switching to edit mode...");
                        this.router.navigate(["story/edit", 0]);
                    }
                    else {
                        console.log("Invalid id: routing back to home...");
                        this.router.navigate([""]);
                    }
                };
                StoryDetailViewComponent.prototype.onStoryDetailEdit = function (story) {
                    this.router.navigate(["story/edit", story.Id]);
                    return false;
                };
                StoryDetailViewComponent.prototype.onBack = function () {
                    this.router.navigate(['']);
                };
                return StoryDetailViewComponent;
            }());
            StoryDetailViewComponent = __decorate([
                core_1.Component({
                    selector: "story-detail-view",
                    template: "\n<div *ngIf=\"story\">\n    <h2>\n        <a href=\"javascript:void(0)\" (click)=\"onBack()\">&laquo; Back to Home</a>\n    </h2>\n    <div class=\"story-container\">\n        <ul class=\"nav nav-tabs\">\n            <li *ngIf=\"authService.isLoggedIn()\" role=\"presentation\">\n                <a href=\"javascript:void(0)\" (click)=\"onStoryDetailEdit(story)\">Edit</a>\n            </li>\n            <li role=\"presentation\" class=\"active\">\n                <a href=\"javascript:void(0)\">View</a>\n            </li>\n        </ul>\n        <div class=\"panel panel-default\">\n            <div class=\"panel-body\">\n                <div class=\"story-image-panel\">\n                    <img src=\"/img/story-image-sample.png\" alt=\"{{story.Title}}\" />\n                    <div class=\"caption\">Sample image with caption.</div>\n                </div>\n                <h3>{{story.Title}}</h3>\n                <p>{{story.Description}}</p>\n                <p>{{story.Text}}</p>\n            </div>\n        </div>\n    </div>\n</div>\n    ",
                    styles: []
                }),
                __metadata("design:paramtypes", [auth_service_1.AuthService,
                    story_service_1.StoryService,
                    router_1.Router,
                    router_1.ActivatedRoute])
            ], StoryDetailViewComponent);
            exports_1("StoryDetailViewComponent", StoryDetailViewComponent);
        }
    };
});
