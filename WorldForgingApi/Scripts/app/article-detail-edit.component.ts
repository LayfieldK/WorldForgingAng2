import {Component, OnInit} from "@angular/core";
import {Router, ActivatedRoute} from "@angular/router";
import {Article} from "./article";
import {AuthService} from "./auth.service";
import {ArticleService} from "./article.service";

@Component({
    selector: "article-detail-edit",
    template: `
<div *ngIf="article">
    <h2>
        <a href="javascript:void(0)" (click)="onBack()">
            &laquo; Back to Home
        </a>
    </h2>
    <div class="article-container">
        <ul class="nav nav-tabs">
            <li role="presentation" class="active">
                <a href="javascript:void(0)">Edit</a>
            </li>
            <li role="presentation" *ngIf="article.Id != 0">
                <a href="javascript:void(0)" (click)="onArticleDetailView(article)">View</a>
            </li>
        </ul>
        <div class="panel panel-default">
            <div class="panel-body">
                <form class="article-detail-edit" #thisForm="ngForm">
                    <h3>
                        {{article.Title}}
                        <span class="empty-field" [hidden]="dTitle.valid">
                            Empty Title
                        </span>
                    </h3>
                    <div class="form-group has-feedback" [ngClass]="{'has-success': dTitle.valid, 'has-error': !dTitle.valid}">
                        <label for="input-title">Title</label>
                        <input id="input-title" name="input-title" type="text" class="form-control" [(ngModel)]="article.Title" placeholder="Insert the title..." required #dTitle="ngModel" />
                        <span class="glyphicon form-control-feedback" aria-hidden="true" [ngClass]="{'glyphicon-ok': dTitle.valid, 'glyphicon-remove': !dTitle.valid}"></span>
                        <div [hidden]="dTitle.valid" class="alert alert-danger">
                            You need to enter a valid Title.
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="input-description">Description</label>
                        <textarea id="input-description" name="input-description" class="form-control" [(ngModel)]="article.Description" placeholder="Insert a suitable description..." required></textarea>
                    </div>
                    <div class="form-group">
                        <label for="input-text">Text</label>
                        <textarea id="input-text" name="input-text" class="form-control" [(ngModel)]="article.Text" placeholder="Insert a suitable description..."></textarea>
                    </div>
                    <div *ngIf="article.Id == 0" class="commands insert">
                        <input type="button" class="btn btn-primary" value="Save" (click)="onInsert(article)" />
                        <input type="button" class="btn btn-default" value="Cancel" (click)="onBack()" />
                    </div>
                    <div *ngIf="article.Id != 0" class="commands update">
                        <input type="button" class="btn btn-primary" value="Update" (click)="onUpdate(article)" />
                        <input type="button" class="btn btn-danger" value="Delete" (click)="onDelete(article)" />
                        <input type="button" class="btn btn-default" value="Cancel" (click)="onArticleDetailView(article)" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>
    `,
    styles: []
})

export class ArticleDetailEditComponent {
    article: Article;

    constructor(
        private authService: AuthService,
        private articleService: ArticleService,
        private router: Router,
        private activatedRoute: ActivatedRoute) { }

    ngOnInit() {
        if (!this.authService.isLoggedIn()) {
            this.router.navigate([""]);
        }
        var id = +this.activatedRoute.snapshot.params["id"];
        if (id) {
            this.articleService.get(id).subscribe(
                article => this.article = article
            );
        }
        else if (id === 0) {
            console.log("id is 0: adding a new article...");
            this.article = new Article(0, "New Article", null);
        }
        else {
            console.log("Invalid id: routing back to home...");
            this.router.navigate([""]);
        }
    }

    onInsert(article: Article) {
        this.articleService.add(article).subscribe(
            (data) => {
                this.article = data;
                console.log("Article " + this.article.Id + " has been added.");
                this.router.navigate([""]);
            },
            (error) => console.log(error)
        );
    }

    onUpdate(article: Article) {
        this.articleService.update(article).subscribe(
            (data) => {
                this.article = data;
                console.log("Article " + this.article.Id + " has been updated.");
                this.router.navigate(["article/view", this.article.Id]);
            },
            (error) => console.log(error)
        );
    }

    onDelete(article: Article) {
        var id = article.Id;
        this.articleService.delete(id).subscribe(
            (data) => {
                console.log("Article " + id + " has been deleted.");
                this.router.navigate([""]);
            },
            (error) => console.log(error)
        );
    }

    onBack() {
        this.router.navigate([""]);
    }

    onArticleDetailView(article: Article) {
        this.router.navigate(["article/view", article.Id]);
    }
}
