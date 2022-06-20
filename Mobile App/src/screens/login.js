import React, { Component } from 'react';
import { ImageBackground, View, } from 'react-native';
import { Input, Card, Button, Image } from 'react-native-elements';
import Icon from 'react-native-vector-icons/FontAwesome';
import styles from '../styles/css/LoginStyles';
export default class Login extends Component {
    constructor(props) {
        super(props)
        this.state = {
            txtName: 'kimhungcv',
            txtPass: 'kimhungcv',
            apiData: [],
            txtIP: '',
            txtMaLoaiTK:'',
            txtMaNV:'',
        }
    }
    // componentDidMount(){
    //     this.getInfo();
    //     this.intervalLogin = setInterval(() => this.getInfo(), 1000);
    // }
    // componentWillUnmount(){
    //     clearInterval(this.intervalLogin);
    // }
    getInfo = () => {
        fetch('http://' + this.state.txtIP + ':8080/login/?TenDN=' + this.state.txtName + '&MatKhau=' + this.state.txtPass, {
            method: 'GET'
        }).then(response => response.json()).then((jsonData) => {
            this.setState({ apiData: jsonData },()=>{
                if (this.state.apiData.length != 0) {
                    this.state.apiData.forEach((item)=>{
                        //alert(item.MaNV);
                        this.state.txtMaNV = item.MaNV;
                        this.state.txtMaLoaiTK = item.MaLoaiTK;
                    })
                    
                    this.props.navigation.navigate('TabNavigator', {
                        Username: this.state.txtName, Password: this.state.txtPass, IP: this.state.txtIP,
                        MaNV:this.state.txtMaNV, MaLoaiTK:this.state.txtMaLoaiTK
                    })
                }
                else {
                    alert("Sai tên đăng nhập hoặc mật khẩu !!!");
                }
            })
        }).catch(e => console.log("error: ", e))
    
    }
    render() {
        console.disableYellowBox = true;
        return (
            <View style={styles.container}>
                <ImageBackground source={require("../img/bg1.jpg")} style={styles.image} >
                    <Card containerStyle={styles.card_logo}>
                        <Image style={styles.image}
                            source={require("../img/logo.png")}
                            style={{ width: "100%", height: 200 }}
                        />
                    </Card>
                    <Card containerStyle={styles.card_login}>
                        <Input
                            placeholder='IP kết nối'
                            leftIcon={
                                <Icon
                                    name='location-arrow'
                                    size={20}
                                    color='#990033'
                                    margin={10}
                                />
                            }
                            onChangeText={value => this.setState({ txtIP: value })}
                            //value="192.168.42.88"
                        />
                        <Input
                            placeholder='Tên đăng nhập'
                            leftIcon={
                                <Icon
                                    name='user'
                                    size={20}
                                    color='#990033'
                                    margin={10}
                                />
                            }
                            onChangeText={value => this.setState({ txtName: value })}
                        />
                        <Input
                            placeholder='Mật khẩu'
                            leftIcon={
                                <Icon
                                    name='lock'
                                    size={20}
                                    color='#990033'
                                    margin={10}
                                />
                            }
                            onChangeText={value => this.setState({ txtPass: value })}
                            secureTextEntry={true}
                        />

                        <Button buttonStyle={styles.button} onPress={() => this.getInfo()}
                            title="Đăng Nhập"
                        />
                    </Card>
                </ImageBackground>
            </View>



        );
    }
}
