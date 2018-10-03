import { Actions, Display, Hidden } from '@aurochses/angular-table';

@Actions()
export class PositionListModel {
    @Hidden()
    id = '';

    @Display('Name')
    name = '';

    @Display('Kill Coefficient')
    killCoefficient = 0;

    @Display('Assist Coefficient')
    assistCoefficient = 0;

    @Display('Death Coefficient')
    deathCoefficient = 0;
}
