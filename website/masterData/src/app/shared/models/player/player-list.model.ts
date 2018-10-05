import { Actions, Display, Hidden } from '@aurochses/angular-table';

@Actions()
export class PlayerListModel {
    @Hidden()
    id = '';

    @Hidden()
    organizationId = '';

    @Display('Organization')
    organizationName = '';

    @Hidden()
    positionId = '';

    @Display('Position')
    positionName = '';

    @Display('First Name')
    firstName = '';
    
    @Display('Last Name')
    lastName = '';

    @Display('Nickname')
    nickname = '';

    @Display('Age')
    age = 0;

    @Display('Country')
    country = '';
}
