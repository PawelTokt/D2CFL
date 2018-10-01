import { Actions, Display, Dropdown, Email, MaxLength, Pattern, Required } from '@aurochses/angular-forms';

@Actions()
export class OrganizationAddModel {
  @Display('Name')
  @Required()
  @Pattern(/^[A-Za-z0-9\s!"#$%&'()*+,\-.\/:;<=>?[\\@^_`\]{|}~]+$/, 'Use UTF-8 characters from 0x0020 to 0x007E')
  @MaxLength(50)
  name = '';

  @Display('Abbreviation')
  @Required()
  @Pattern(/^[A-Za-z0-9\s!"#$%&'()*+,\-.\/:;<=>?[\\@^_`\]{|}~]+$/, 'Use UTF-8 characters from 0x0020 to 0x007E')
  @MaxLength(50)
  abbreviation = '';

  @Display('Region')
  @Required()
  @Pattern(/^[A-Za-z0-9\s!"#$%&'()*+,\-.\/:;<=>?[\\@^_`\]{|}~]+$/, 'Use UTF-8 characters from 0x0020 to 0x007E')
  @MaxLength(50)
  region = '';  
}
