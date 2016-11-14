import { Component } from '@angular/core';
import { OnInit } from '@angular/core';

import { Story } from '../story.ts';
import { StoryDetailsService } from '../services/storyDetails.service';

import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'storyDetails',
    templateUrl: '/app/stories/details/storyDetails.component.template.html',
    providers: [StoryDetailsService]
})

export class StoryDetails implements OnInit {
    errorMessage: string;
    story: Story;
    mode = 'Observable';
    storyId: Number;
    private sub: any;
    constructor(private storyDetailsService: StoryDetailsService, private route: ActivatedRoute) { }
    ngOnInit() {
        
        this.sub = this.route.params.subscribe(params => {
            this.storyId = +params['id']; // (+) converts string 'id' to a number
            this.getStoryDetails(this.storyId);
        });
    }
    getStoryDetails(storyId : Number) {
        this.storyDetailsService.getStoryDetails(storyId)
            .subscribe(
            story => this.story = story,
            error => this.errorMessage = <any>error);
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
}