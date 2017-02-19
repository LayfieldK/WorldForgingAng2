import {Component, Input, OnInit} from "@angular/core";
import {Router} from "@angular/router";
import {Article} from "./article";
import {ArticleService} from "./article.service";

@Component({
    selector: "article-list",
    template: `
<h3>{{title}}</h3>
<ul class="articles">
    <li *ngFor="let article of articles"
        [class.selected]="article === selectedArticle"
        (click)="onSelect(article)">
        <div class="title">{{article.Title}}</div>
        <div class="description">{{article.Description}}</div>
    </li>
</ul>
    `,
    styles: [`
        ul.articles li { 
            cursor: pointer;
        }
        ul.articles li.selected { 
            background-color: #dddddd; 
        }
    `]
})

export class ArticleListComponent implements OnInit {
    @Input() class: string;
    title: string;
    selectedArticle: Article;
    articles: Article[];
    errorMessage: string;

    constructor(private articleService: ArticleService, private router: Router) { }

    ngOnInit() {
        console.log("ArticleListComponent instantiated with the following type: " + this.class);
        var s = null;
        switch (this.class) {
            case "latest":
            default:
                this.title = "Latest Articles";
                s = this.articleService.getLatest();
                break;
            case "most-viewed":
                this.title = "Most Viewed Articles";
                s = this.articleService.getMostViewed();
                break;
            case "random":
                this.title = "Random Articles";
                s = this.articleService.getRandom();
                break;
        }
        s.subscribe(
            articles => this.articles = articles,
            error => this.errorMessage = <any>error
        );
    }

    onSelect(article: Article) {
        this.selectedArticle = article;
        console.log("Article " + this.selectedArticle.Id + " has been clicked: loading article viewer...");
        this.router.navigate(["article/view", this.selectedArticle.Id]);
    }
}
