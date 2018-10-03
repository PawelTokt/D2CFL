import { Actions, Display, Required, Pattern, MaxLength } from '@aurochses/angular-forms';

@Actions()
export class PositionAddModel {
    @Display('Name')
    @Required()
    @Pattern(/^[A-Za-z0-9\s!"#$%&'()*+,\-.\/:;<=>?[\\@^_`\]{|}~]+$/, 'Use UTF-8 characters from 0x0020 to 0x007E')
    @MaxLength(50)
    name = '';

    @Display('Kill Coefficient')
    @Required()
    @Pattern(/^[0-9]+$/, 'Value should be numeric')
    killCoefficient = 0;

    @Display('Assist Coefficient')
    @Required()
    @Pattern(/^[0-9]+$/, 'Value should be numeric')
    assistCoefficient = 0;

    @Display('Death Coefficient')
    @Required()
    @Pattern(/^[0-9]+$/, 'Value should be numeric')
    deathCoefficient = 0;
}
