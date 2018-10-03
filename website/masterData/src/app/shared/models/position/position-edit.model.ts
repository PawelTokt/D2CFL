import { Actions, Hidden } from '@aurochses/angular-forms';
import { PositionAddModel } from './position-add.model';

@Actions()
export class PositionEditModel extends PositionAddModel {
    @Hidden()
    id = '';
}
