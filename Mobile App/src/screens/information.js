import React, { Component } from 'react';
import NumberFormat from 'react-number-format';
import { Image, Text, View, Alert, FlatList, TouchableOpacity, ImageBackground } from 'react-native';
import Modal from 'react-native-modal';
import { Button } from 'react-native-elements';
import CustomRowFoodOrder from '../styles/listview/CustomRowFoodOrder';
import CustomRowTypeFood from '../styles/listview/CustomRowTypeFood';
import InputSpinner from "react-native-input-spinner";
import styles from "../styles/css/InfomationStyle.js"

export default class Information extends Component {
    constructor(props) {
        super(props)
        this.state = {
            countMaHD: [], apiData: [], apiFood: [], apiTypeOfFood: [], checkdata: [], checkNL: [], apiMaHD: [],
            showOrder: true, showCancel: false, showPrint: false, showCancelPrint: false, trangthai: [], txtMaMon: '', txtMaLoai: '', showDialog: false,
            txtTenMon: '', txtSoLuongCon: '', txtMaMon: '', txtMaHoaDon: '', txtDonGia: '', txtSoLuongXN: 0, checkIntervalAll: false,
            checkInterval: false,status:[]
        }
    }
    componentDidMount() {
        this.getCountMaHD();
        this.intervalCountMaHD = setInterval(() => this.getCountMaHD(), 1000);
        this.getBill();
        this.intervalBill = setInterval(() => this.getBill(), 1000);
        //this.intervalGetAllFood = setInterval(() => this.getAllFood(), 1000);
        this.intervalGetFood = setInterval(() => this.getFood(this.state.txtMaLoai), 1000);
        this.getTypeOfFood();
        this.CheckNL(this.state.txtMaMon);
        this.intervalFood = setInterval(() => this.CheckNL(this.state.txtMaMon), 1000);
        this.getMaHD();
        this.intervalMaHD = setInterval(() => this.getMaHD(), 1000);
        this.checkButton();
        this.intervalButton = setInterval(() => this.checkButton(), 1000);
    }
    componentWillUnmount() {
        clearInterval(this.intervalBill);
        clearInterval(this.intervalMaHD);
        clearInterval(this.intervalGetFood);
        clearInterval(this.intervalCountMaHD);
        clearInterval(this.intervalFood);
        clearInterval(this.intervalButton);
    };
    checkNguyenLieu = () => {
        fetch('http://' + this.props.navigation.getParam('IP') + ':8080/checknguyenlieu', {
            method: 'GET'
        }).then((responseData) => {
            return responseData.json();
        }).then((jsonData) => {
            this.setState({ checknguyenlieu: jsonData })
        }).done();
    }
    //------------Lấy SL Mã Hóa Đơn-------------------------
    getCountMaHD = () => {
        fetch('http://' + this.props.navigation.getParam('IP') + ':8080/getcount', {
            method: 'GET'
        }).then((responseData) => {
            return responseData.json();
        }).then((jsonData) => {
            this.setState({ countMaHD: jsonData })
        }).done();
    }
    //--------------Lấy Danh Sách Thực Đơn Theo Loại Món -------------------------
    getFood = (MaLoai) => {
        try {
            fetch('http://' + this.props.navigation.getParam('IP') + ':8080/food/?MaLoai=' + MaLoai, {
                method: 'GET'
            }).then((responseData) => {
                return responseData.json();
            }).then((jsonData) => {
                //console.log(jsonData)
                this.setState({ apiFood: jsonData })
                // console.log(this.state.apiData)
            }).done();
        }
        catch (error) {
            console.log(error);
        }
        this.state.txtMaLoai = MaLoai;
    }
    getAllFood = () => {
        try {
            fetch('http://' + this.props.navigation.getParam('IP') + ':8080/allfood/', {
                method: 'GET'
            }).then((responseData) => {
                return responseData.json();
            }).then((jsonData) => {
                //console.log(jsonData)
                this.setState({ apiFood: jsonData })
                // console.log(this.state.apiData)
            }).done();
        }
        catch (error) {
            console.log(error);
        }
    }
    //---------------------Lấy Loại Món Thực Đơn------------------------------
    getTypeOfFood = () => {
        fetch('http://' + this.props.navigation.getParam('IP') + ':8080/typefood', {
            method: 'GET'
        }).then((responseData) => {
            return responseData.json();
        }).then((jsonData) => {
            //console.log(jsonData)
            this.setState({ apiTypeOfFood: jsonData })
            // console.log(this.state.apiData)
        }).done();
    };

