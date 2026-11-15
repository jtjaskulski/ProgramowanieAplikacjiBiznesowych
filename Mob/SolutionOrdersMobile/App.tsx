import React from 'react';
import { View, StatusBar, useColorScheme, StyleSheet } from 'react-native';
import { SafeAreaProvider, useSafeAreaInsets } from 'react-native-safe-area-context';
import { ItemsProvider } from './src/context/ItemsContext';
import RootNavigator from './src/navigation/RootNavigator';
import {CartProvider} from "./src/context/CartContext.tsx";

function App(): React.JSX.Element {
    const isDarkMode = useColorScheme() === 'dark';

    return (
        <SafeAreaProvider>
            <StatusBar barStyle={isDarkMode ? 'light-content' : 'dark-content'} />
            <ItemsProvider>
                <CartProvider>
                <AppContent />
                </CartProvider>
            </ItemsProvider>
        </SafeAreaProvider>
    );
}

function AppContent(): React.JSX.Element {
    const insets = useSafeAreaInsets();

    return (
        <View style={[styles.container, { paddingTop: insets.top }]}>
            <RootNavigator />
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
    },
});

export default App;