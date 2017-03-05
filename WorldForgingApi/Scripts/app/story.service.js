System.register(["@angular/core", "@angular/http", "rxjs/Observable", "./auth.http"], function(exports_1, context_1) {
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
    var core_1, http_1, Observable_1, auth_http_1;
    var StoryService;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (Observable_1_1) {
                Observable_1 = Observable_1_1;
            },
            function (auth_http_1_1) {
                auth_http_1 = auth_http_1_1;
            }],
        execute: function() {
            StoryService = (function () {
                function StoryService(http) {
                    this.http = http;
                    this.baseUrl = "api/stories/"; // web api URL
                }
                // calls the [GET] /api/stories/GetLatest/{n} Web API method to retrieve the latest stories.
                StoryService.prototype.getLatest = function (num) {
                    var url = this.baseUrl + "GetLatest/";
                    if (num != null) {
                        url += num;
                    }
                    return this.http.get(url)
                        .map(function (response) { return response.json(); })
                        .catch(this.handleError);
                };
                // calls the [GET] /api/stories/GetMostViewed/{n} Web API method to retrieve the most viewed stories.
                StoryService.prototype.getMostViewed = function (num) {
                    var url = this.baseUrl + "GetMostViewed/";
                    if (num != null) {
                        url += num;
                    }
                    return this.http.get(url)
                        .map(function (response) { return response.json(); })
                        .catch(this.handleError);
                };
                // calls the [GET] /api/stories/GetRandom/{n} Web API method to retrieve n random stories.
                StoryService.prototype.getRandom = function (num) {
                    var url = this.baseUrl + "GetRandom/";
                    if (num != null) {
                        url += num;
                    }
                    return this.http.get(url)
                        .map(function (response) { return response.json(); })
                        .catch(this.handleError);
                };
                // calls the [GET] /api/stories/{id} Web API method to retrieve the story with the given id.
                StoryService.prototype.get = function (id) {
                    if (id == null) {
                        throw new Error("id is required.");
                    }
                    var url = this.baseUrl + id;
                    return this.http.get(url)
                        .map(function (res) { return res.json(); })
                        .catch(this.handleError);
                };
                StoryService.prototype.search = function (term) {
                    var url = this.baseUrl + "Search/" + term;
                    return this.http
                        .get(url)
                        .map(function (response) { return response.json(); });
                };
                // calls the [POST] /api/stories/ Web API method to add a new story.
                StoryService.prototype.add = function (story) {
                    var url = this.baseUrl;
                    return this.http.post(url, JSON.stringify(story), this.getRequestOptions())
                        .map(function (response) { return response.json(); })
                        .catch(this.handleError);
                };
                // calls the [PUT] /api/stories/{id} Web API method to update an existing story.
                StoryService.prototype.update = function (story) {
                    var url = this.baseUrl + story.Id;
                    return this.http.put(url, JSON.stringify(story), this.getRequestOptions())
                        .map(function (response) { return response.json(); })
                        .catch(this.handleError);
                };
                // calls the [DELETE] /api/stories/{id} Web API method to delete the story with the given id.
                StoryService.prototype.delete = function (id) {
                    var url = this.baseUrl + id;
                    return this.http.delete(url)
                        .catch(this.handleError);
                };
                // returns a viable RequestOptions object to handle Json requests
                StoryService.prototype.getRequestOptions = function () {
                    return new http_1.RequestOptions({
                        headers: new http_1.Headers({
                            "Content-Type": "application/json"
                        })
                    });
                };
                StoryService.prototype.handleError = function (error) {
                    // output errors to the console.
                    console.error(error);
                    return Observable_1.Observable.throw(error.json().error || "Server error");
                };
                StoryService = __decorate([
                    core_1.Injectable(), 
                    __metadata('design:paramtypes', [auth_http_1.AuthHttp])
                ], StoryService);
                return StoryService;
            }());
            exports_1("StoryService", StoryService);
        }
    }
});
