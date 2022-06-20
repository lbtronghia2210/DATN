import React from 'react';
import { View, Text, StyleSheet, Image } from 'react-native';

const styles = StyleSheet.create({
    container: {
        flex: 1,
        flexDirection: 'row',
        margin: 5,
        borderRadius: 10,
        backgroundColor: '#FFF',
        justifyContent: 'center',
        alignItems: 'center',
        padding: 5,
        borderColor: '#990033',
        borderWidth: 1,
        width: 135,
        height: 75
    },
    container1: {
        flex: 1,
        flexDirection: 'row',
        margin: 5,
        borderRadius: 10,
        backgroundColor: '#FFCCCC',
        justifyContent: 'center',
        alignItems: 'center',
        padding: 5,
        borderColor: '#990033',
        borderWidth: 1,
        width: 135,
        height: 75
    },
    TenMon: {
        textAlign: 'center',
        fontSize: 12,
        color: '#000',
        fontWeight: 'bold',
    },
    Gia: {
        textAlign: 'center',
        fontSize: 11,
        alignItems: 'center',
    },
});

const CustomRowFoodOrder = ({ TenMon, Gia, SLCon, DVT }) => {
    if (SLCon == 0) {
        return (<View style={styles.container1}>
            {/* {<Image source={{ uri: image_url }} style={styles.photo} />} */}
            <View style={{ justifyContent: 'center' }}>
                <Text style={styles.TenMon}>
                    {TenMon.trim()}
                </Text>
                <Text style={styles.Gia}>
                    Giá : <Text style={{ fontSize: 11, alignItems: 'center', color: 'red' }}>{Gia}</Text>
                </Text>
                <Text style={styles.Gia}>
                   <Text style={{ fontSize: 11, alignItems: 'center', color: '#CC0000', fontWeight: 'bold' }}>Món Đã Hết</Text>
                    
                </Text>
            </View>
        </View>)
    }
    else {
        return (<View style={styles.container}>
            {/* {<Image source={{ uri: image_url }} style={styles.photo} />} */}
            <View style={{ justifyContent: 'center' }}>
                <Text style={styles.TenMon}>
                    {TenMon.trim()}
                </Text>
                <Text style={styles.Gia}>
                    Giá : <Text style={{ fontSize: 11, alignItems: 'center', color: 'red' }}>{Gia}</Text>
                </Text>
                <Text style={styles.Gia}>
                    SL Còn : <Text style={{ fontSize: 11, alignItems: 'center', color: '#00DD00', fontWeight: 'bold' }}>{SLCon} </Text>
                    <Text style={{ fontSize: 11, alignItems: 'center', color: '#777777', fontWeight: 'bold' }}>{DVT.trim()}</Text>
                </Text>
            </View>
        </View>)
    }
}

export default CustomRowFoodOrder;