    //---------------------Kiếm Tra Trạng Thái Bàn Và Thêm Hóa Đơn------------------------------
    checkStatus = () => {
        const MaBan = this.props.navigation.getParam('MaBan');
        if (this.state.apiData.length == 0) {
            fetch('http://' + this.props.navigation.getParam('IP') + ':8080/changestatus/?MaBan=' + MaBan, {
                method: 'PUT'
            }).done();
            this.state.countMaHD.forEach((item) => {
                if (item.SL == 0) {
                    fetch('http://' + this.props.navigation.getParam('IP') + ':8080/addbillnull/?MaBan=' + MaBan + '&MaNV=' + this.props.navigation.getParam('MaNV'), {
                        method: 'PUT'
                    }).done();
                }
                else {
                    fetch('http://' + this.props.navigation.getParam('IP') + ':8080/addbill/?MaBan=' + MaBan + '&MaNV=' + this.props.navigation.getParam('MaNV'), {
                        method: 'PUT'
                    }).done();
                }
            })

            this.setState({ showOrder: false });
            this.setState({ showCancel: true });
            this.setState({ showPrint: true });
        }
        else {
            this.setState({ showOrder: false });
            this.setState({ showCancel: true });
            this.setState({ showPrint: true });
        }
    };

    //---------------------Kiếm Tra Trạng Thái Nút Đặt Món Hủy Món------------------------------    
    checkButton = () => {
          fetch('http://' + this.props.navigation.getParam('IP') + ':8080/getStatus/?MaBan='+this.props.navigation.getParam('MaBan'), {
            method: 'GET'
        }).then((responseData) => {
            return responseData.json();
        }).then((jsonData) => {
            //console.log(jsonData.TrangThai)
            this.setState({ status: jsonData },()=>{
                this.state.status.forEach((item)=>{
                    if (item.TrangThai.trim() == 1) {
                        this.setState({ showOrder: false });
                        this.setState({ showCancel: true });
                        this.setState({ showPrint: true });
                        this.setState({ showCancelPrint: false });
                    }
                    else if (item.TrangThai.trim() == 'BT') {
                        this.setState({ showOrder: false });
                        this.setState({ showCancel: true });
                        this.setState({ showPrint: false });
                        this.setState({ showCancelPrint: true });
                    }
                    else {
                        this.setState({ showOrder: true });
                        this.setState({ showCancel: false });
                        this.setState({ showPrint: false });
                        this.setState({ showCancelPrint: false });
                    }
                })
            })
            // console.log(this.state.apiData)
        }).done();
    }
    //------------------Lấy Mã Hóa Đơn Từ Mã Bàn-------------------------
    getMaHD = () => {
        const MaBan = this.props.navigation.getParam('MaBan');
        fetch('http://' + this.props.navigation.getParam('IP') + ':8080/getMaHD?MaBan=' + MaBan, {
            method: 'GET'
        }).then((responseData) => {
            return responseData.json();
        }).then((jsonData) => {
            this.setState({ apiMaHD: jsonData })
            //console.log(this.state.apiMaHD)
        }).done();
    }

    //-------------------------Xử Lí Sự Kiện Hủy Bàn-------------------------    
    cancelTable = (MaBan, MaHoaDon) => {
        this.state.apiData.forEach((item) => {
            fetch('http://' + this.props.navigation.getParam('IP') + ':8080/updateNLSub/?MaMon=' + item.MaMon + '&SoLuong=' + item.SoLuong, {
                method: 'PUT',
            });
            console.log(item.MaMon, item.SoLuong);
        })
        fetch('http://' + this.props.navigation.getParam('IP') + ':8080/canceltable/?MaHoaDon=' + MaHoaDon, {
            method: 'PUT',
        }).done();
        fetch('http://' + this.props.navigation.getParam('IP') + ':8080/resettable/?MaBan=' + MaBan, {
            method: 'PUT'
        }).done();
        this.props.navigation.goBack();
    }

