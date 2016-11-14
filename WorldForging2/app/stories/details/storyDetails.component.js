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
const storyDetails_service_1 = require('../services/storyDetails.service');
const router_1 = require('@angular/router');
let StoryDetails = class StoryDetails {
    constructor(storyDetailsService, route) {
        this.storyDetailsService = storyDetailsService;
        this.route = route;
        this.mode = 'Observable';
    }
    ngOnInit() {
        this.sub = this.route.params.subscribe(params => {
            this.storyId = +params['id']; // (+) converts string 'id' to a number
            this.getStoryDetails(this.storyId);
        });
    }
    getStoryDetails(storyId) {
        this.storyDetailsService.getStoryDetails(storyId)
            .subscribe(story => this.story = story, error => this.errorMessage = error);
    }
    //addStory(name: string) {
    //    if (!name) { return; }
    //    this.storyListService.addStory(name)
    //        .subscribe(
    //        story => this.stories.push(story),
    //        error => this.errorMessage = <any>error);
    //}
    ngOnDestroy() {
        this.sub.unsubscribe();
    }
};
StoryDetails = __decorate([
    core_1.Component({
        selector: 'storyDetails',
        templateUrl: '/app/stories/details/storyDetails.component.template.html',
        providers: [storyDetails_service_1.StoryDetailsService]
    }), 
    __metadata('design:paramtypes', [storyDetails_service_1.StoryDetailsService, router_1.ActivatedRoute])
], StoryDetails);
exports.StoryDetails = StoryDetails;
//# sourceMappingURL=storyDetails.component.js.map