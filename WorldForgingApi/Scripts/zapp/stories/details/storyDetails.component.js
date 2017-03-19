System.register(["@angular/core", "../services/storyService.service", "@angular/router"], function (exports_1, context_1) {
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
    var core_1, storyService_service_1, router_1, StoryDetails;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (storyService_service_1_1) {
                storyService_service_1 = storyService_service_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            }
        ],
        execute: function () {
            StoryDetails = (function () {
                function StoryDetails(storyService, route) {
                    this.storyService = storyService;
                    this.route = route;
                    this.mode = 'Observable';
                }
                StoryDetails.prototype.ngOnInit = function () {
                    var _this = this;
                    this.route.params.subscribe(function (params) {
                        _this.storyId = +params['id']; // (+) converts string 'id' to a number
                        _this.getStoryDetails(_this.storyId);
                    });
                };
                StoryDetails.prototype.getStoryDetails = function (storyId) {
                    var _this = this;
                    this.storyService.getStoryDetails(storyId)
                        .subscribe(function (story) { return _this.story = story; }, function (error) { return _this.errorMessage = error; });
                };
                StoryDetails.prototype.ngOnDestroy = function () {
                    this.sub.unsubscribe();
                };
                return StoryDetails;
            }());
            StoryDetails = __decorate([
                core_1.Component({
                    selector: 'storyDetails',
                    templateUrl: '/Scripts/app/stories/details/storyDetails.component.template.html',
                    providers: [storyService_service_1.StoryService]
                }),
                __metadata("design:paramtypes", [storyService_service_1.StoryService, router_1.ActivatedRoute])
            ], StoryDetails);
            exports_1("StoryDetails", StoryDetails);
        }
    };
});
