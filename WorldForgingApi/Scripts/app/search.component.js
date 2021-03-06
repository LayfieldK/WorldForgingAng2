System.register(["@angular/core", "@angular/router", "rxjs/Observable", "rxjs/Subject", "rxjs/add/observable/of", "rxjs/add/operator/catch", "rxjs/add/operator/debounceTime", "rxjs/add/operator/distinctUntilChanged", "./article.service", "./story.service"], function (exports_1, context_1) {
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
    var core_1, router_1, Observable_1, Subject_1, article_service_1, story_service_1, SearchComponent;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (Observable_1_1) {
                Observable_1 = Observable_1_1;
            },
            function (Subject_1_1) {
                Subject_1 = Subject_1_1;
            },
            function (_1) {
            },
            function (_2) {
            },
            function (_3) {
            },
            function (_4) {
            },
            function (article_service_1_1) {
                article_service_1 = article_service_1_1;
            },
            function (story_service_1_1) {
                story_service_1 = story_service_1_1;
            }
        ],
        execute: function () {
            SearchComponent = (function () {
                function SearchComponent(articleService, storyService, router) {
                    this.articleService = articleService;
                    this.storyService = storyService;
                    this.router = router;
                    this.searchTerms = new Subject_1.Subject();
                }
                // Push a search term into the observable stream.
                SearchComponent.prototype.search = function (term) {
                    this.searchTerms.next(term);
                };
                SearchComponent.prototype.ngOnInit = function () {
                    var _this = this;
                    this.articles = this.searchTerms
                        .debounceTime(300) // wait 300ms after each keystroke before considering the term
                        .distinctUntilChanged() // ignore if next search term is same as previous
                        .switchMap(function (term) { return term // switch to new observable each time the term changes
                        ? _this.articleService.search(term)
                        : Observable_1.Observable.of([]); })
                        .catch(function (error) {
                        // TODO: add real error handling
                        console.log(error);
                        return Observable_1.Observable.of([]);
                    });
                    this.stories = this.searchTerms
                        .debounceTime(300) // wait 300ms after each keystroke before considering the term
                        .distinctUntilChanged() // ignore if next search term is same as previous
                        .switchMap(function (term) { return term // switch to new observable each time the term changes
                        ? _this.storyService.search(term)
                        : Observable_1.Observable.of([]); })
                        .catch(function (error) {
                        // TODO: add real error handling
                        console.log(error);
                        return Observable_1.Observable.of([]);
                    });
                };
                SearchComponent.prototype.gotoArticle = function (article) {
                    //this.router.navigateByUrl('/dummy', { skipLocationChange: true });
                    var link = ['article/view', article.Id];
                    this.router.navigate(link);
                };
                SearchComponent.prototype.gotoStory = function (story) {
                    //this.router.navigateByUrl('/dummy', { skipLocationChange: true });
                    var link = ['story/view', story.Id];
                    this.router.navigate(link);
                };
                return SearchComponent;
            }());
            SearchComponent = __decorate([
                core_1.Component({
                    selector: "article-search",
                    template: "\n        <div id=\"search-component\">\n          <h4>Search</h4>\n          <input #searchBox id=\"search-box\" (keyup)=\"search(searchBox.value)\" />\n          <div id=\"search-results\">\n            <div *ngIf=\"(articles | async) && (articles | async)?.length != 0\" class=\"search-result category\" >\n              Articles\n            </div>\n            <div *ngFor=\"let article of articles | async\"\n                 (click)=\"gotoArticle(article); searchBox.value = ''; search(searchBox.value);\" class=\"search-result\" >\n              {{article.Title}}\n            </div>\n            <div *ngIf=\"(stories | async) && (stories | async)?.length != 0\" class=\"search-result category\" >\n              Stories\n            </div>\n            <div *ngFor=\"let story of stories | async\"\n                 (click)=\"gotoStory(story); searchBox.value = ''; search(searchBox.value);\" class=\"search-result\" >\n              {{story.Title}}\n            </div>\n          </div>\n        </div>\n    ",
                    styles: ["\n        .search-result{\n          border-bottom: 1px solid gray;\n          border-left: 1px solid gray;\n          border-right: 1px solid gray;\n          width:195px;\n          height: 32px;\n          padding: 5px;\n          background-color: white;\n          cursor: pointer;\n        }\n        .search-result.category{\n          background-color: lightblue;\n        }\n        #search-box{\n          width: 200px;\n          height: 20px;\n        }\n        #search-component{\n          margin-top:46px;\n        }\n        #search-results{\n          position:absolute;\n          z-index:99;\n        }\n    "],
                    providers: [article_service_1.ArticleService, story_service_1.StoryService]
                }),
                __metadata("design:paramtypes", [article_service_1.ArticleService,
                    story_service_1.StoryService,
                    router_1.Router])
            ], SearchComponent);
            exports_1("SearchComponent", SearchComponent);
        }
    };
});
