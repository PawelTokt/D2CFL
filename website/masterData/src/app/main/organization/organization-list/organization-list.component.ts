import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../../shared/services/api.service';
import DataSource from 'devextreme/data/data_source';

@Component({
  selector: 'app-organization-list',
  templateUrl: './organization-list.component.html'
})
export class OrganizationListComponent implements OnInit {

  gridDataSource: any = {};
  logoTypeDropdownValues: any;
  salutationDropdownValues: any;
  currentFilter: any;
  patternText = /^[A-Za-z0-9\s!"#$%&'()*+,\-.\/:;<=>?[\\@^_`\]{|}~ÄäÖöÜüẞß]+$/;

  constructor(private apiService: ApiService) {
     this.gridDataSource = new DataSource({
      load: () => this.apiService.getOrganizations().toPromise(),
      insert: (value) => this.apiService.addOrganization(value).toPromise(),
      update: (key, values) => {
        // current workaround for put!
        Object.keys(values).forEach(k => key[k] = values[k]);
        return this.apiService.editOrganization(key.id, key).toPromise();
      },
      remove: (key)  => {
        return this.apiService.deleteOrganization(key).toPromise();
      }
    });
  }

  ngOnInit() {  }
}
