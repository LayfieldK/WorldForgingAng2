﻿import {Injectable} from '@angular/core';
import {Article} from '../article';
import { Http, Response } from '@angular/http';
import { Observable }     from 'rxjs/Observable';

@Injectable()
export class ArticleListService {
    private articlesUrl = 'http://localhost:51332/api/articleapi';  // URL to web API
    constructor(private http: Http) { }
    getArticles(): Observable<Article[]> {
        return this.http.get(this.articlesUrl)
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