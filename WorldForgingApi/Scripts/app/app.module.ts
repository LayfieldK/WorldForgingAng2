﻿///<reference path="../../typings/index.d.ts"/>
import {NgModule} from "@angular/core";
import {BrowserModule} from "@angular/platform-browser";
import {HttpModule} from "@angular/http";
import { FormsModule, ReactiveFormsModule} from "@angular/forms";
import { RouterModule } from "@angular/router";
import "rxjs/Rx";

import {AboutComponent} from "./about.component";
import {AppComponent} from "./app.component";
import {HomeComponent} from "./home.component";
import {ArticleDetailViewComponent} from "./article-detail-view.component";
import { ArticleDetailEditComponent } from "./article-detail-edit.component";
import { EntityRelationshipEditComponent } from "./entity-relationship-edit.component";
import {ArticleListComponent} from "./article-list.component";
import {StoryDetailViewComponent} from "./story-detail-view.component";
import {StoryDetailEditComponent} from "./story-detail-edit.component";
import {StoryListComponent} from "./story-list.component";
import {LoginComponent} from "./login.component";
import {PageNotFoundComponent} from "./page-not-found.component";
import {UserEditComponent} from "./user-edit.component";
import { SearchComponent } from "./search.component";
import { DummyComponent } from "./dummy.component";

import {AppRouting} from "./app.routing";
import {AuthHttp} from "./auth.http";
import {AuthService} from "./auth.service";
import {ArticleService} from "./article.service";
import { StoryService } from "./story.service";
import { RelationshipService } from "./relationship.service";
import { EntityService } from "./entity.service";

@NgModule({
    // directives, components, and pipes
    declarations: [
        AboutComponent,
        AppComponent,
        HomeComponent,
        ArticleListComponent,
        ArticleDetailViewComponent,
        ArticleDetailEditComponent,
        EntityRelationshipEditComponent,
        StoryListComponent,
        StoryDetailViewComponent,
        StoryDetailEditComponent,
        LoginComponent,
        PageNotFoundComponent,
        UserEditComponent,
        SearchComponent,
        DummyComponent
    ],
    // modules
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule, 
        AppRouting
    ],
    // providers
    providers: [
        AuthHttp,
        ArticleService,
        StoryService,
        RelationshipService,
        EntityService,
        AuthService
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }
