import React from 'react';
import { View, Text, StyleSheet, Image } from 'react-native';

const styles = StyleSheet.create({
    container: {
        flex: 1,
        flexDirection: 'row',
        padding: 15,
        marginLeft:10,
        marginRight:10,
        marginTop: 8,
        marginBottom: 8,
        borderWidth:0.5,
        borderColor:'#990033',
        borderRadius:5,
        backgroundColor: '#FFF',
        elevation: 2,
        alignItems: 'center',
        width:180,
        height:105
    },
    containerBill: {
        flex: 1,
        flexDirection: 'row',
        padding: 15,
        marginLeft:10,
        marginRight:10,
        marginTop: 8,
        marginBottom: 8,
        borderWidth:0.5,
        borderColor:'#990033',
        borderRadius:5,
        backgroundColor: '#FFFFCC',
        elevation: 2,
        alignItems: 'center',
        width:180,
        height:105
    },
    TenBan: {
        fontSize: 18,
        color: '#990033',
        textAlign:'left',
        fontWeight:'bold',
        textAlign:'center'
    },
    TrangThai: {
        flex: 1,
        flexDirection: 'column',
        fontSize: 13,
        fontWeight:'bold',
        textAlign:'center'
    },
    SoChoNgoi: {
        fontSize: 13,
        fontWeight:'bold',
        textAlign:'center'
    },
    SoKhach: {
        fontSize: 13,
        fontWeight:'bold',
        color:'#FF0033',
        textAlign:'center'
    },
    photo: {
        height: 14,
        width: 14,
        marginBottom:5
    },
});

const CustomRow = ({ TenBan, SoChoNgoi, TrangThai }) =>{
    
    if(TrangThai.trim() == 1){
        return (
            <View style={styles.container}>
                {/* {<Image source={{ uri: image_url }} style={styles.photo} />} */}
                <View style={{justifyContent:'center'}}>
                    <Text style={styles.TenBan}>
                        {TenBan.trim()}
                    </Text>
                    <Text style={styles.SoChoNgoi}>
                        SL Chỗ Ngồi : <Text style={styles.SoKhach}>
                    {SoChoNgoi}  <Image source={require('../../img/guest.png') } style={styles.photo}/>
                    </Text>
                    </Text>
                    <Text style={styles.TrangThai}>
                    Trạng Thái    : <Text style={{color:'#FF0033',fontWeight:'bold'}}>Có Khách</Text>
                    </Text>
                </View>
            </View>
        )
    } 
    else if(TrangThai.trim() == 0) {
        return (
            <View style={styles.container}>
                {/* {<Image source={{ uri: image_url }} style={styles.photo} />} */}
                <View style={{justifyContent:'center'}}>
                    <Text style={styles.TenBan}>
                        {TenBan.trim()}
                    </Text>
                    <Text style={styles.SoChoNgoi}>
                        SL Chỗ Ngồi :  <Text style={styles.SoKhach}>
                    {SoChoNgoi}  <Image source={require('../../img/guest.png') } style={styles.photo}/>
                    </Text>
                    </Text>
                    <Text style={styles.TrangThai}>
                        Trạng Thái    : <Text style={{color:'#009966',fontWeight:'bold'}}>Còn Trống</Text>
                    </Text>
                </View>
            </View>
        )
    }
    else if(TrangThai.trim() == 'BT') {
        return (
            <View style={styles.containerBill}>
                {/* {<Image source={{ uri: image_url }} style={styles.photo} />} */}
                <View style={{justifyContent:'center'}}>
                    <Text style={styles.TenBan}>
                    * {TenBan.trim()} *
                    </Text>
                    <Text style={styles.SoChoNgoi}>
                        SL Chỗ Ngồi :  <Text style={styles.SoKhach}>
                    {SoChoNgoi}  <Image source={require('../../img/guest.png') } style={styles.photo}/>
                    </Text>
                    </Text>
                    <Text style={styles.TrangThai}>
                        Trạng Thái    : <Text style={{color:'#9933FF',fontWeight:'bold'}}>Đang Chờ Bill Tạm</Text>
                    </Text>
                </View>
            </View>
        )
    }
    else{
        return (
            <View style={styles.container}>
                {/* {<Image source={{ uri: image_url }} style={styles.photo} />} */}
                <View style={{justifyContent:'center'}}>
                    <Text style={styles.TenBan}>
                        {TenBan.trim()}
                    </Text>
                    <Text style={styles.SoChoNgoi}>
                        SL Chỗ Ngồi :  <Text style={styles.SoKhach}>
                    {SoChoNgoi}  <Image source={require('../../img/guest.png') } style={styles.photo}/>
                    </Text>
                    </Text>
                    <Text style={styles.TrangThai}>
                    Trạng Thái    : <Text style={{color:'blue',fontWeight:'bold'}}>Đã Đặt</Text>
                    </Text>
                </View>
            </View>
        )
    }
};

export default CustomRow;
