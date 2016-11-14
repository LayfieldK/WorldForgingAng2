"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
const core_1 = require('@angular/core');
const articleDetails_service_1 = require('../services/articleDetails.service');
const router_1 = require('@angular/router');
let ArticleDetails = class ArticleDetails {
    constructor(articleDetailsService, route) {
        this.articleDetailsService = articleDetailsService;
        this.route = route;
        this.mode = 'Observable';
    }
    ngOnInit() {
        this.sub = this.route.params.subscribe(params => {
            this.articleId = +params['id']; // (+) converts string 'id' to a number
            this.getArticleDetails(this.articleId);
        });
    }
    getArticleDetails(articleId) {
        this.articleDetailsService.getArticleDetails(articleId)
            .subscribe(article => this.article = article, error => this.errorMessage = error);
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
};
ArticleDetails = __decorate([
    core_1.Component({
        selector: 'articleDetails',
        templateUrl: '/app/articles/details/articleDetails.component.template.html',
        providers: [articleDetails_service_1.ArticleDetailsService]
    }), 
    __metadata('design:paramtypes', [articleDetails_service_1.ArticleDetailsService, router_1.ActivatedRoute])
], ArticleDetails);
exports.ArticleDetails = ArticleDetails;
//# sourceMappingURL=articleDetails.component.js.map