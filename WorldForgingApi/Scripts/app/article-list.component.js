System.register(["@angular/core", "@angular/router", "./article.service"], function (exports_1, context_1) {
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
    var __moduleName = context_1 && context_1.id;
    var core_1, router_1, article_service_1, ArticleListComponent;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (article_service_1_1) {
                article_service_1 = article_service_1_1;
            }
        ],
        execute: function () {
            ArticleListComponent = (function () {
                function ArticleListComponent(articleService, router) {
                    this.articleService = articleService;
                    this.router = router;
                }
                ArticleListComponent.prototype.ngOnInit = function () {
                    var _this = this;
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
                    s.subscribe(function (articles) { return _this.articles = articles; }, function (error) { return _this.errorMessage = error; });
                };
                ArticleListComponent.prototype.onSelect = function (article) {
                    this.selectedArticle = article;
                    console.log("Article " + this.selectedArticle.Id + " has been clicked: loading article viewer...");
                    this.router.navigate(["article/view", this.selectedArticle.Id]);
                };
                return ArticleListComponent;
            }());
            __decorate([
                core_1.Input(),
                __metadata("design:type", String)
            ], ArticleListComponent.prototype, "class", void 0);
            ArticleListComponent = __decorate([
                core_1.Component({
                    selector: "article-list",
                    template: "\n<h3>{{title}}</h3>\n<ul class=\"articles\">\n    <li *ngFor=\"let article of articles\"\n        [class.selected]=\"article === selectedArticle\"\n        (click)=\"onSelect(article)\">\n        <div class=\"title\">{{article.Title}}</div>\n        <div class=\"description\">{{article.Description}}</div>\n    </li>\n</ul>\n    ",
                    styles: ["\n        ul.articles li { \n            cursor: pointer;\n        }\n        ul.articles li.selected { \n            background-color: #dddddd; \n        }\n    "]
                }),
                __metadata("design:paramtypes", [article_service_1.ArticleService, router_1.Router])
            ], ArticleListComponent);
            exports_1("ArticleListComponent", ArticleListComponent);
        }
    };
});
