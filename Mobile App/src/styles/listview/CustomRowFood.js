import React from 'react';
import { View, Text, StyleSheet, Image } from 'react-native';

const styles = StyleSheet.create({
    container: {
        flex: 1,
        flexDirection: 'row',
        padding: 10,
        marginLeft:16,
        marginRight:16,
        marginTop: 8,
        marginBottom: 8,
        borderRadius: 5,
        borderWidth:0.5,
        borderColor:'#990033',
        backgroundColor: '#FFF',
        elevation: 2,
        borderRadius : 5
    },
    TenMon: {
        fontSize: 18,
        color: '#990033',
        textAlign:'center',
        fontWeight:'bold'
    },
    container_text: {
        flex: 1,
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems:'center',
    },
    DonGia: {
        fontSize: 14,
        color: '#000',
        fontWeight:"bold",
        textAlign:'center',
        marginLeft:55
    },
    photo:{
        height:80,
        width: 100,
        borderRadius:10,
    }
});
const CustomRow = ({ TenMon, DVT, DonGia,HinhAnh }) => (
    <View style={styles.container} >
        <Image style={styles.photo} 
                     source={require('../../img/bundauganh.jpg')} />
        <View style={styles.container_text}>
            <Text style={styles.TenMon}   >
                {TenMon.trim()}
            </Text>
            <Text style={styles.DonGia}>
                Giá : {DonGia} <Text style={{fontSize:10}}>VNĐ</Text>/{DVT}
            </Text>
        </View>
    </View>
);

export default CustomRow;
