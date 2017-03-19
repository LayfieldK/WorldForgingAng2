System.register(["@angular/core", "../services/storyService.service"], function (exports_1, context_1) {
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
    var core_1, storyService_service_1, Stories;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (storyService_service_1_1) {
                storyService_service_1 = storyService_service_1_1;
            }
        ],
        execute: function () {
            Stories = (function () {
                function Stories(storyService) {
                    this.storyService = storyService;
                    this.mode = 'Observable';
                }
                Stories.prototype.ngOnInit = function () { this.getStories(); };
                Stories.prototype.getStories = function () {
                    var _this = this;
                    this.storyService.getStories()
                        .subscribe(function (stories) { return _this.stories = stories; }, function (error) { return _this.errorMessage = error; });
                };
                return Stories;
            }());
            Stories = __decorate([
                core_1.Component({
                    selector: 'stories',
                    templateUrl: '/Scripts/app/stories/index/stories.component.template.html',
                    providers: [storyService_service_1.StoryService]
                }),
                __metadata("design:paramtypes", [storyService_service_1.StoryService])
            ], Stories);
            exports_1("Stories", Stories);
        }
    };
});
