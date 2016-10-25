"use strict";
const router_1 = require('@angular/router');
const dashboard_component_1 = require('./dashboard/dashboard.component');
const personalCabinet_component_1 = require('./personalCabinet/personalCabinet.component');
const worlds_component_1 = require('./worlds/index/worlds.component');
const worlddetails_component_1 = require('./worlds/details/worlddetails.component');
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
    }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map