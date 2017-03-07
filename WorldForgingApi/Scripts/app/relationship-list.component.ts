import {Component, OnInit} from "@angular/core";
import {Router, ActivatedRoute} from "@angular/router";

import {Article} from "./article";
import {ArticleService} from "./article.service";

import {Story} from "./story";
import {StoryService} from "./story.service";


@Component({
    selector: "relationships",
    template: `
        <div id="relationship-list-component">
          <h4>Relationships</h4>
          <div id="relationship-list">
            <div *ngFor="let relationship of relationships" class="relationship-item" >
              {{relationship.Description}}
            </div>
          </div>
        </div>
    `,
    styles: []
})

export class RelationshipListComponent {
    

    constructor() {}
        

    ngOnInit() {
        
    }

    onInsert(article: Article) {
        
    }

    onUpdate(article: Article) {
     
    }

    onDelete(article: Article) {
        
    }

}