    //--------------------------Xử Lí Xuất Bill Tạm----------------------------
    printBill = (MaBan, MaHD) => {
        Alert.alert(
            'Thông Báo !!',
            'Yêu Cầu Xuất Bill Tạm Cho Khách ?',
            [
                {
                    text: 'Yes', onPress: () => {
                        fetch('http://' + this.props.navigation.getParam('IP') + ':8080/printBill/?MaBan=' + MaBan, {
                            method: 'PUT',
                        }).done();
                        this.setState({ showPrint: false });
                        this.setState({ showCancelPrint: true });
                        this.props.navigation.goBack();
                    }

                },
                { text: 'No', onPress: () => console.log('No Pressed'), style: 'cancel' },
            ],
            { cancelable: false }
        );

    }
    cancelPrintBill = (MaBan, MaHD) => {
        Alert.alert(
            'Thông Báo !!',
            'Hủy Yêu Cầu Xuất Bill Tạm Cho Khách ?',
            [
                {
                    text: 'Yes', onPress: () => {
                        fetch('http://' + this.props.navigation.getParam('IP') + ':8080/cancelPrintBill/?MaBan=' + MaBan, {
                            method: 'PUT',
                        }).done();
                        this.setState({ showPrint: true });
                        this.setState({ showCancelPrint: false });
                    }

                },
                { text: 'No', onPress: () => console.log('No Pressed'), style: 'cancel' },
            ],
            { cancelable: false }
        );
    }
    //----------------------------Xử Lí Sự Kiện Thêm Món Ăn Từ Danh Sách Món-----------------------
    showDialog = (MaMon, MaHoaDon, DonGia, TenMon, SoLuong) => {
        this.setState({ txtTenMon: TenMon });
        this.setState({ txtSoLuongCon: SoLuong });
        this.setState({ txtMaMon: MaMon });
        this.setState({ txtMaHoaDon: MaHoaDon });
        this.setState({ txtDonGia: DonGia });
        this.setState({ showDialog: !this.state.showDialog });
    }
    //---------------------------------Thêm Món Ăn Với SL = SL Vào Bill----------------------------
    addFood = (MaMon, MaHoaDon, DonGia, SoLuong) => {
        if (SoLuong == 0) {
            this.setState({ showDialog: !this.state.showDialog });
        }
        else {
            const index = this.state.apiData.findIndex(item => item.MaMon == MaMon);
            if (index > -1) {
                this.AddFoodSL(MaHoaDon, MaMon, SoLuong);
            }
            else {
                fetch('http://' + this.props.navigation.getParam('IP') + ':8080/addfoodtobill/?MaMon=' + MaMon + '&MaHoaDon=' + MaHoaDon + '&DonGia=' + DonGia + '&SoLuong=' + SoLuong, {
                    method: 'PUT'
                }).done();
                fetch('http://' + this.props.navigation.getParam('IP') + ':8080/updateNLAdd/?MaMon=' + MaMon + '&SoLuong=' + SoLuong, {
                    method: 'PUT',
                });
            }
            this.setState({ showDialog: !this.state.showDialog });
        }

    }
    //-------------------------Lấy Toàn Bộ Thông Tin Hóa Đơn Bàn----------------------------
    getBill = () => {
        fetch('http://' + this.props.navigation.getParam('IP') + ':8080/bill/?MaBan=' + this.props.navigation.getParam('MaBan'), {
            method: 'GET',
            'Content-Type': 'application/json'
        }).then((responseData) => {
            return responseData.json();
        }).then((jsonData) => {
            //console.log(jsonData)
            this.setState({ apiData: jsonData })
            // console.log(this.state.apiData)
        }).catch((error) => {
            this.setState({ apiData: [] });
        });
    };

    //-----------------------------Kiểm Tra Số Lượng Nguyên Liệu Hiện Còn--------------------------------
    CheckNL = (MaMon) => {
        fetch('http://' + this.props.navigation.getParam('IP') + ':8080/checknl/?MaMon=' + MaMon, {
            method: 'GET',
        }).then((responseData) => {
            return responseData.json();
        }).then((jsonData) => {
            this.setState({ checkNL: jsonData })
        }).done();
    }

