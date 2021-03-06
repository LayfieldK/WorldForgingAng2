System.register(["@angular/core", "@angular/router", "./article", "./auth.service", "./article.service"], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, router_1, article_1, auth_service_1, article_service_1;
    var ArticleDetailEditComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (article_1_1) {
                article_1 = article_1_1;
            },
            function (auth_service_1_1) {
                auth_service_1 = auth_service_1_1;
            },
            function (article_service_1_1) {
                article_service_1 = article_service_1_1;
            }],
        execute: function() {
            ArticleDetailEditComponent = (function () {
                function ArticleDetailEditComponent(authService, articleService, router, activatedRoute) {
                    this.authService = authService;
                    this.articleService = articleService;
                    this.router = router;
                    this.activatedRoute = activatedRoute;
                }
                ArticleDetailEditComponent.prototype.ngOnInit = function () {
                    var _this = this;
                    if (!this.authService.isLoggedIn()) {
                        this.router.navigate([""]);
                    }
                    var id = +this.activatedRoute.snapshot.params["id"];
                    if (id) {
                        this.articleService.get(id).subscribe(function (article) { return _this.article = article; });
                    }
                    else if (id === 0) {
                        console.log("id is 0: adding a new article...");
                        this.article = new article_1.Article(0, "New Article", null);
                    }
                    else {
                        console.log("Invalid id: routing back to home...");
                        this.router.navigate([""]);
                    }
                };
                ArticleDetailEditComponent.prototype.onInsert = function (article) {
                    var _this = this;
                    this.articleService.add(article).subscribe(function (data) {
                        _this.article = data;
                        console.log("Article " + _this.article.Id + " has been added.");
                        _this.router.navigate([""]);
                    }, function (error) { return console.log(error); });
                };
                ArticleDetailEditComponent.prototype.onUpdate = function (article) {
                    var _this = this;
                    this.articleService.update(article).subscribe(function (data) {
                        _this.article = data;
                        console.log("Article " + _this.article.Id + " has been updated.");
                        _this.router.navigate(["article/view", _this.article.Id]);
                    }, function (error) { return console.log(error); });
                };
                ArticleDetailEditComponent.prototype.onDelete = function (article) {
                    var _this = this;
                    var id = article.Id;
                    this.articleService.delete(id).subscribe(function (data) {
                        console.log("Article " + id + " has been deleted.");
                        _this.router.navigate([""]);
                    }, function (error) { return console.log(error); });
                };
                ArticleDetailEditComponent.prototype.onBack = function () {
                    this.router.navigate([""]);
                };
                ArticleDetailEditComponent.prototype.onArticleDetailView = function (article) {
                    this.router.navigate(["article/view", article.Id]);
                };
                ArticleDetailEditComponent = __decorate([
                    core_1.Component({
                        selector: "article-detail-edit",
                        template: "\n<div *ngIf=\"article\">\n    <h2>\n        <a href=\"javascript:void(0)\" (click)=\"onBack()\">\n            &laquo; Back to Home\n        </a>\n    </h2>\n    <div class=\"article-container\">\n        <ul class=\"nav nav-tabs\">\n            <li role=\"presentation\" class=\"active\">\n                <a href=\"javascript:void(0)\">Edit</a>\n            </li>\n            <li role=\"presentation\" *ngIf=\"article.Id != 0\">\n                <a href=\"javascript:void(0)\" (click)=\"onArticleDetailView(article)\">View</a>\n            </li>\n        </ul>\n        <div class=\"panel panel-default\">\n            <div class=\"panel-body\">\n                <form class=\"article-detail-edit\" #thisForm=\"ngForm\">\n                    <h3>\n                        {{article.Title}}\n                        <span class=\"empty-field\" [hidden]=\"dTitle.valid\">\n                            Empty Title\n                        </span>\n                    </h3>\n                    <div class=\"form-group has-feedback\" [ngClass]=\"{'has-success': dTitle.valid, 'has-error': !dTitle.valid}\">\n                        <label for=\"input-title\">Title</label>\n                        <input id=\"input-title\" name=\"input-title\" type=\"text\" class=\"form-control\" [(ngModel)]=\"article.Title\" placeholder=\"Insert the title...\" required #dTitle=\"ngModel\" />\n                        <span class=\"glyphicon form-control-feedback\" aria-hidden=\"true\" [ngClass]=\"{'glyphicon-ok': dTitle.valid, 'glyphicon-remove': !dTitle.valid}\"></span>\n                        <div [hidden]=\"dTitle.valid\" class=\"alert alert-danger\">\n                            You need to enter a valid Title.\n                        </div>\n                    </div>\n                    <div class=\"form-group\">\n                        <label for=\"input-description\">Description</label>\n                        <textarea id=\"input-description\" name=\"input-description\" class=\"form-control\" [(ngModel)]=\"article.Description\" placeholder=\"Insert a suitable description...\" required></textarea>\n                    </div>\n                    <div class=\"form-group\">\n                        <label for=\"input-text\">Text</label>\n                        <textarea id=\"input-text\" name=\"input-text\" class=\"form-control\" [(ngModel)]=\"article.Text\" placeholder=\"Insert a suitable description...\"></textarea>\n                    </div>\n                    <div *ngIf=\"article.Id == 0\" class=\"commands insert\">\n                        <input type=\"button\" class=\"btn btn-primary\" value=\"Save\" (click)=\"onInsert(article)\" />\n                        <input type=\"button\" class=\"btn btn-default\" value=\"Cancel\" (click)=\"onBack()\" />\n                    </div>\n                    <div *ngIf=\"article.Id != 0\" class=\"commands update\">\n                        <input type=\"button\" class=\"btn btn-primary\" value=\"Update\" (click)=\"onUpdate(article)\" />\n                        <input type=\"button\" class=\"btn btn-danger\" value=\"Delete\" (click)=\"onDelete(article)\" />\n                        <input type=\"button\" class=\"btn btn-default\" value=\"Cancel\" (click)=\"onArticleDetailView(article)\" />\n                    </div>\n                </form>\n            </div>\n        </div>\n    </div>\n</div>\n    ",
                        styles: []
                    }), 
                    __metadata('design:paramtypes', [auth_service_1.AuthService, article_service_1.ArticleService, router_1.Router, router_1.ActivatedRoute])
                ], ArticleDetailEditComponent);
                return ArticleDetailEditComponent;
            }());
            exports_1("ArticleDetailEditComponent", ArticleDetailEditComponent);
        }
    }
});
