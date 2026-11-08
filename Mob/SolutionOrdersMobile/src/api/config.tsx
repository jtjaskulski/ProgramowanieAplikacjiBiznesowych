import { Platform } from 'react-native';

const getBaseUrl = (): string => {
    if (__DEV__) {
        // Development
        if (Platform.OS === 'android') {
            return 'http://10.0.2.2:5000/api';
        } else if (Platform.OS === 'ios') {
            return 'http://localhost:5000/api';
        }
    }

    // Production
    return 'https://your-production-api.com/api';
};

export const API_BASE_URL = getBaseUrl();