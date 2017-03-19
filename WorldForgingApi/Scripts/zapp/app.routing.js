System.register(["@angular/router", "./dashboard/dashboard.component", "./personalCabinet/personalCabinet.component", "./worlds/index/worlds.component", "./worlds/details/worlddetails.component", "./articles/index/articles.component", "./articles/details/articleDetails.component", "./stories/index/stories.component", "./stories/details/storyDetails.component"], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var router_1, dashboard_component_1, personalCabinet_component_1, worlds_component_1, worlddetails_component_1, articles_component_1, articleDetails_component_1, stories_component_1, storyDetails_component_1, appRoutes, routing;
    return {
        setters: [
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (dashboard_component_1_1) {
                dashboard_component_1 = dashboard_component_1_1;
            },
            function (personalCabinet_component_1_1) {
                personalCabinet_component_1 = personalCabinet_component_1_1;
            },
            function (worlds_component_1_1) {
                worlds_component_1 = worlds_component_1_1;
            },
            function (worlddetails_component_1_1) {
                worlddetails_component_1 = worlddetails_component_1_1;
            },
            function (articles_component_1_1) {
                articles_component_1 = articles_component_1_1;
            },
            function (articleDetails_component_1_1) {
                articleDetails_component_1 = articleDetails_component_1_1;
            },
            function (stories_component_1_1) {
                stories_component_1 = stories_component_1_1;
            },
            function (storyDetails_component_1_1) {
                storyDetails_component_1 = storyDetails_component_1_1;
            }
        ],
        execute: function () {
            appRoutes = [
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
            exports_1("routing", routing = router_1.RouterModule.forRoot(appRoutes));
        }
    };
});
