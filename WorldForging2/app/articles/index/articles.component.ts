import { Component } from '@angular/core';
import { OnInit } from '@angular/core';

import { Article } from '../article.ts';
import { ArticleListService } from '../services/articleList.service';

@Component({
    selector: 'articles',
    templateUrl: '/app/articles/index/articles.component.template.html',
    providers: [ArticleListService]
})

export class Articles implements OnInit {
    errorMessage: string;
    articles: Article[];
    mode = 'Observable';
    constructor(private articleListService: ArticleListService) { }
    ngOnInit() { this.getArticles(); }
    getArticles() {
        this.articleListService.getArticles()
            .subscribe(
            articles => this.articles = articles,
            error => this.errorMessage = <any>error);
    }
    //addArticle(name: string) {
    //    if (!name) { return; }
    //    this.articleListService.addArticle(name)
    //        .subscribe(
    //        article => this.articles.push(article),
    //        error => this.errorMessage = <any>error);
    //}
}