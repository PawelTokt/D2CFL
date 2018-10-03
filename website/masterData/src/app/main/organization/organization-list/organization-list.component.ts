import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material';

import { ApiService } from '../../../shared/services/api.service';
import { TranslateService } from '@ngx-translate/core';

import DataSource from 'devextreme/data/data_source';

@Component({
  selector: 'organization-list',
  templateUrl: './organization-list.component.html'
})
export class OrganizationListComponent {
  gridDataSource: any = {};
  currentFilter: any;
  patternText = /^[A-Za-z0-9\s!"#$%&'()*+,\-.\/:;<=>?[\\@^_`\]{|}~ÄäÖöÜüẞß]+$/;

  constructor(private apiService: ApiService, private translate: TranslateService, private snackBar: MatSnackBar) {
    this.gridDataSource = new DataSource({
      load: () => this.apiService.getOrganizations().toPromise(),
      insert: (value) => this.apiService.addOrganization(value).toPromise(),
      update: (key, values) => {
        Object.keys(values).forEach(k => key[k] = values[k]);
        return this.apiService.editOrganization(key.id, key).toPromise().then(
          () => this.translate.get('MESSAGE.EDIT.SUCCESS')
            .subscribe((translation) => this.showEditMessage(translation))
          , error => this.showEditMessage(error.errorMessage)
        );
      },
      remove: (key) => {
        return this.apiService.deleteOrganization(key).toPromise().then(
          () => this.translate.get('MESSAGE.DELETE.SUCCESS')
            .subscribe((translation) => this.showDeleteMessage(translation))
          , error => this.showDeleteMessage(error.errorMessage)
        );
      }
    });
  }

  ngOnInit() { }

  private showEditMessage(message: string): void {
    this.translate.get('MESSAGE.EDIT.CLOSE').subscribe((translation) => {
      const snackBarRef = this.snackBar.open(`${message}`, translation, { duration: 10000 });
      snackBarRef.onAction().subscribe(() => {
        snackBarRef.dismiss();
      });
    });
  }

  private showDeleteMessage(message: string): void {
    this.translate.get('MESSAGE.DELETE.CLOSE').subscribe((translation) => {
      const snackBarRef = this.snackBar.open(`${message}`, translation, { duration: 10000 });
      snackBarRef.onAction().subscribe(() => {
        snackBarRef.dismiss();
      });
    });
  }
}
