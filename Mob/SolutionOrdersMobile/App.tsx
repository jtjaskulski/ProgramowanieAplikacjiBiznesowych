/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 *
 * @format
 */

import {ScrollView, StyleSheet, View,} from 'react-native';
import SimpleForm from "./src/components/SimpleForm.tsx";
import {SafeAreaProvider} from "react-native-safe-area-context";

function App() {
    return (
        <SafeAreaProvider>
            <View style={styles.container}>
                <SimpleForm/>
            </View>
        </SafeAreaProvider>
    );
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#f5f5f5',
    },
});

export default App;
