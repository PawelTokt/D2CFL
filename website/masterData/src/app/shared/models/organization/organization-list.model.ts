import { Actions, Display, Hidden } from '@aurochses/angular-table';

@Actions()
export class OrganizationListModel {
  @Hidden()
  id = '';

  @Display('Name')
  name = '';

  @Display('Abbreviation')
  abbreviation = '';

  @Display('Region')
  region = '';  
}
