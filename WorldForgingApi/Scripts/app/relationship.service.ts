import {Injectable} from "@angular/core";
import {Http, Response, Headers, RequestOptions} from "@angular/http";
import {Observable} from "rxjs/Observable";
import {Relationship} from "./relationship";
import {AuthHttp} from "./auth.http";

@Injectable()
export class RelationshipService {
    constructor(private http: AuthHttp) { }

    private baseUrl = "api/relationships/";  // web api URL


    // calls the [GET] /api/relationships/ Web API method to retrieve all relationships.
    getAll() {
        var url = this.baseUrl;
        return this.http.get(url)
            .map(res => <Relationship>res.json())
            .catch(this.handleError);
    }
    
    // calls the [GET] /api/relationships/{id} Web API method to retrieve the relationship with the given id.
    get(id: number) {
        if (id == null) { throw new Error("id is required."); }
        var url = this.baseUrl + id;
        return this.http.get(url)
            .map(res => <Relationship>res.json())
            .catch(this.handleError);
    }

    search(term: string): Observable<Relationship[]> {
        var url = this.baseUrl + "Search/" + term;
        return this.http
                   .get(url)
            .map(response => <Relationship[]>response.json());
    }

    // calls the [POST] /api/stories/ Web API method to add a new storelationshipry.
    add(relationship: Relationship) {
        var url = this.baseUrl;
        return this.http.post(url, JSON.stringify(relationship), this.getRequestOptions())
            .map(response => response.json())
            .catch(this.handleError);
    }

    // calls the [PUT] /api/stories/{id} Web API method to update an existing relationship.
    update(relationship: Relationship) {
        var url = this.baseUrl + relationship.Id;
        return this.http.put(url, JSON.stringify(relationship), this.getRequestOptions())
            .map(response => response.json())
            .catch(this.handleError);
    }

    // calls the [DELETE] /api/stories/{id} Web API method to delete the relationship with the given id.
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
