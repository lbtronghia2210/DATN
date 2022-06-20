import React, { Component } from 'react';
import { Text, View, FlatList, TouchableOpacity } from 'react-native';
import CustomRow from '../styles/listview/CustomRowTable';
import styles from '../styles/css/LocationStyles';
import { Button, Image } from 'react-native-elements';

export default class Location extends Component {

  constructor(props) {
    super(props)
    this.state = {
      txtKV: "",
      apiData: [],
      floorData: [],
      Active: false,
    }
  }
  componentDidMount() {
    this.interval = setInterval(() => this.showFloor(this.state.txtKV), 1000);
    this.getFloor();
    this.showFloor("KV1");
  }
  componentWillUnmount() {
    clearInterval(this.interval);
  }
  getFloor = () => {
    fetch('http://' + this.props.navigation.getParam('IP') + ':8080/floor', {
      method: 'GET'
    }).then((responseData) => {
      return responseData.json();
    }).then((jsonData) => {
      //console.log(jsonData)
      this.setState({ floorData: jsonData })
      this.setState({ Active: true })
      //console.log(this.state.floorData)
    }).done();
  }
  showFloor = (MaKV) => {
    this.state.Active = !this.state.Active
    fetch('http://' + this.props.navigation.getParam('IP') + ':8080/location/?MaKV=' + MaKV, {
      method: 'GET'
    }).then((responseData) => {
      return responseData.json();
    }).then((jsonData) => {
      //console.log(jsonData)
      this.setState({ apiData: jsonData })
      // console.log(this.state.apiData)
    }).done();
    this.state.txtKV = MaKV;
  }
  navigate = () => {
    this.props.navigation.navigate("InfoScreen");
  }
  render() {
    console.disableYellowBox = true;
    const data = this.state.apiData;
    return (
      <View style={styles.container}>
        <View style={styles.screenview}>
          <FlatList
            horizontal={true}
            data={this.state.floorData}
            renderItem={({ item }) => 
                <TouchableOpacity style={styles.itemSelect} onPress={() => this.showFloor(item.MaKV)}>
                  <Text style={styles.btntxt}>{item.TenKV}</Text>
                </TouchableOpacity>}
            keyExtractor={item => item.TenBan}

          />
        </View>
        <FlatList
          data={this.state.apiData}
          renderItem={({ item }) =>
            <TouchableOpacity style={styles.touch} onPress={() => this.props.navigation.navigate('InfoScreen', {
              MaBan: item.MaBan, TenBan: item.TenBan, TrangThai: item.TrangThai, IP: this.props.navigation.getParam('IP'),
              MaNV: this.props.navigation.getParam('MaNV')
            })}>
              <CustomRow
                TenBan={item.TenBan}
                SoChoNgoi={item.SoChoNgoi}
                TrangThai={item.TrangThai}
              />
            </TouchableOpacity >}
          keyExtractor={item => item.MaBan}

          numColumns={2}
        />
        <Button buttonStyle={styles.button} onPress={() => this.showFloor("KV1")}
          title="Làm Mới Danh Sách Bàn"
        />
      </View>

    );
  }
}

