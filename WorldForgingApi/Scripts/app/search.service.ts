import { Injectable } from '@angular/core';
import { Http }       from '@angular/http';
import { Observable }     from 'rxjs/Observable';
import 'rxjs/add/operator/map';
//import { Story }           from './story';
import { Article }           from './article';

@Injectable()
export class SearchService {
  constructor(private http: Http) {}
  search(term: string): Observable<Article[]> {
    return this.http
               .get(`app/articles/?name=${term}`)
               .map(response => response.json().data as Article[]);
  }
}
