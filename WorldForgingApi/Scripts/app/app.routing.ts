import {ModuleWithProviders} from "@angular/core";
import {Routes, RouterModule} from "@angular/router";

import {AboutComponent} from "./about.component";
import {HomeComponent} from "./home.component";
import {ArticleDetailEditComponent} from "./article-detail-edit.component";
import {ArticleDetailViewComponent} from "./article-detail-view.component";
import {StoryDetailEditComponent} from "./story-detail-edit.component";
import {StoryDetailViewComponent} from "./story-detail-view.component";
import {LoginComponent} from "./login.component";
import {PageNotFoundComponent} from "./page-not-found.component";
import { UserEditComponent } from "./user-edit.component";
import { DummyComponent } from "./dummy.component";

const appRoutes: Routes = [
    {
        path: "",
        component: HomeComponent
    },
    {
        path: "dummy",
        component: DummyComponent
    },
    {
        path: "home",
        redirectTo: ""
    },
    {
        path: "about",
        component: AboutComponent
    },
    {
        path: "login",
        component: LoginComponent
    },
    {
        path: "register",
        component: UserEditComponent
    },
    {
        path: "account",
        component: UserEditComponent
    },
    {
        path: "article/edit/:id",
        component: ArticleDetailEditComponent
    },
    {
        path: "article/view/:id",
        component: ArticleDetailViewComponent
    },
    {
        path: "story/edit/:id",
        component: StoryDetailEditComponent
    },
    {
        path: "story/view/:id",
        component: StoryDetailViewComponent
    },
    {
        path: '**',
        component: PageNotFoundComponent
    }
];

export const AppRoutingProviders: any[] = [
];

export const AppRouting: ModuleWithProviders = RouterModule.forRoot(appRoutes);