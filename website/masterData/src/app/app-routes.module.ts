import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './main/dashboard/dashboard.component';

import { OrganizationListComponent } from './main/organization/organization-list/organization-list.component';
import { PositionListComponent } from './main/position/position-list/position-list.component';

const routes: Routes = [
    {
      path: '',
      component: DashboardComponent,
      data: {
        icon: 'dashboard',
        title: 'MENU.DASHBOARD',
        showMenuDividerAfter: true
      }
    },
    {
      path: 'organizations',
      data: {
        icon: 'people',
        title: 'MENU.ORGANIZATIONS.ORGANIZATIONS',
      },
      children: [
        {
          path: '',
          component: OrganizationListComponent,
          data: {
            icon: '',
            title: 'MENU.ORGANIZATIONS.LIST',
            hideInMenu: true
          },
        }
      ]
    },
    {
      path: 'positions',
      data: {
        icon: 'timeline',
        title: 'MENU.POSITIONS.POSITIONS',
      },
      children: [
        {
          path: '',
          component: PositionListComponent,
          data: {
            icon: '',
            title: 'MENU.POSITIONS.LIST',
            hideInMenu: true
          },
        }
      ]
    },
    {
      path: '**',
      redirectTo: '/list',
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
  