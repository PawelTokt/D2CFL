import { authenticationSettings } from './authentication-settings';
import { templateSettings } from './template-settings';

export const environment = {
  production: false,
  authenticationSettings: authenticationSettings,
  apiUrl: 'http://localhost:8001',
  templateSettings: templateSettings
};
