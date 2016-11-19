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
const storyService_service_1 = require('../services/storyService.service');
const router_1 = require('@angular/router');
let StoryDetails = class StoryDetails {
    constructor(storyService, route) {
        this.storyService = storyService;
        this.route = route;
        this.mode = 'Observable';
    }
    ngOnInit() {
        this.route.params.subscribe(params => {
            this.storyId = +params['id']; // (+) converts string 'id' to a number
            this.getStoryDetails(this.storyId);
        });
    }
    getStoryDetails(storyId) {
        this.storyService.getStoryDetails(storyId)
            .subscribe(story => this.story = story, error => this.errorMessage = error);
    }
    ngOnDestroy() {
        this.sub.unsubscribe();
    }
};
StoryDetails = __decorate([
    core_1.Component({
        selector: 'storyDetails',
        templateUrl: '/app/stories/details/storyDetails.component.template.html',
        providers: [storyService_service_1.StoryService]
    }), 
    __metadata('design:paramtypes', [storyService_service_1.StoryService, router_1.ActivatedRoute])
], StoryDetails);
exports.StoryDetails = StoryDetails;
//# sourceMappingURL=storyDetails.component.js.map