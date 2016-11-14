import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule, JsonpModule } from '@angular/http';

import { AppComponent }   from './app.component';
import { Dashboard } from './dashboard/dashboard.component'
import { PersonalCabinet } from './personalCabinet/personalCabinet.component'

import { Worlds } from './worlds/index/worlds.component'
import { WorldDetails } from './worlds/details/worlddetails.component'

import { Articles } from './articles/index/articles.component'
import { ArticleDetails } from './articles/details/articleDetails.component'

import { Stories } from './stories/index/stories.component'
import { StoryDetails } from './stories/details/storyDetails.component'

import { routing } from './app.routing';

@NgModule({
    imports: [BrowserModule, routing, HttpModule, JsonpModule],
    declarations: [AppComponent, Dashboard, PersonalCabinet, Worlds, WorldDetails, Articles, ArticleDetails, Stories, StoryDetails],
    bootstrap: [AppComponent]
})

export class AppModule {}