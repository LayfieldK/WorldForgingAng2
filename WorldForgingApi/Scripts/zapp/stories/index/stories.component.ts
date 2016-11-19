import { Component } from '@angular/core';
import { OnInit } from '@angular/core';

import { Story } from '../story';
import { StoryService } from '../services/storyService.service';

@Component({
    selector: 'stories',
    templateUrl: '/Scripts/app/stories/index/stories.component.template.html',
    providers: [StoryService]
})

export class Stories implements OnInit {
    errorMessage: string;
    stories: Story[];
    mode = 'Observable';
    constructor(private storyService: StoryService) { }
    ngOnInit() { this.getStories(); }
    getStories() {
        this.storyService.getStories()
            .subscribe(
            stories => this.stories = stories,
            error => this.errorMessage = <any>error);
    }
    //addStory(name: string) {
    //    if (!name) { return; }
    //    this.storyService.addStory(name)
    //        .subscribe(
    //        story => this.stories.push(story),
    //        error => this.errorMessage = <any>error);
    //}
}