import {StyleSheet } from 'react-native';
const styles = StyleSheet.create({
    container: {
        flex: 1,
        flexDirection: 'column',
        justifyContent: 'center',
        backgroundColor: '#FFF'
    },
    logo: {
        width: '100%',
        flexDirection: 'column',
        justifyContent: 'center',
        backgroundColor: '#FFF',
        margin: 39
    },
    login: {
        flex: 4,
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center',
        borderTopRightRadius: 20,
        borderTopLeftRadius: 20,
        backgroundColor: "#990033",
        marginTop: 10,
    },
    card_login: {
        borderRadius: 5,
        borderWidth: 1,
        height: 'auto',
        margin: 20,
        width: '80%',
        borderColor: '#990033',

    },
    card_logo: {
        width: '95%',
        borderRadius: 20,
        borderWidth: 0.5,
        borderColor: "#990033",
        margin: 20,
        padding: 20
    },
    button: {
        marginTop: 10,
        borderRadius: 5,
        backgroundColor: "#990033",
    },
    image: {
        flex: 1,
        resizeMode: "cover",
        justifyContent: "center",
        width: "100%",
        alignItems: 'center'
    },
})
export default styles;