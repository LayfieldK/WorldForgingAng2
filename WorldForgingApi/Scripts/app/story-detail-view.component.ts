import {Component, OnInit} from "@angular/core";
import {Router, ActivatedRoute} from "@angular/router";
import {Story} from "./story";
import {AuthService} from "./auth.service";
import {StoryService} from "./story.service";

@Component({
    selector: "story-detail-view",
    template: `
<div *ngIf="story">
    <h2>
        <a href="javascript:void(0)" (click)="onBack()">&laquo; Back to Home</a>
    </h2>
    <div class="story-container">
        <ul class="nav nav-tabs">
            <li *ngIf="authService.isLoggedIn()" role="presentation">
                <a href="javascript:void(0)" (click)="onStoryDetailEdit(story)">Edit</a>
            </li>
            <li role="presentation" class="active">
                <a href="javascript:void(0)">View</a>
            </li>
        </ul>
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="story-image-panel">
                    <img src="/img/story-image-sample.png" alt="{{story.Title}}" />
                    <div class="caption">Sample image with caption.</div>
                </div>
                <h3>{{story.Title}}</h3>
                <p>{{story.Description}}</p>
                <p>{{story.Text}}</p>
            </div>
        </div>
    </div>
</div>
    `,
    styles: []
})

export class StoryDetailViewComponent {
    story: Story;

    constructor(
        private authService: AuthService,
        private storyService: StoryService,
        private router: Router,
        private activatedRoute: ActivatedRoute) { }

    ngOnInit() {
        var id = +this.activatedRoute.snapshot.params["id"];
        if (id) {
            this.storyService.get(id).subscribe(
                story => this.story = story
            );
        }
        else if (id === 0) {
            console.log("id is 0: switching to edit mode...");
            this.router.navigate(["story/edit", 0]);
        }
        else {
            console.log("Invalid id: routing back to home...");
            this.router.navigate([""]);
        }
    }

    onStoryDetailEdit(story: Story) {
        this.router.navigate(["story/edit", story.Id]);
        return false;
    }

    onBack() {
        this.router.navigate(['']);
    }
}
