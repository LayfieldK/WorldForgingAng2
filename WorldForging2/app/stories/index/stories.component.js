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
let Stories = class Stories {
    constructor(storyService) {
        this.storyService = storyService;
        this.mode = 'Observable';
    }
    ngOnInit() { this.getStories(); }
    getStories() {
        this.storyService.getStories()
            .subscribe(stories => this.stories = stories, error => this.errorMessage = error);
    }
};
Stories = __decorate([
    core_1.Component({
        selector: 'stories',
        templateUrl: '/app/stories/index/stories.component.template.html',
        providers: [storyService_service_1.StoryService]
    }), 
    __metadata('design:paramtypes', [storyService_service_1.StoryService])
], Stories);
exports.Stories = Stories;
//# sourceMappingURL=stories.component.js.map