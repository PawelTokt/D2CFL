import { authenticationSettings } from './authentication-settings';
import { templateSettings } from './template-settings';

export const environment = {
  production: false,
  authenticationSettings: authenticationSettings,
  templateSettings: templateSettings,
  masterDataUrl: 'http://localhost:8003',
};
