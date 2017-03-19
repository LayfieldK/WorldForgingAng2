import {Component, OnInit} from "@angular/core";
import {Router, ActivatedRoute, Params} from "@angular/router";
import {Article} from "./article";
import {AuthService} from "./auth.service";
import { ArticleService } from "./article.service";
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/map';

@Component({
    selector: "article-detail-view",
    template: `
<div *ngIf="article">
    <h2>
        <a href="javascript:void(0)" (click)="onBack()">&laquo; Back to Home</a>
    </h2>
    <div class="article-container">
        <ul class="nav nav-tabs">
            <li *ngIf="authService.isLoggedIn()" role="presentation">
                <a href="javascript:void(0)" (click)="onArticleDetailEdit(article)">Edit</a>
            </li>
            <li role="presentation" class="active">
                <a href="javascript:void(0)">View</a>
            </li>
        </ul>
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="article-image-panel">
                    <img src="/img/article-image-sample.png" alt="{{article.Title}}" />
                    <div class="caption">Sample image with caption.</div>
                </div>
                <h3>{{article.Title}}</h3>
                <p>{{article.Description}}</p>
                <p>{{article.Text}}</p>
            </div>
        </div>
    </div>
</div>
    `,
    styles: []
})

export class ArticleDetailViewComponent {
    article: Article;

    constructor(
        private authService: AuthService,
        private articleService: ArticleService,
        private router: Router,
        private activatedRoute: ActivatedRoute) { }

    ngOnInit() {
        var id;
        this.activatedRoute.params
            .map(params => +params['id'])
            .do(id => {
                console.log(id);
                if (id) {
                    console.log(id);
                } else if (id === 0) {
                    console.log("id is 0: switching to edit mode...");
                    this.router.navigate(["article/edit", 0]);
                } else {
                    console.log("Invalid id: routing back to home...");
                    this.router.navigate([""]);
                }
            })
            .filter(id => id > 0)
            .switchMap(id => this.articleService.get(id))
            .subscribe(article => this.article = article);
        //if (id) {
        //    this.articleService.get(id).subscribe(
        //        article => this.article = article
        //    );
        //}
        //else if (id === 0) {
        //    console.log("id is 0: switching to edit mode...");
        //    this.router.navigate(["article/edit", 0]);
        //}
        //else {
        //    console.log("Invalid id: routing back to home...");
        //    this.router.navigate([""]);
        //}
    }

    onArticleDetailEdit(article: Article) {
        this.router.navigate(["article/edit", article.Id]);
        return false;
    }

    onBack() {
        this.router.navigate(['']);
    }
}
