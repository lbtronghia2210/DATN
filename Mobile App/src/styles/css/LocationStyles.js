import {StyleSheet } from 'react-native';
const styles = StyleSheet.create({
    container: {
      flex: 1,
      backgroundColor: '#FCFCFC',
      alignItems:'center',
      justifyContent:'center'
    },
    screenview: 
    { 
      backgroundColor: '#FCFCFC',
      flexDirection: 'row',
      justifyContent: 'center',
      alignItems: 'center',
      margin:8,
    },
    itemSelect: {
      backgroundColor: 'white',
      borderRadius: 5,
      paddingHorizontal: 10,
      paddingVertical: 12,
      marginRight: 10,
      marginLeft:5,
      marginBottom:10,
      width:190,
      justifyContent: 'center', 
      alignItems: 'center',
      borderWidth:0.5,
      borderColor:'#990033'
    },
    itemUnselect: {
      backgroundColor: '#FCFCFC',
      borderRadius: 5,
      paddingHorizontal: 10,
      paddingVertical: 12,
      marginRight: 10,
      marginLeft:5,
      marginBottom:10,
      width:190,
      justifyContent: 'center', 
      alignItems: 'center',
      borderWidth:0.5,
      borderColor:'red'
    },
    btntxt: {
      textAlign: "center",
      color: '#990033',
      fontSize: 17,
      fontWeight:'bold',
      marginLeft:58
    },
    button: {
      margin: 10,
      borderRadius: 5,
      backgroundColor: "#990033",
      
  },
    touch:{
      padding:0,
      margin:1,
      alignItems:'center',
      alignContent:'center',
      
    },
  });
export default styles;
  