import { Component } from '@angular/core';
import { OnInit } from '@angular/core';

import { Story } from '../story';
import { StoryService } from '../services/storyService.service';

import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'storyDetails',
    templateUrl: '/Scripts/app/stories/details/storyDetails.component.template.html',
    providers: [StoryService]
})

export class StoryDetails implements OnInit {
    errorMessage: string;
    story: Story;
    mode = 'Observable';
    storyId: Number;
    private sub: any;
    constructor(private storyService: StoryService, private route: ActivatedRoute) { }
    ngOnInit() {
        
        this.route.params.subscribe(params => {
            this.storyId = +params['id']; // (+) converts string 'id' to a number
            this.getStoryDetails(this.storyId);
        });
    }
    getStoryDetails(storyId : Number) {
        this.storyService.getStoryDetails(storyId)
            .subscribe(
            story => this.story = story,
            error => this.errorMessage = <any>error);
    }
    ngOnDestroy() {
        this.sub.unsubscribe();
    }
}