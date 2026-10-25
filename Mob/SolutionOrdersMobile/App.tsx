/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 *
 * @format
 */

import {ScrollView, StyleSheet, } from 'react-native';
import Greeting from './src/components/Greeting';

function App() {
  return (
        <ScrollView style={styles.container}>
            <Greeting name="Anna" age={25} />
            <Greeting name="Piotr" isVip={true} />
            <Greeting name="Kasia" age={30} isVip={true} />
            <Greeting name="Jan" />
            <Greeting name="Anna" age={25} />
            <Greeting name="Piotr" isVip={true} />
            <Greeting name="Kasia" age={30} isVip={true} />
            <Greeting name="Jan" />
            <Greeting name="Anna" age={25} />
            <Greeting name="Piotr" isVip={true} />
            <Greeting name="Kasia" age={30} isVip={true} />
            <Greeting name="Jan" />
            <Greeting name="Anna" age={25} />
            <Greeting name="Piotr" isVip={true} />
            <Greeting name="Kasia" age={30} isVip={true} />
            <Greeting name="Jan" />
        </ScrollView>
  );
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#f5f5f5',
    },
});

export default App;