    //----------------------------Xử Lí Sự Kiện Thêm Món Ăn Bằng Phím + -----------------------
    AddFoodSL = (MaHD, MaMon, SoLuong) => {
        fetch('http://' + this.props.navigation.getParam('IP') + ':8080/updatebilladd/?MaHoaDon=' + MaHD + '&MaMon=' + MaMon + '&SoLuong=' + SoLuong, {
            method: 'PUT',
        });
        fetch('http://' + this.props.navigation.getParam('IP') + ':8080/updateNLAdd/?MaMon=' + MaMon + '&SoLuong=' + SoLuong, {
            method: 'PUT',
        });
    }
    //--------------------------------Add Món Với SL = 1 ----------------------------------
    AddFoodOne = (MaHD, MaMon) => {
        this.CheckNL(MaMon);
        this.state.checkNL.forEach((item) => {
            if (item.SLMin == null) {
                return;
            }
            else if (item.SLMin == 0) {
                alert("Món Chọn Đã Hết !")
                return;
            }
            else {
                // alert(item.SLMin - 1);
                fetch('http://' + this.props.navigation.getParam('IP') + ':8080/updatebilladd/?MaHoaDon=' + MaHD + '&MaMon=' + MaMon + '&SoLuong=1', {
                    method: 'PUT',
                });
                fetch('http://' + this.props.navigation.getParam('IP') + ':8080/updateNLAdd/?MaMon=' + MaMon + '&SoLuong=1', {
                    method: 'PUT',
                });

            }
        })
    }

    //----------------------------Xử Lí Sự Kiện Xóa Món Ăn Bằng Phím - -----------------------
    SubSL = (MaHD, MaMon, SoLuong) => {
        if (SoLuong == 1) {
            Alert.alert(
                'Thông Báo',
                'Bạn muốn xóa thông tin món ?',
                [
                    {
                        text: 'Yes', onPress: () => {
                            fetch('http://' + this.props.navigation.getParam('IP') + ':8080/removefood/?MaHoaDon=' + MaHD + '&MaMon=' + MaMon, {
                                method: 'PUT',
                            })
                            fetch('http://' + this.props.navigation.getParam('IP') + ':8080/updateNLSub/?MaMon=' + MaMon + '&SoLuong=1', {
                                method: 'PUT',
                            });
                        }

                    },
                    { text: 'No', onPress: () => console.log('No Pressed'), style: 'cancel' },
                ],
                { cancelable: false }
            );
            this.getBill();
        }
        else {
            fetch('http://' + this.props.navigation.getParam('IP') + ':8080/updatebillsub/?MaHoaDon=' + MaHD + '&MaMon=' + MaMon, {
                method: 'PUT',
            });
            fetch('http://' + this.props.navigation.getParam('IP') + ':8080/updateNLSub/?MaMon=' + MaMon + '&SoLuong=1', {
                method: 'PUT',
            });
        }

    }

    //----------------------------Xóa 1 Món Từ Bill------------------------------
    deleteFood = (MaHD, MaMon, SoLuong) => {
        Alert.alert(
            'Thông Báo',
            'Bạn có chắc muốn xóa món ?',
            [
                {
                    text: 'Yes', onPress: () => {
                        fetch('http://' + this.props.navigation.getParam('IP') + ':8080/removefood/?MaHoaDon=' + MaHD + '&MaMon=' + MaMon, {
                            method: 'PUT',
                        })
                        fetch('http://' + this.props.navigation.getParam('IP') + ':8080/updateNLSub/?MaMon=' + MaMon + '&SoLuong=' + SoLuong, {
                            method: 'PUT',
                        });
                    }

                },
                { text: 'No', onPress: () => console.log('No Pressed'), style: 'cancel' },
            ],
            { cancelable: false }
        );
    }

    //--------------------------------Ẩn Dialog-------------------------------
    cancelModal = () => {
        this.setState({ showDialog: !this.state.showDialog });
    }

