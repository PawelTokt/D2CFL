import { Actions, Display, Hidden } from '@aurochses/angular-table';

@Actions()
export class OrganizationListModel {
  @Hidden()
  id = '';

  @Display('Name')
  name = '';

  @Display('ShortName')
  shortName = '';

  @Display('Region')
  region = '';  
}
