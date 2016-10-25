import { ModuleWithProviders }  from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { Dashboard } from './dashboard/dashboard.component'
import { PersonalCabinet } from './personalCabinet/personalCabinet.component'
import { Worlds } from './worlds/index/worlds.component'
import { WorldDetails } from './worlds/details/worlddetails.component'

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
    }
];


export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);