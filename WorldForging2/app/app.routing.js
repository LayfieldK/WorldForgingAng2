"use strict";
const router_1 = require('@angular/router');
const dashboard_component_1 = require('./dashboard/dashboard.component');
const personalCabinet_component_1 = require('./personalCabinet/personalCabinet.component');
const worlds_component_1 = require('./worlds/index/worlds.component');
const worlddetails_component_1 = require('./worlds/details/worlddetails.component');
const articles_component_1 = require('./articles/index/articles.component');
const articleDetails_component_1 = require('./articles/details/articleDetails.component');
const stories_component_1 = require('./stories/index/stories.component');
const storyDetails_component_1 = require('./stories/details/storyDetails.component');
const appRoutes = [
    {
        path: '',
        component: dashboard_component_1.Dashboard
    },
    {
        path: 'personal',
        component: personalCabinet_component_1.PersonalCabinet
    },
    {
        path: 'worlds',
        component: worlds_component_1.Worlds
    },
    {
        path: 'worlds/:id',
        component: worlddetails_component_1.WorldDetails
    },
    {
        path: 'article',
        component: articles_component_1.Articles
    },
    {
        path: 'article/:id',
        component: articleDetails_component_1.ArticleDetails
    },
    {
        path: 'story',
        component: stories_component_1.Stories
    },
    {
        path: 'story/:id',
        component: storyDetails_component_1.StoryDetails
    }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map