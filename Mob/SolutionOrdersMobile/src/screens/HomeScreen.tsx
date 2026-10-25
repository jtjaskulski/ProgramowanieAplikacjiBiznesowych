import React from 'react';
import { View, Text, Button, StyleSheet } from 'react-native';
import { NativeStackScreenProps } from '@react-navigation/native-stack';
import {RootStackParamList} from "../navigation/types.ts";


type Props = NativeStackScreenProps<RootStackParamList, 'Home'>;

const HomeScreen: React.FC<Props> = ({ navigation }) => {
    const goToDetails = (): void => {
        // Nawigacja z parametrami
        navigation.navigate('Details', {
            itemId: 123,
            itemName: 'Laptop Dell',
        });
    };

    return (
        <View style={styles.container}>
            <Text style={styles.title}>Ekran Główny</Text>
            <Text style={styles.subtitle}>Witaj w aplikacji!</Text>

            <Button
                title="Przejdź do szczegółów"
                onPress={goToDetails}
            />
        </View>
    );
};

const styles = StyleSheet.create({
    container: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
        padding: 20,
        backgroundColor: '#f5f5f5',
    },
    title: {
        fontSize: 24,
        fontWeight: 'bold',
        marginBottom: 10,
        color: '#333',
    },
    subtitle: {
        fontSize: 16,
        color: '#666',
        marginBottom: 20,
    },
});

export default HomeScreen;