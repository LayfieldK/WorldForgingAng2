import {Injectable} from "@angular/core";
import {Http, Response, Headers, RequestOptions} from "@angular/http";
import {Observable} from "rxjs/Observable";
import {Story} from "./story";
import {AuthHttp} from "./auth.http";

@Injectable()
export class StoryService {
    constructor(private http: AuthHttp) { }

    private baseUrl = "api/stories/";  // web api URL

    // calls the [GET] /api/stories/GetLatest/{n} Web API method to retrieve the latest stories.
    getLatest(num?: number) {
        var url = this.baseUrl + "GetLatest/";
        if (num != null) { url += num; }
        return this.http.get(url)
            .map(response => response.json())
            .catch(this.handleError);
    }

    // calls the [GET] /api/stories/GetMostViewed/{n} Web API method to retrieve the most viewed stories.
    getMostViewed(num?: number) {
        var url = this.baseUrl + "GetMostViewed/";
        if (num != null) { url += num; }
        return this.http.get(url)
            .map(response => response.json())
            .catch(this.handleError);
    }

    // calls the [GET] /api/stories/GetRandom/{n} Web API method to retrieve n random stories.
    getRandom(num?: number) {
        var url = this.baseUrl + "GetRandom/";
        if (num != null) { url += num; }
        return this.http.get(url)
            .map(response => response.json())
            .catch(this.handleError);
    }

    // calls the [GET] /api/stories/{id} Web API method to retrieve the story with the given id.
    get(id: number) {
        if (id == null) { throw new Error("id is required."); }
        var url = this.baseUrl + id;
        return this.http.get(url)
            .map(res => <Story>res.json())
            .catch(this.handleError);
    }

    // calls the [POST] /api/stories/ Web API method to add a new story.
    add(story: Story) {
        var url = this.baseUrl;
        return this.http.post(url, JSON.stringify(story), this.getRequestOptions())
            .map(response => response.json())
            .catch(this.handleError);
    }

    // calls the [PUT] /api/stories/{id} Web API method to update an existing story.
    update(story: Story) {
        var url = this.baseUrl + story.Id;
        return this.http.put(url, JSON.stringify(story), this.getRequestOptions())
            .map(response => response.json())
            .catch(this.handleError);
    }

    // calls the [DELETE] /api/stories/{id} Web API method to delete the story with the given id.
    delete(id: number) {
        var url = this.baseUrl + id;
        return this.http.delete(url)
            .catch(this.handleError);
    }

    // returns a viable RequestOptions object to handle Json requests
    private getRequestOptions() {
        return new RequestOptions({
            headers: new Headers({
                "Content-Type": "application/json"
            })
        });
    }

    private handleError(error: Response) {
        // output errors to the console.
        console.error(error);
        return Observable.throw(error.json().error || "Server error");
    }
}
