import {Component, Input, OnInit} from "@angular/core";
import {Router} from "@angular/router";
import {Story} from "./story";
import {StoryService} from "./story.service";

@Component({
    selector: "story-list",
    template: `
<h3>{{title}}</h3>
<ul class="stories">
    <li *ngFor="let story of stories"
        [class.selected]="story === selectedStory"
        (click)="onSelect(story)">
        <div class="title">{{story.Title}}</div>
        <div class="description">{{story.Description}}</div>
    </li>
</ul>
    `,
    styles: [`
        ul.stories li { 
            cursor: pointer;
        }
        ul.stories li.selected { 
            background-color: #dddddd; 
        }
    `]
})

export class StoryListComponent implements OnInit {
    @Input() class: string;
    title: string;
    selectedStory: Story;
    stories: Story[];
    errorMessage: string;

    constructor(private storyService: StoryService, private router: Router) { }

    ngOnInit() {
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
        s.subscribe(
            stories => this.stories = stories,
            error => this.errorMessage = <any>error
        );
    }

    onSelect(story: Story) {
        this.selectedStory = story;
        console.log("Story " + this.selectedStory.Id + " has been clicked: loading story viewer...");
        this.router.navigate(["story/view", this.selectedStory.Id]);
    }
}
