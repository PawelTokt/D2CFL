import { TemplateSettings } from '@aurochses/angular-template';

export const templateSettings: TemplateSettings = {
    toolbar: {
        logo: {
            enable: true,
            url: 'assets/logo.png'
        },
        i18n: {
            enable: true,
            localStorageKey: 'language'
        },
        fullScreen: {
            enable: false
        },
        applications: {
            enable: true,
            url: 'http://localhost:8001/api/applications',
            current: {
                id: '0',
                showInMenu: false
            }
        },
        notifications: {
            enable: false,
            url: ''
        },
        user: {
            enable: true,
            allowSilentSignIn: true
        }
    },
    sidenav: {
        enable: false,
        mode: 'side',
        open: true
    },
    breadcrumb: {
        enable: false,
        homeTitle: ''
    },
    title: {
        enable: false
    }
};
