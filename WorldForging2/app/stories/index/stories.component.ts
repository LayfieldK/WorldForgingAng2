import { Component } from '@angular/core';
import { OnInit } from '@angular/core';

import { Story } from '../story.ts';
import { StoryListService } from '../services/storyList.service';

@Component({
    selector: 'stories',
    templateUrl: '/app/stories/index/stories.component.template.html',
    providers: [StoryListService]
})

export class Stories implements OnInit {
    errorMessage: string;
    stories: Story[];
    mode = 'Observable';
    constructor(private storyListService: StoryListService) { }
    ngOnInit() { this.getStories(); }
    getStories() {
        this.storyListService.getStories()
            .subscribe(
            stories => this.stories = stories,
            error => this.errorMessage = <any>error);
    }
    //addStory(name: string) {
    //    if (!name) { return; }
    //    this.storyListService.addStory(name)
    //        .subscribe(
    //        story => this.stories.push(story),
    //        error => this.errorMessage = <any>error);
    //}
}