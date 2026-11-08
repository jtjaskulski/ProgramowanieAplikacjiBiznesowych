import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import ItemsScreen from '../screens/ItemsScreen';
import CreateItemScreen from '../screens/CreateItemScreen';
import EditItemScreen from '../screens/EditItemScreen';
import { RootStackParamList } from './types';

// Tworzenie Stack Navigator
const Stack = createNativeStackNavigator<RootStackParamList>();

function RootNavigator(): React.JSX.Element {
    return (
        <NavigationContainer>
            <Stack.Navigator
                screenOptions={{
                    headerStyle: { backgroundColor: '#007AFF' },
                    headerTintColor: '#fff',
                    headerTitleStyle: { fontWeight: 'bold' },
                }}
            >
                <Stack.Screen
                    name="Items"
                    component={ItemsScreen}
                    options={{ title: 'Produkty' }}
                />
                <Stack.Screen
                    name="CreateItem"
                    component={CreateItemScreen}
                    options={{ title: 'Nowy Produkt' }}
                />
                <Stack.Screen
                    name="EditItem"
                    component={EditItemScreen}
                    options={{ title: 'Edytuj Produkt' }}
                />
            </Stack.Navigator>
        </NavigationContainer>
    );
}

export default RootNavigator;