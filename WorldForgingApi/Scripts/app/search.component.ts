import {Component, Input, OnInit} from "@angular/core";
import {Router} from "@angular/router";
import { Observable }        from 'rxjs/Observable';
import { Subject }           from 'rxjs/Subject';

// Observable class extensions
import 'rxjs/add/observable/of';
// Observable operators
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';

import {Article} from "./article";
import {ArticleService} from "./article.service";

import {Story} from "./story";
import {StoryService} from "./story.service";

@Component({
    selector: "article-search",
    template: `
        <div id="search-component">
          <h4>Search</h4>
          <input #searchBox id="search-box" (keyup)="search(searchBox.value)" />
          <div id="search-results">
            <div *ngIf="(articles | async) && (articles | async)?.length != 0" class="search-result category" >
              Articles
            </div>
            <div *ngFor="let article of articles | async"
                 (click)="gotoArticle(article); searchBox.value = ''; search(searchBox.value);" class="search-result" >
              {{article.Title}}
            </div>
            <div *ngIf="(stories | async) && (stories | async)?.length != 0" class="search-result category" >
              Stories
            </div>
            <div *ngFor="let story of stories | async"
                 (click)="gotoStory(story); searchBox.value = ''; search(searchBox.value);" class="search-result" >
              {{story.Title}}
            </div>
          </div>
        </div>
    `,
    styles: [`
        .search-result{
          border-bottom: 1px solid gray;
          border-left: 1px solid gray;
          border-right: 1px solid gray;
          width:195px;
          height: 32px;
          padding: 5px;
          background-color: white;
          cursor: pointer;
        }
        .search-result.category{
          background-color: lightblue;
        }
        #search-box{
          width: 200px;
          height: 20px;
        }
        #search-component{
          margin-top:46px;
        }
        #search-results{
          position:absolute;
          z-index:99;
        }
    `],
    providers: [ArticleService, StoryService]
})

export class SearchComponent implements OnInit {
    articles: Observable<Article[]>;
    stories: Observable<Story[]>;
    private searchTerms = new Subject<string>();
    constructor(
        private articleService: ArticleService,
        private storyService: StoryService,
        private router: Router) {}
    // Push a search term into the observable stream.
    search(term: string): void {
        this.searchTerms.next(term);
    }
    ngOnInit(): void {
        this.articles = this.searchTerms
            .debounceTime(300)        // wait 300ms after each keystroke before considering the term
            .distinctUntilChanged()   // ignore if next search term is same as previous
            .switchMap(term => term   // switch to new observable each time the term changes
            // return the http search observable
            ? this.articleService.search(term)
            // or the observable of empty heroes if there was no search term
            : Observable.of<Article[]>([]))
            .catch(error => {
            // TODO: add real error handling
            console.log(error);
            return Observable.of<Article[]>([]);
            });
        this.stories = this.searchTerms
            .debounceTime(300)        // wait 300ms after each keystroke before considering the term
            .distinctUntilChanged()   // ignore if next search term is same as previous
            .switchMap(term => term   // switch to new observable each time the term changes
            // return the http search observable
            ? this.storyService.search(term)
            // or the observable of empty heroes if there was no search term
            : Observable.of<Story[]>([]))
            .catch(error => {
            // TODO: add real error handling
            console.log(error);
            return Observable.of<Story[]>([]);
            });
    }
    gotoArticle(article: Article): void {
        //this.router.navigateByUrl('/dummy', { skipLocationChange: true });

        let link = ['article/view', article.Id];
        this.router.navigate(link);
    }
    gotoStory(story: Story): void {
        //this.router.navigateByUrl('/dummy', { skipLocationChange: true });

        let link = ['story/view', story.Id];
        this.router.navigate(link);
    }
}
