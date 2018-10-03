import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

import { FlexLayoutModule } from '@angular/flex-layout';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBarModule } from '@angular/material/snack-bar';

import { DxDataGridModule } from 'devextreme-angular';

import { TranslateModule } from '@ngx-translate/core';

import { AurTableModule } from '@aurochses/angular-table';
import { AurFormsModule } from '@aurochses/angular-forms';

import { SharedModule } from '../shared/shared.module';

import { DashboardComponent } from './dashboard/dashboard.component';

import { OrganizationListComponent } from './organization/organization-list/organization-list.component';
import { PositionListComponent } from './position/position-list/position-list.component';

import { MatDialogModule, MatSelectModule } from '@angular/material';
import { MatInputModule } from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    DashboardComponent,
    OrganizationListComponent,
    PositionListComponent   
  ],
  imports: [
    CommonModule,
    RouterModule,
    FlexLayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatDividerModule,
    MatIconModule,
    MatInputModule,
    MatSnackBarModule,
    MatDialogModule,
    MatSelectModule,
    FormsModule,
    ReactiveFormsModule,
    DxDataGridModule,
    TranslateModule,
    AurTableModule,
    AurFormsModule,
    SharedModule
  ]
})
export class MainModule { }
