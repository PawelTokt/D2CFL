import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './main/home/home.component';

const routes: Routes = [
    {
        path: '',
        component: HomeComponent,
        data: {
            icon: 'home',
            title: 'MENU.HOME'
        }
    },
    {
        path: '**',
        redirectTo: '',
        pathMatch: 'prefix'
    }
];
@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    providers: [ ]
})
export class AppRoutesModule { }
