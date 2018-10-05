import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material';

import { ApiService } from '../../../shared/services/api.service';
import { TranslateService } from '@ngx-translate/core';

import DataSource from 'devextreme/data/data_source';

@Component({
    selector: 'app-player-list',
    templateUrl: './player-list.component.html'
})
export class PlayerListComponent implements OnInit {
    gridDataSource: any = {};
    organizationDropdownValues: any;
    positionDropdownValues: any;
    currentFilter: any;
    patternText = /^[A-Za-z0-9\s!"#$%&'()*+,\-.\/:;<=>?[\\@^_`\]{|}~ÄäÖöÜüẞß]+$/;

    constructor(private apiService: ApiService, private translate: TranslateService, private snackBar: MatSnackBar) {
        this.apiService.getOrganizationDropdownValues().subscribe(data => this.organizationDropdownValues = data);
        this.apiService.getPositionDropDownValues().subscribe(data => this.positionDropdownValues = data);
        this.gridDataSource = new DataSource({
            load: () => this.apiService.getPlayers().toPromise(),
            insert: (value) => this.apiService.addPlayer(value).toPromise().then(
                () => this.translate.get('MESSAGE.ADD.SUCCESS')
                    .subscribe((translation) => this.showAddMessage(translation))
                , error => this.showAddMessage(error.errorMessage)
            ),
            update: (key, values) => {
                Object.keys(values).forEach(k => key[k] = values[k]);
                return this.apiService.editPlayer(key.id, key).toPromise().then(
                    () => this.translate.get('MESSAGE.EDIT.SUCCESS')
                        .subscribe((translation) => this.showEditMessage(translation))
                    , error => this.showEditMessage(error.errorMessage)
                )
            },
            remove: (key) => {
                return this.apiService.deletePlayer(key).toPromise().then(
                    () => this.translate.get('MESSAGE.DELETE.SUCCESS')
                        .subscribe((translation) => this.showDeleteMessage(translation))
                    , error => this.showDeleteMessage(error.errorMessage)
                );
            }
        });
    }

    ngOnInit() { }

    private showAddMessage(message: string): void {
        this.translate.get('MESSAGE.ADD.CLOSE').subscribe((translation) => {
          const snackBarRef = this.snackBar.open(`${message}`, translation, { duration: 5000 });
          snackBarRef.onAction().subscribe(() => {
            snackBarRef.dismiss();
          });
        });
      }
    
      private showEditMessage(message: string): void {
        this.translate.get('MESSAGE.EDIT.CLOSE').subscribe((translation) => {
          const snackBarRef = this.snackBar.open(`${message}`, translation, { duration: 5000 });
          snackBarRef.onAction().subscribe(() => {
            snackBarRef.dismiss();
          });
        });
      }
    
      private showDeleteMessage(message: string): void {
        this.translate.get('MESSAGE.DELETE.CLOSE').subscribe((translation) => {
          const snackBarRef = this.snackBar.open(`${message}`, translation, { duration: 5000 });
          snackBarRef.onAction().subscribe(() => {
            snackBarRef.dismiss();
          });
        });
      }
}