    //----------------------------------Render---------------------------------
    render() {
        console.disableYellowBox = true;
        let totalQuantity = 0;
        let totalPrice = 0;
        let mahoadon = 0;
        const { apiData } = this.state;
        this.state.apiData.forEach((item) => {
            totalQuantity += item.SoLuong;
            totalPrice += item.SoLuong * (item.ThanhTien / item.SoLuong);
        });
        this.state.apiMaHD.forEach((item) => {
            mahoadon = item.MaHoaDon;
        });
        const data = this.state.apiData;
        return (
            <View style={styles.container}>
                <Modal isVisible={this.state.showDialog}>
                    <View style={styles.modal}>
                        <View style={styles.modalTop}>
                            <Text style={{ textAlign: "center", marginTop: 10, fontSize: 14, fontWeight: "bold" }}>XÁC NHẬN SỐ LƯỢNG</Text>
                            <Text style={{ textAlign: "center", marginTop: 1, fontSize: 13, fontWeight: "bold", color: "#0066FF" }}>       {this.state.txtTenMon}</Text>
                            <Text style={{ textAlign: "center", marginTop: 1, fontSize: 13, }}>( Số Lượng Còn :
                            <Text style={{ textAlign: "center", marginTop: 1, fontSize: 13, color: "#00AA00" }}> {this.state.txtSoLuongCon} </Text>)
                            </Text>
                        </View>
                        <View style={styles.modalMid}>
                            <InputSpinner
                                style={styles.modalCenter}
                                min={0}
                                max={this.state.txtSoLuongCon}
                                step={1}
                                color={"#3399FF"}
                                colorPress={"#3366FF"}
                                showBorder={true}
                                fontSize={15}
                                keyboardType='number-pad'
                                onChange={(num) => {
                                    this.setState({ txtSoLuongXN: num })
                                }}
                            />
                        </View>
                        <View style={styles.modalBot}>
                            <View style={styles.modalBotItem}>
                                <Button buttonStyle={styles.buttonCancel} onPress={() => this.cancelModal()}
                                    title="Hủy"
                                />
                            </View>
                            <View style={styles.modalBotItem}>
                                <Button buttonStyle={styles.buttonOK} onPress={() => this.addFood
                                    (this.state.txtMaMon, this.state.txtMaHoaDon, this.state.txtDonGia, this.state.txtSoLuongXN)}
                                    title="Xác Nhận"
                                />
                            </View>
                        </View>
                    </View>
                </Modal>
                <View style={styles.containertitle}>
                    <View style={styles.containertitlebot} >
                        <Text style={styles.titleTenMon}>Tên Món</Text>
                        <Text style={styles.titleSL}>Số Lượng</Text>
                        <Text style={styles.titleGia}>Thành Tiền</Text>
                        <Text style={styles.titleThaoTac}>Thao Tác</Text>
                    </View>
                </View>
                <View style={styles.topcontainer}>
                    <View style={styles.flview}>
                        <FlatList style={{ width: '100%' }}
                            data={this.state.apiData}
                            extraData={this.state}
                            renderItem={({ item, index }) =>
                                <View style={styles.container1}>
                                    <Text style={styles.TenMon}>
                                        {item.TenMon}
                                    </Text>
                                    <View style={styles.SubAdd}>
                                        <Text style={styles.SL}> {item.SoLuong}</Text>
                                    </View>
                                    <Text style={styles.Gia}>
                                        <NumberFormat
                                            value={item.ThanhTien}
                                            displayType={'text'}
                                            thousandSeparator={true}
                                            prefix={''}
                                            renderText={formattedValue => <Text style={{ fontSize: 15, color: '#990033' }}> {formattedValue}</Text>} // <--- Don't forget this!
                                        />

                                    </Text>
                                    <View style={styles.Edit}>
                                        <View style={styles.EditItem}>
                                            <TouchableOpacity onPress={() => this.SubSL(item.MaHoaDon, item.MaMon, item.SoLuong)}>
                                                <Image style={styles.icon} source={require('../img/delete.png')} />
                                            </TouchableOpacity>
                                        </View>
                                        <View style={styles.EditItem} >
                                            <TouchableOpacity onPress={() => this.AddFoodOne(item.MaHoaDon, item.MaMon)} >
                                                <Image style={styles.icon} source={require('../img/add.png')} />
                                            </TouchableOpacity>
                                        </View>
                                        <View style={styles.EditItem} >
                                            <TouchableOpacity onPress={() => this.deleteFood(item.MaHoaDon, item.MaMon, item.SoLuong)} >
                                                <Image style={styles.icon} source={require('../img/close.png')} />
                                            </TouchableOpacity>
                                        </View>
                                    </View>
                                </View>}

                            keyExtractor={item => item.MaMon}

                            numColumns={1}
                        />

                    </View>

                    <View style={styles.totalview}>
                        <View style={styles.infoview}>
                            <View style={styles.rightinfo} >
                                <View style={styles.tenban}>
                                    <Image style={styles.icon1} source={require('../img/food-and-restaurant.png')} />
                                    <Text style={{ fontSize: 14, fontWeight: 'bold', marginTop: 2, color: "#990033" }}>{this.props.navigation.getParam('TenBan')}</Text>
                                </View>
                                <View style={styles.mahoadon}>
                                    <Image style={styles.icon1} source={require('../img/business.png')} />
                                    <Text style={{ fontSize: 14, fontWeight: 'bold', marginTop: 5 }}>Mã Hóa Đơn : <Text style={{ fontSize: 14, fontWeight: 'bold', color: '#990033' }}>{mahoadon}</Text></Text>
                                </View>
                            </View>
                            <View style={styles.leftinfo} >
                                <Image style={styles.icon1} source={require('../img/business-and-finance.png')} />
                                <Text style={{ fontSize: 14, fontWeight: 'bold' }}>Tổng Tiền :</Text>
                                <NumberFormat
                                    value={totalPrice}
                                    displayType={'text'}
                                    thousandSeparator={true}
                                    prefix={''}
                                    renderText={formattedValue => <Text style={{ fontSize: 14, fontWeight: 'bold', color: '#990033' }}>  {formattedValue} vnd</Text>} // <--- Don't forget this!
                                />

                            </View>
                        </View>
                        <View style={styles.btnview}>

                            {this.state.showOrder ? <TouchableOpacity style={styles.btnThanhToan} onPress={() => this.checkStatus()}>
                                <Text style={styles.txtThanhToan}>Đặt Món</Text>
                            </TouchableOpacity> : null}
                            {this.state.showCancel ? <TouchableOpacity style={styles.btnHuy} onPress={() => this.cancelTable(this.props.navigation.getParam('MaBan'), mahoadon)}>
                                <Text style={styles.txtThanhToan}>Hủy Bàn</Text>
                            </TouchableOpacity> : null}
                            {this.state.showPrint ? <TouchableOpacity style={styles.btnIn} onPress={() => this.printBill(this.props.navigation.getParam('MaBan'), mahoadon)}>
                                <Text style={styles.txtThanhToan}>Xuất Bill Tạm</Text>
                            </TouchableOpacity> : null}
                            {this.state.showCancelPrint ? <TouchableOpacity style={styles.btnIn} onPress={() => this.cancelPrintBill(this.props.navigation.getParam('MaBan'), mahoadon)}>
                                <Text style={styles.txtThanhToan}>Hủy Xuất Bill</Text>
                            </TouchableOpacity> : null}
                        </View>
                    </View>
                </View>
                <View style={styles.bottomcontainer}>

                    <ImageBackground source={require("../img/menu.jpg")} style={styles.rightorder} imageStyle={{ borderRadius: 5 }}>

                        <View style={styles.text}><Text style={{ color: '#990033', fontSize: 13, padding: 2 }}>!! NHẤN ĐẶT MÓN TRƯỚC KHI CHỌN MÓN !!</Text></View>
                        <FlatList style={{ width: '100%', padding: 1 }}
                            data={this.state.apiFood}
                            renderItem={({ item, index }) =>
                                <TouchableOpacity disabled={this.state.showOrder} style={{ alignItems: 'center' }} onPress={() => this.showDialog(item.MaMon, mahoadon, item.DonGia, item.TenMon, item.SLCon)}>
                                    <CustomRowFoodOrder
                                        TenMon={item.TenMon}
                                        Gia={item.DonGia}
                                        SLCon={item.SLCon}
                                        DVT={item.DVT}
                                    />
                                </TouchableOpacity>
                            }
                            keyExtractor={item => item.TenMon}
                            numColumns={2}
                        />

                    </ImageBackground>


                    <View style={styles.leftorder}>
                        {/* <View style={styles.getall}>
                            <TouchableOpacity disabled={this.state.showOrder} style={styles.allbtn} onPress={() => this.getAllFood()}>
                                <Text style={{ fontSize: 12, color: '#000', fontWeight: 'bold', }}>Tất Cả Món</Text>
                            </TouchableOpacity>
                        </View> */}
                        <View style={styles.gettype}>
                            <FlatList style={{ width: '100%', padding: 1 }}
                                data={this.state.apiTypeOfFood}
                                renderItem={({ item }) =>
                                    <TouchableOpacity disabled={this.state.showOrder} style={{ alignItems: 'center' }} onPress={() => this.getFood(item.MaLoai)}>
                                        <CustomRowTypeFood
                                            TenLoai={item.TenLoai}
                                        />
                                    </TouchableOpacity>}
                                keyExtractor={item => item.TenLoai}
                                numColumns={1}
                            />
                        </View>
                    </View>
                </View>
            </View>
        );
    }
}
