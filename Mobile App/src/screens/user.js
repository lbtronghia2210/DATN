import React, { Component } from 'react';
import { ImageBackground, View, Image, Text } from 'react-native';
import styles from '../styles/css/UserStyles';
import { Input, Card, Button } from 'react-native-elements';
import Icon from 'react-native-vector-icons/FontAwesome';

export default class User extends Component {
    constructor(props) {
        super(props)
        this.state = {
            apiData: [],
            txtTenNV: '',
            txtGioiTinh: '',
            txtNgaySinh: '',
            txtViTri: '',
            txtSDT: ''
        }
    }
    componentDidMount() {
        //alert(this.props.navigation.getParam('MaNV'));
        fetch('http://' + this.props.navigation.getParam('IP') + ':8080/getUser/?MaNV=' + this.props.navigation.getParam('MaNV') + '&MaLoaiTK=' + this.props.navigation.getParam('MaLoaiTK'), {
            method: 'GET'
        }).then((responseData) => {
            return responseData.json();
        }).then((jsonData) => {
            this.setState({ apiData: jsonData })
        }).done();
    }
    signOut=()=>{
        this.props.navigation.goBack(null);
        this.props.navigation.goBack(null)
    }
    render() {
        console.disableYellowBox = true;
        this.state.apiData.forEach((item)=>{
            this.state.txtTenNV = item.HoTen;
            this.state.txtGioiTinh = item.Phai;
            this.state.txtNgaySinh = item.NgaySinh;
            this.state.txtViTri = item.TenLoaiTK;
            this.state.txtSDT = item.SDT;
        })
        return (
            <View style={styles.container}>
                <ImageBackground source={require("../img/bg1.jpg")} style={styles.image1} >
                <View style={styles.logo}>
                    <Image style={styles.image}
                        source={require("../img/nhanvien.png")}
                    />
                </View>
                <View style={styles.info}>
                    <Card containerStyle={styles.card_login}>
                        <Text style={styles.txtTen}>{this.state.txtTenNV.trim()}</Text>
                        <Text style={styles.txtGT}>Giới tính : {this.state.txtGioiTinh.trim()} </Text>
                        <Text style={styles.txtGT}>Ngày sinh : {this.state.txtNgaySinh.trim()}</Text>
                        <Text style={styles.txtGT}>Vị trí : {this.state.txtViTri.trim()} </Text>
                        <Text style={styles.txtGT}>Số ĐT : <Text style={styles.txtGT,{color:"#0099FF"}}>{this.state.txtSDT.trim()}</Text></Text>
                    
                        <Button buttonStyle={styles.button} onPress={()=>this.signOut()}
                            title="Đăng xuất"
                        />
                       
                    </Card>
                </View>
                <View style={styles.btn}>
                
                </View>
                </ImageBackground>
            </View>
        )
    }
}