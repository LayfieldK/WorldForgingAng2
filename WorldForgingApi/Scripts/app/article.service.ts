import {Injectable} from "@angular/core";
import {Http, Response, Headers, RequestOptions} from "@angular/http";
import {Observable} from "rxjs/Observable";
import {Article} from "./article";
import {AuthHttp} from "./auth.http";

@Injectable()
export class ArticleService {
    constructor(private http: AuthHttp) { }

    private baseUrl = "api/articles/";  // web api URL

    // calls the [GET] /api/articles/GetLatest/{n} Web API method to retrieve the latest articles.
    getLatest(num?: number) {
        var url = this.baseUrl + "GetLatest/";
        if (num != null) { url += num; }
        return this.http.get(url)
            .map(response => response.json())
            .catch(this.handleError);
    }

    // calls the [GET] /api/articles/GetMostViewed/{n} Web API method to retrieve the most viewed articles.
    getMostViewed(num?: number) {
        var url = this.baseUrl + "GetMostViewed/";
        if (num != null) { url += num; }
        return this.http.get(url)
            .map(response => response.json())
            .catch(this.handleError);
    }

    // calls the [GET] /api/articles/GetRandom/{n} Web API method to retrieve n random articles.
    getRandom(num?: number) {
        var url = this.baseUrl + "GetRandom/";
        if (num != null) { url += num; }
        return this.http.get(url)
            .map(response => response.json())
            .catch(this.handleError);
    }

    search(term: string): Observable<Article[]> {
        var url = this.baseUrl + "Search/" + term;
        return this.http
                   .get(url)
                   .map(response => <Article[]>response.json());
    }

    // calls the [GET] /api/articles/{id} Web API method to retrieve the article with the given id.
    get(id: number) {
        if (id == null) { throw new Error("id is required."); }
        var url = this.baseUrl + id;
        return this.http.get(url)
            .map(res => <Article>res.json())
            .catch(this.handleError);
    }

    // calls the [POST] /api/articles/ Web API method to add a new article.
    add(article: Article) {
        var url = this.baseUrl;
        return this.http.post(url, JSON.stringify(article), this.getRequestOptions())
            .map(response => response.json())
            .catch(this.handleError);
    }

    // calls the [PUT] /api/articles/{id} Web API method to update an existing article.
    update(article: Article) {
        var url = this.baseUrl + article.Id;
        return this.http.put(url, JSON.stringify(article), this.getRequestOptions())
            .map(response => response.json())
            .catch(this.handleError);
    }

    // calls the [DELETE] /api/articles/{id} Web API method to delete the article with the given id.
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
