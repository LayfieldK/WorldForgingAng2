import { ModuleWithProviders }  from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { Dashboard } from './dashboard/dashboard.component'
import { PersonalCabinet } from './personalCabinet/personalCabinet.component'

import { Worlds } from './worlds/index/worlds.component'
import { WorldDetails } from './worlds/details/worlddetails.component'

import { Articles } from './articles/index/articles.component'
import { ArticleDetails } from './articles/details/articleDetails.component'

import { Stories } from './stories/index/stories.component'
import { StoryDetails } from './stories/details/storyDetails.component'

const appRoutes: Routes = [
    {
        path: '',
        component: Dashboard
    },
    {
        path: 'personal',
        component: PersonalCabinet
    },
    {
        path: 'worlds',
        component: Worlds
    },
    {
        path: 'worlds/:id',
        component: WorldDetails
    },
    {
        path: 'article',
        component: Articles
    },
    {
        path: 'article/:id',
        component: ArticleDetails
    },
    {
        path: 'story',
        component: Stories
    },
    {
        path: 'stories/:id',
        component: StoryDetails
    }
];


export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);