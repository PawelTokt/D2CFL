import { Actions, Hidden } from '@aurochses/angular-forms';
import { PlayerAddModel } from './player-add.model';

@Actions()
export class PlayerEditModel extends PlayerAddModel {
    @Hidden()
    id = '';
} 
