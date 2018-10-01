import { AuthenticationSettings } from '@aurochses/angular-auth';

export const authenticationSettings: AuthenticationSettings = {
  authority: '',
  client_id: '',
  redirect_uri: '',
  post_logout_redirect_uri: '',
  response_type: '',
  scope: '',
  silent_redirect_uri: '',
  automaticSilentRenew: false,
  accessTokenExpiringNotificationTime: 240,
  filterProtocolClaims: false,
  loadUserInfo: false
};
