import React, { Component } from 'react';
import { View, } from 'react-native';
import styles from '../styles/css/FoodStyles';
import CustomListviewFood from '../styles/listview/CustomListViewFood';
import CustomRow from '../styles/listview/CustomRowFood';


export default class Food extends Component {
  constructor(props) {
    super(props)
    this.state = {
      apiData: []
    }
  }
  componentDidMount() {
    this.getData();
  }
  getData() {
    fetch('http://' + this.props.navigation.getParam('IP') + ':8080/users', {
      method: 'GET'
    }).then((responseData) => {
      return responseData.json();
    }).then((jsonData) => {
      this.setState({ apiData: jsonData })
    }).done();
  }
  render() {
    const data = this.state.apiData;
    console.disableYellowBox = true;
    return (
      <View style={styles.container}>
        <CustomListviewFood
          itemList={this.state.apiData}
        />
      </View>

    );
  }
}


