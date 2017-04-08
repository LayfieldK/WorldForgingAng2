System.register(["@angular/core", "@angular/router", "./auth.service", "./article.service", "rxjs/add/operator/mergeMap", "rxjs/add/operator/map"], function (exports_1, context_1) {
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
    var core_1, router_1, auth_service_1, article_service_1, ArticleDetailViewComponent;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (auth_service_1_1) {
                auth_service_1 = auth_service_1_1;
            },
            function (article_service_1_1) {
                article_service_1 = article_service_1_1;
            },
            function (_1) {
            },
            function (_2) {
            }
        ],
        execute: function () {
            ArticleDetailViewComponent = (function () {
                function ArticleDetailViewComponent(authService, articleService, router, activatedRoute) {
                    this.authService = authService;
                    this.articleService = articleService;
                    this.router = router;
                    this.activatedRoute = activatedRoute;
                }
                ArticleDetailViewComponent.prototype.ngOnInit = function () {
                    var _this = this;
                    var id;
                    this.activatedRoute.params
                        .map(function (params) { return +params['id']; })
                        .do(function (id) {
                        console.log(id);
                        if (id) {
                            console.log(id);
                        }
                        else if (id === 0) {
                            console.log("id is 0: switching to edit mode...");
                            _this.router.navigate(["article/edit", 0]);
                        }
                        else {
                            console.log("Invalid id: routing back to home...");
                            _this.router.navigate([""]);
                        }
                    })
                        .filter(function (id) { return id > 0; })
                        .switchMap(function (id) { return _this.articleService.get(id); })
                        .subscribe(function (article) {
                        _this.article = article;
                        console.log(article);
                    });
                };
                ArticleDetailViewComponent.prototype.onArticleDetailEdit = function (article) {
                    this.router.navigate(["article/edit", article.Id]);
                    return false;
                };
                ArticleDetailViewComponent.prototype.onBack = function () {
                    this.router.navigate(['']);
                };
                return ArticleDetailViewComponent;
            }());
            ArticleDetailViewComponent = __decorate([
                core_1.Component({
                    selector: "article-detail-view",
                    template: "\n<div *ngIf=\"article\">\n    <h2>\n        <a href=\"javascript:void(0)\" (click)=\"onBack()\">&laquo; Back to Home</a>\n    </h2>\n    <div class=\"article-container\">\n        <ul class=\"nav nav-tabs\">\n            <li *ngIf=\"authService.isLoggedIn()\" role=\"presentation\">\n                <a href=\"javascript:void(0)\" (click)=\"onArticleDetailEdit(article)\">Edit</a>\n            </li>\n            <li role=\"presentation\" class=\"active\">\n                <a href=\"javascript:void(0)\">View</a>\n            </li>\n        </ul>\n        <div class=\"panel panel-default\">\n            <div class=\"panel-body\">\n                <div class=\"article-image-panel\">\n                    <img src=\"/img/article-image-sample.png\" alt=\"{{article.Title}}\" />\n                    <div class=\"caption\">Sample image with caption.</div>\n                </div>\n                <h3>{{article.Title}}</h3>\n                <p>{{article.Description}}</p>\n                <p>{{article.Text}}</p>\n                <p *ngFor=\"let eRelationship of article.EntityRelationships\">{{eRelationship.Entity1Name}} {{eRelationship.Relationship.Description}} {{eRelationship.Entity2Name}}</p>\n            </div>\n        </div>\n    </div>\n</div>\n    ",
                    styles: []
                }),
                __metadata("design:paramtypes", [auth_service_1.AuthService,
                    article_service_1.ArticleService,
                    router_1.Router,
                    router_1.ActivatedRoute])
            ], ArticleDetailViewComponent);
            exports_1("ArticleDetailViewComponent", ArticleDetailViewComponent);
        }
    };
});
