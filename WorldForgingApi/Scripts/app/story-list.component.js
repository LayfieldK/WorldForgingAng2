System.register(["@angular/core", "@angular/router", "./story.service"], function(exports_1, context_1) {
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
    var core_1, router_1, story_service_1;
    var StoryListComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (story_service_1_1) {
                story_service_1 = story_service_1_1;
            }],
        execute: function() {
            StoryListComponent = (function () {
                function StoryListComponent(storyService, router) {
                    this.storyService = storyService;
                    this.router = router;
                }
                StoryListComponent.prototype.ngOnInit = function () {
                    var _this = this;
                    console.log("StoryListComponent instantiated with the following type: " + this.class);
                    var s = null;
                    switch (this.class) {
                        case "latest":
                        default:
                            this.title = "Latest Stories";
                            s = this.storyService.getLatest();
                            break;
                        case "most-viewed":
                            this.title = "Most Viewed Stories";
                            s = this.storyService.getMostViewed();
                            break;
                        case "random":
                            this.title = "Random Stories";
                            s = this.storyService.getRandom();
                            break;
                    }
                    s.subscribe(function (stories) { return _this.stories = stories; }, function (error) { return _this.errorMessage = error; });
                };
                StoryListComponent.prototype.onSelect = function (story) {
                    this.selectedStory = story;
                    console.log("Story " + this.selectedStory.Id + " has been clicked: loading story viewer...");
                    this.router.navigate(["story/view", this.selectedStory.Id]);
                };
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', String)
                ], StoryListComponent.prototype, "class", void 0);
                StoryListComponent = __decorate([
                    core_1.Component({
                        selector: "story-list",
                        template: "\n<h3>{{title}}</h3>\n<ul class=\"stories\">\n    <li *ngFor=\"let story of stories\"\n        [class.selected]=\"story === selectedStory\"\n        (click)=\"onSelect(story)\">\n        <div class=\"title\">{{story.Title}}</div>\n        <div class=\"description\">{{story.Description}}</div>\n    </li>\n</ul>\n    ",
                        styles: ["\n        ul.stories li { \n            cursor: pointer;\n        }\n        ul.stories li.selected { \n            background-color: #dddddd; \n        }\n    "]
                    }), 
                    __metadata('design:paramtypes', [story_service_1.StoryService, router_1.Router])
                ], StoryListComponent);
                return StoryListComponent;
            }());
            exports_1("StoryListComponent", StoryListComponent);
        }
    }
});
