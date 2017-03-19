import {Component, OnInit} from "@angular/core";
import { Router, ActivatedRoute, Params} from "@angular/router";
import {Story} from "./story";
import {AuthService} from "./auth.service";
import {StoryService} from "./story.service";

@Component({
    selector: "story-detail-edit",
    template: `
<div *ngIf="story">
    <h2>
        <a href="javascript:void(0)" (click)="onBack()">
            &laquo; Back to Home
        </a>
    </h2>
    <div class="story-container">
        <ul class="nav nav-tabs">
            <li role="presentation" class="active">
                <a href="javascript:void(0)">Edit</a>
            </li>
            <li role="presentation" *ngIf="story.Id != 0">
                <a href="javascript:void(0)" (click)="onStoryDetailView(story)">View</a>
            </li>
        </ul>
        <div class="panel panel-default">
            <div class="panel-body">
                <form class="story-detail-edit" #thisForm="ngForm">
                    <h3>
                        {{story.Title}}
                        <span class="empty-field" [hidden]="dTitle.valid">
                            Empty Title
                        </span>
                    </h3>
                    <div class="form-group has-feedback" [ngClass]="{'has-success': dTitle.valid, 'has-error': !dTitle.valid}">
                        <label for="input-title">Title</label>
                        <input id="input-title" name="input-title" type="text" class="form-control" [(ngModel)]="story.Title" placeholder="Insert the title..." required #dTitle="ngModel" />
                        <span class="glyphicon form-control-feedback" aria-hidden="true" [ngClass]="{'glyphicon-ok': dTitle.valid, 'glyphicon-remove': !dTitle.valid}"></span>
                        <div [hidden]="dTitle.valid" class="alert alert-danger">
                            You need to enter a valid Title.
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="input-description">Description</label>
                        <textarea id="input-description" name="input-description" class="form-control" [(ngModel)]="story.Description" placeholder="Insert a suitable description..." required></textarea>
                    </div>
                    <div class="form-group">
                        <label for="input-text">Text</label>
                        <textarea id="input-text" name="input-text" class="form-control" [(ngModel)]="story.Text" placeholder="Insert a suitable description..."></textarea>
                    </div>
                    <div *ngIf="story.Id == 0" class="commands insert">
                        <input type="button" class="btn btn-primary" value="Save" (click)="onInsert(story)" />
                        <input type="button" class="btn btn-default" value="Cancel" (click)="onBack()" />
                    </div>
                    <div *ngIf="story.Id != 0" class="commands update">
                        <input type="button" class="btn btn-primary" value="Update" (click)="onUpdate(story)" />
                        <input type="button" class="btn btn-danger" value="Delete" (click)="onDelete(story)" />
                        <input type="button" class="btn btn-default" value="Cancel" (click)="onStoryDetailView(story)" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>
    `,
    styles: []
})

export class StoryDetailEditComponent {
    story: Story;

    constructor(
        private authService: AuthService,
        private storyService: StoryService,
        private router: Router,
        private activatedRoute: ActivatedRoute) { }

    ngOnInit() {
        if (!this.authService.isLoggedIn()) {
            this.router.navigate([""]);
        }
        var id;
        this.activatedRoute.params.subscribe((params: Params) => {
            id = params['id'];
            console.log(params);
        });
        if (id) {
            this.storyService.get(id).subscribe(
                story => this.story = story
            );
        }
        else if (id === 0) {
            console.log("id is 0: adding a new story...");
            this.story = new Story(0, "New Story", null, null);
        }
        else {
            console.log("Invalid id: routing back to home...");
            this.router.navigate([""]);
        }
    }

    onInsert(story: Story) {
        this.storyService.add(story).subscribe(
            (data) => {
                this.story = data;
                console.log("Story " + this.story.Id + " has been added.");
                this.router.navigate([""]);
            },
            (error) => console.log(error)
        );
    }

    onUpdate(story: Story) {
        console.log("story object");
        console.log(story);
        console.log("end story object");
        this.storyService.update(story).subscribe(
            (data) => {
                this.story = data;
                console.log("Story " + this.story.Id + " has been updated.");
                this.router.navigate(["story/view", this.story.Id]);
            },
            (error) => console.log(error)
        );
    }

    onDelete(story: Story) {
        var id = story.Id;
        this.storyService.delete(id).subscribe(
            (data) => {
                console.log("Story " + id + " has been deleted.");
                this.router.navigate([""]);
            },
            (error) => console.log(error)
        );
    }

    onBack() {
        this.router.navigate([""]);
    }

    onStoryDetailView(story: Story) {
        this.router.navigate(["story/view", story.Id]);
    }
}
