System.register(["@angular/core", "@angular/http", "rxjs/Observable"], function (exports_1, context_1) {
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
    var core_1, http_1, Observable_1, StoryService;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (Observable_1_1) {
                Observable_1 = Observable_1_1;
            }
        ],
        execute: function () {
            StoryService = (function () {
                function StoryService(http) {
                    this.http = http;
                    this.storyUrl = 'http://localhost:51332/api/stories'; // URL to web API
                }
                StoryService.prototype.getStories = function () {
                    return this.http.get(this.storyUrl)
                        .map(this.extractData)
                        .catch(this.handleError);
                };
                StoryService.prototype.getStoryDetails = function (storyId) {
                    return this.http.get(this.storyUrl + "/" + storyId)
                        .map(this.extractData)
                        .catch(this.handleError);
                };
                StoryService.prototype.extractData = function (res) {
                    var body = res.json();
                    return body;
                };
                StoryService.prototype.handleError = function (error) {
                    var errMsg = (error.message) ? error.message :
                        error.status ? error.status + " - " + error.statusText : 'Server error';
                    console.error(errMsg); // log to console instead
                    return Observable_1.Observable.throw(errMsg);
                };
                return StoryService;
            }());
            StoryService = __decorate([
                core_1.Injectable(),
                __metadata("design:paramtypes", [http_1.Http])
            ], StoryService);
            exports_1("StoryService", StoryService);
        }
    };
});
