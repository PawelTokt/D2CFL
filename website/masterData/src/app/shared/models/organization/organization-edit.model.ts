import { Actions, Hidden } from '@aurochses/angular-forms';
import { OrganizationAddModel } from './organization-add.model';

@Actions()
export class OrganizationEditModel extends OrganizationAddModel {
  @Hidden()
  id = '';
}
