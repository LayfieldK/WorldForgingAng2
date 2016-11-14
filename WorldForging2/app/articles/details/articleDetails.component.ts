import { Component } from '@angular/core';
import { OnInit } from '@angular/core';

import { Article } from '../article.ts';
import { ArticleDetailsService } from '../services/articleDetails.service';

import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'articleDetails',
    templateUrl: '/app/articles/details/articleDetails.component.template.html',
    providers: [ArticleDetailsService]
})

export class ArticleDetails implements OnInit {
    errorMessage: string;
    article: Article;
    mode = 'Observable';
    articleId: Number;
    private sub: any;
    constructor(private articleDetailsService: ArticleDetailsService, private route: ActivatedRoute) { }
    ngOnInit() {
        
        this.sub = this.route.params.subscribe(params => {
            this.articleId = +params['id']; // (+) converts string 'id' to a number
            this.getArticleDetails(this.articleId);
        });
    }
    getArticleDetails(articleId : Number) {
        this.articleDetailsService.getArticleDetails(articleId)
            .subscribe(
            article => this.article = article,
            error => this.errorMessage = <any>error);
    }
    //addArticle(name: string) {
    //    if (!name) { return; }
    //    this.articleListService.addArticle(name)
    //        .subscribe(
    //        article => this.articles.push(article),
    //        error => this.errorMessage = <any>error);
    //}

    ngOnDestroy() {
        this.sub.unsubscribe();
    }
}