import { Actions, Display, Dropdown, MaxLength, Pattern, Required } from '@aurochses/angular-forms';

@Actions()
export class PlayerAddModel {
    @Display('Organization')
    @Dropdown()
    organizationId = '';

    @Display('Position')
    @Dropdown()
    positionId = '';

    @Display('First Name')
    @Required()
    @Pattern(/^[A-Za-z0-9\s!"#$%&'()*+,\-.\/:;<=>?[\\@^_`\]{|}~]+$/, 'Use UTF-8 characters from 0x0020 to 0x007E')
    @MaxLength(50)
    firstName = '';

    @Display('Last Name')
    @Required()
    @Pattern(/^[A-Za-z0-9\s!"#$%&'()*+,\-.\/:;<=>?[\\@^_`\]{|}~]+$/, 'Use UTF-8 characters from 0x0020 to 0x007E')
    @MaxLength(50)
    lastName = '';

    @Display('Nickname')
    @Required()
    @Pattern(/^[A-Za-z0-9\s!"#$%&'()*+,\-.\/:;<=>?[\\@^_`\]{|}~]+$/, 'Use UTF-8 characters from 0x0020 to 0x007E')
    @MaxLength(50)
    nickname = '';

    @Display('Age')
    @Required()
    @Pattern(/^[0-9]+$/, 'Value should be numeric')
    age = 0;

    @Display('Country')
    @Required()
    @Pattern(/^[A-Za-z0-9\s!"#$%&'()*+,\-.\/:;<=>?[\\@^_`\]{|}~]+$/, 'Use UTF-8 characters from 0x0020 to 0x007E')
    @MaxLength(50)
    country = '';
}
