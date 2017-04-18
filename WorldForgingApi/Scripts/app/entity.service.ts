import {Injectable} from "@angular/core";
import {Http, Response, Headers, RequestOptions} from "@angular/http";
import {Observable} from "rxjs/Observable";
import {Entity} from "./entity";
import {AuthHttp} from "./auth.http";

@Injectable()
export class EntityService {
    constructor(private http: AuthHttp) { }

    private baseUrl = "api/entities/";  // web api URL

    // calls the [GET] /api/relationships/ Web API method to retrieve all relationships.
    getAll() {
        var url = this.baseUrl;
        return this.http.get(url)
            .map(res => <Entity>res.json())
            .catch(this.handleError);
    }

    // calls the [GET] /api/entities/{id} Web API method to retrieve the entity with the given id.
    get(id: number): Promise<Entity> {
        if (id == null) { throw new Error("id is required."); }
        var url = this.baseUrl + id;
        return this.http.get(url)
            .map(res => <Entity>res.json())
            .catch(this.handleError);
    }

    // calls the [POST] /api/entities/ Web API method to add a new entity.
    add(entity: Entity) {
        var url = this.baseUrl;
        return this.http.post(url, JSON.stringify(entity), this.getRequestOptions())
            .map(response => response.json())
            .catch(this.handleError);
    }

    // calls the [PUT] /api/entities/{id} Web API method to update an existing entity.
    update(entity: Entity) {
        var url = this.baseUrl + entity.Id;
        return this.http.put(url, JSON.stringify(entity), this.getRequestOptions())
            .map(response => response.json())
            .catch(this.handleError);
    }

    // calls the [DELETE] /api/entities/{id} Web API method to delete the entity with the given id.
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
