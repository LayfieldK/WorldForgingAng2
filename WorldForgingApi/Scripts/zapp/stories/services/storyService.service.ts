import {Injectable} from '@angular/core';
import {Story} from '../story';
import { Http, Response } from '@angular/http';
import { Observable }     from 'rxjs/Observable';

@Injectable()
export class StoryService {
    private storyUrl = 'http://localhost:51332/api/stories';  // URL to web API
    constructor(private http: Http) { }
    getStories(): Observable<Story[]> {
        return this.http.get(this.storyUrl)
            .map(this.extractData)
            .catch(this.handleError);
    }
    getStoryDetails(storyId: Number): Observable<Story> {
        return this.http.get(`${this.storyUrl}/${storyId}`)
            .map(this.extractData)
            .catch(this.handleError);
    }
    private extractData(res: Response) {
        let body = res.json();
        return body;
    }
    private handleError(error: any) {
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }
}