import {Injectable} from '@angular/core';
import {World} from '../worldListService/world';
import { Http, Response } from '@angular/http';
import { Observable }     from 'rxjs/Observable';

@Injectable()
export class WorldListService {
    private worldsUrl = 'http://localhost:51332/api/worldsapi';  // URL to web API
    constructor(private http: Http) { }
    getWorlds(): Observable<World[]> {
        return this.http.get(this.worldsUrl)
            .map(this.extractData)
            .catch(this.handleError);
    }
    private extractData(res: Response) {
        let body = res.json();
        return body;
    }
    private handleError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }
}