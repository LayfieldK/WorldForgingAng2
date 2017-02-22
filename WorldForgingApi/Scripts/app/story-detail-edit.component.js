System.register(["@angular/core", "@angular/router", "./story", "./auth.service", "./story.service"], function(exports_1, context_1) {
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
    var core_1, router_1, story_1, auth_service_1, story_service_1;
    var StoryDetailEditComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (story_1_1) {
                story_1 = story_1_1;
            },
            function (auth_service_1_1) {
                auth_service_1 = auth_service_1_1;
            },
            function (story_service_1_1) {
                story_service_1 = story_service_1_1;
            }],
        execute: function() {
            StoryDetailEditComponent = (function () {
                function StoryDetailEditComponent(authService, storyService, router, activatedRoute) {
                    this.authService = authService;
                    this.storyService = storyService;
                    this.router = router;
                    this.activatedRoute = activatedRoute;
                }
                StoryDetailEditComponent.prototype.ngOnInit = function () {
                    var _this = this;
                    if (!this.authService.isLoggedIn()) {
                        this.router.navigate([""]);
                    }
                    var id = +this.activatedRoute.snapshot.params["id"];
                    if (id) {
                        this.storyService.get(id).subscribe(function (story) { return _this.story = story; });
                    }
                    else if (id === 0) {
                        console.log("id is 0: adding a new story...");
                        this.story = new story_1.Story(0, "New Story", null, null);
                    }
                    else {
                        console.log("Invalid id: routing back to home...");
                        this.router.navigate([""]);
                    }
                };
                StoryDetailEditComponent.prototype.onInsert = function (story) {
                    var _this = this;
                    this.storyService.add(story).subscribe(function (data) {
                        _this.story = data;
                        console.log("Story " + _this.story.Id + " has been added.");
                        _this.router.navigate([""]);
                    }, function (error) { return console.log(error); });
                };
                StoryDetailEditComponent.prototype.onUpdate = function (story) {
                    var _this = this;
                    this.storyService.update(story).subscribe(function (data) {
                        _this.story = data;
                        console.log("Story " + _this.story.Id + " has been updated.");
                        _this.router.navigate(["story/view", _this.story.Id]);
                    }, function (error) { return console.log(error); });
                };
                StoryDetailEditComponent.prototype.onDelete = function (story) {
                    var _this = this;
                    var id = story.Id;
                    this.storyService.delete(id).subscribe(function (data) {
                        console.log("Story " + id + " has been deleted.");
                        _this.router.navigate([""]);
                    }, function (error) { return console.log(error); });
                };
                StoryDetailEditComponent.prototype.onBack = function () {
                    this.router.navigate([""]);
                };
                StoryDetailEditComponent.prototype.onStoryDetailView = function (story) {
                    this.router.navigate(["story/view", story.Id]);
                };
                StoryDetailEditComponent = __decorate([
                    core_1.Component({
                        selector: "story-detail-edit",
                        template: "\n<div *ngIf=\"story\">\n    <h2>\n        <a href=\"javascript:void(0)\" (click)=\"onBack()\">\n            &laquo; Back to Home\n        </a>\n    </h2>\n    <div class=\"story-container\">\n        <ul class=\"nav nav-tabs\">\n            <li role=\"presentation\" class=\"active\">\n                <a href=\"javascript:void(0)\">Edit</a>\n            </li>\n            <li role=\"presentation\" *ngIf=\"story.Id != 0\">\n                <a href=\"javascript:void(0)\" (click)=\"onStoryDetailView(story)\">View</a>\n            </li>\n        </ul>\n        <div class=\"panel panel-default\">\n            <div class=\"panel-body\">\n                <form class=\"story-detail-edit\" #thisForm=\"ngForm\">\n                    <h3>\n                        {{story.Title}}\n                        <span class=\"empty-field\" [hidden]=\"dTitle.valid\">\n                            Empty Title\n                        </span>\n                    </h3>\n                    <div class=\"form-group has-feedback\" [ngClass]=\"{'has-success': dTitle.valid, 'has-error': !dTitle.valid}\">\n                        <label for=\"input-title\">Title</label>\n                        <input id=\"input-title\" name=\"input-title\" type=\"text\" class=\"form-control\" [(ngModel)]=\"story.Title\" placeholder=\"Insert the title...\" required #dTitle=\"ngModel\" />\n                        <span class=\"glyphicon form-control-feedback\" aria-hidden=\"true\" [ngClass]=\"{'glyphicon-ok': dTitle.valid, 'glyphicon-remove': !dTitle.valid}\"></span>\n                        <div [hidden]=\"dTitle.valid\" class=\"alert alert-danger\">\n                            You need to enter a valid Title.\n                        </div>\n                    </div>\n                    <div class=\"form-group\">\n                        <label for=\"input-description\">Description</label>\n                        <textarea id=\"input-description\" name=\"input-description\" class=\"form-control\" [(ngModel)]=\"story.Description\" placeholder=\"Insert a suitable description...\" required></textarea>\n                    </div>\n                    <div class=\"form-group\">\n                        <label for=\"input-text\">Text</label>\n                        <textarea id=\"input-text\" name=\"input-text\" class=\"form-control\" [(ngModel)]=\"story.Text\" placeholder=\"Insert a suitable description...\"></textarea>\n                    </div>\n                    <div *ngIf=\"story.Id == 0\" class=\"commands insert\">\n                        <input type=\"button\" class=\"btn btn-primary\" value=\"Save\" (click)=\"onInsert(story)\" />\n                        <input type=\"button\" class=\"btn btn-default\" value=\"Cancel\" (click)=\"onBack()\" />\n                    </div>\n                    <div *ngIf=\"story.Id != 0\" class=\"commands update\">\n                        <input type=\"button\" class=\"btn btn-primary\" value=\"Update\" (click)=\"onUpdate(story)\" />\n                        <input type=\"button\" class=\"btn btn-danger\" value=\"Delete\" (click)=\"onDelete(story)\" />\n                        <input type=\"button\" class=\"btn btn-default\" value=\"Cancel\" (click)=\"onStoryDetailView(story)\" />\n                    </div>\n                </form>\n            </div>\n        </div>\n    </div>\n</div>\n    ",
                        styles: []
                    }), 
                    __metadata('design:paramtypes', [auth_service_1.AuthService, story_service_1.StoryService, router_1.Router, router_1.ActivatedRoute])
                ], StoryDetailEditComponent);
                return StoryDetailEditComponent;
            }());
            exports_1("StoryDetailEditComponent", StoryDetailEditComponent);
        }
    }
});
