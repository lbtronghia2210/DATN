import {StyleSheet } from 'react-native';

const styles = StyleSheet.create({
    container: {
        flex: 1,
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems:'center',
        backgroundColor: '#FFF',
        width:"100%",
    },
    image: {
        resizeMode: "cover",
        justifyContent: "center",
        width:150,
        height:150,
        padding:10,
        borderRadius:5,
        borderWidth:1,
        borderColor:'#990033',
        marginTop:30
    },
    image1: {
        flex: 1,
        resizeMode: "cover",
        justifyContent: "center",
        width: "100%",
        alignItems: 'center'
    },
    logo:{
        flex:2,
        width:"100%",
        backgroundColor:'#FFF',
        alignItems:'center'
    },
    info:{
        flex:3,
        width:"100%",
        backgroundColor:'#FFF',
        alignItems:'center'
    },
    btn:{
        flex:2,
        width:"100%",
        backgroundColor:'#FFF',
        flexDirection:'row',
        alignItems:'center',
        alignSelf:"center",
        
    },
    card_login: {
        height: 'auto',
        margin: 20,
        width: '80%',
        borderRadius:5,
        borderWidth:1,
        borderColor:'#990033',
    },
    txtTen:{
        fontSize:30,
        fontWeight:"bold",
        textAlign:"center",
        color:"#990033",
        marginBottom:10,
    },
    txtGT:{
        fontSize:20,
        fontWeight:"bold",
        textAlign:"center",
        marginLeft: 30
    },
    button: {
        marginTop: 30,
        width:150,
        borderRadius: 5,
        backgroundColor: "#990033",
        alignSelf:'center',
    },
})
export default styles;