import { StyleSheet } from 'react-native';
const styles = StyleSheet.create({
    rightorder: {
        flex: 5,
        height: '100%',
        borderWidth: 0.5,
        borderColor: 'gray',
        borderRadius: 5
    },
    container1: {
        padding: 2,
        flex: 1,
        flexDirection: 'row',
        backgroundColor: '#FFF',
        justifyContent: 'flex-start',
        borderBottomColor: '#FFF',
        borderBottomWidth: 0.5,
        width: '100%',
        marginTop: 1,
        borderRadius: 2
    },
    leftorder: {
        flex: 2,
        flexDirection: "column",
        backgroundColor: '#FFFFCC',
        height: '100%',
        padding: 3,
        borderWidth: 0.5,
        borderColor: 'gray',
        borderRadius: 5
    },
    container: {
        flex: 1,
        backgroundColor: '#FFF',
        justifyContent: 'center',
        alignItems: 'center',
        flexDirection: 'column'
    },
    topcontainer: {
        flex: 6,
        flexDirection: 'column',
        backgroundColor: '#FFF',
        width: '100%',
        alignItems: 'center',
        padding: 10
    },
    allbtn: {
        flex: 1,
        flexDirection: 'row',
        padding: 10,
        borderRadius: 10,
        justifyContent:'center',
        alignItems:"center",
        backgroundColor: '#FFF',
        borderRadius: 10,
        borderColor: '#990033',
        borderWidth: 1,
        
        marginBottom:5
    },
    getall:{
        flex:1,
        borderBottomColor:'gray',
        borderBottomWidth:0.5,
        borderStyle: 'dashed',
    },
    gettype:{
        flex :4,
    },
    bottomcontainer: {
        flex: 6,
        flexDirection: 'row',
        backgroundColor: '#FFF',
        width: '100%',
        alignItems: 'center'
    },
    containertitle: {
        flex: 1,
        backgroundColor: '#FFF',
        width: '100%',
        alignSelf: 'center',
        marginTop: 5
    },
    containertitlebot: {
        width: '100%',
        flexDirection: 'row',
    },
    titleTenMon: {
        width: '100%',
        flex: 3,
        fontSize: 15,
        marginTop: 15,
        marginLeft: 20,
        fontWeight: 'bold',
        padding: 2
    },
    titleSL: {
        width: '100%',
        flex: 2,
        fontSize: 15,
        marginTop: 15,
        textAlign: 'center',
        fontWeight: 'bold',
        padding: 2,
        marginRight: 10,
    },
    titleGia: {
        width: '100%',
        flex: 2,
        textAlign: 'center',
        fontSize: 15,
        marginTop: 15,
        fontWeight: 'bold',
        padding: 2,
        marginRight: 20,
    },
    titleThaoTac: {
        width: '100%',
        flex: 2,
        textAlign: 'center',
        fontSize: 15,
        marginTop: 15,
        fontWeight: 'bold',
        padding: 2,
        marginRight: 20,
    },
    totalview: {
        flex: 4,
        backgroundColor: '#FFFFCC',
        width: '100%',
        alignItems: 'center',
    },
    infoview: {
        flex: 3,
        backgroundColor: '#FFF',
        width: '100%',
        flexDirection: 'row',
        alignItems: 'center',
        padding: 3
    },
    btnview: {
        flex: 2,
        flexDirection: 'row',
        justifyContent: 'center',
        alignSelf: 'center',
        backgroundColor: '#FFFF',
        width: '100%',
        alignItems: 'center',
    },
    flview: {
        flex: 8,
        backgroundColor: '#FFFFCC',
        width: '100%',
        borderColor: 'gray',
        borderRadius: 5,
        borderWidth: 1,
        // borderStyle:'dashed',
    },
    btnThanhToan: {
        backgroundColor: '#3377FF',
        borderRadius: 5,
        paddingHorizontal: 25,
        paddingVertical: 12,
        marginLeft: 10,
    },
    btnHuy: {
        backgroundColor: '#FF3333',
        borderRadius: 5,
        paddingHorizontal: 25,
        paddingVertical: 12,
        marginLeft: 10,
    },
    txtThanhToan: {
        color: '#FFF',
        fontSize: 15
    },
    rightinfo: {
        flex: 1,
        flexDirection: 'column',
        backgroundColor: '#FFF',
        height: '100%',
        alignItems: 'flex-start',
        padding: 10
    },
    leftinfo: {
        flex: 1,
        flexDirection: 'row',
        backgroundColor: '#FFF',
        height: '100%',
        alignItems: 'flex-start',
        padding: 10
    },
    tenban: {
        flex: 1,
        backgroundColor: '#FFF',
        flexDirection: 'row',
        width: '100%',
        alignItems: 'flex-start',
    },
    mahoadon: {
        flex: 1,
        backgroundColor: '#FFF',
        flexDirection: 'row',
        width: '100%',
        alignItems: 'flex-start',
    },
    TenMon: {
        flex: 5,
        fontSize: 15,
        color: '#000',

    },
    SubAdd: {
        flex: 1,
        color: '#3377FF',
        alignItems: 'center',
        flexDirection: 'row',
        width: '100%',
    },
    Gia: {
        fontSize: 15,
        flex: 3,
        color: '#990033',
        textAlign: 'right',
        marginRight: 15,
        marginLeft: 5
    },
    SL: {
        fontSize: 15,
        flex: 3,
        textAlign: 'center',
    },
    Edit: {
        flex: 3,
        color: '#3377FF',
        alignItems: 'center',
        flexDirection: 'row',
        width: '100%',
        alignItems: 'center',
    },
    EditItem: {
        flex: 1,
        width: '100%',
        alignItems: 'center',
    },
    Text: {
        flex: 1,
        width: '100%',
        alignItems: 'center',
    },
    icon: {
        padding: 2,
        width: 18,
        height: 18,
    },
    icon1: {
        marginRight: 10,
        marginTop: 5,
        width: 15,
        height: 15,
    },
    text: {
        backgroundColor: '#FFF',
        alignSelf: 'center',
        alignItems: 'center',
        width: '100%',
        borderRadius: 10,
        borderColor: 'gray',
        borderWidth: 1
    },
    modal: {
        flexDirection: "column",
        backgroundColor: '#FFF',
        borderRadius: 15,
        borderColor: "#FFFFCC",
        borderWidth: 2,
        height: 200,
        width: "70%",
        alignSelf: "center"
    },
    modalTop: {
        flex: 1,
        width: "100%",
        alignSelf: "center",
    },
    modalMid: {
        flex: 1,
        flexDirection: "row",
        width: "100%",
        alignSelf: "center",
    },
    modalBot: {
        flex: 1,
        flexDirection: "row",
        width: "100%",
        alignSelf: "center",

    },
    modalLeft: {
        flex: 1,
        height: "100%",
        alignSelf: "center"
    },
    modalCenter: {
        flex: 1,
        marginLeft: 40,
        marginRight: 40,
        marginTop: 20,
        padding: 5,
        height: "100%",
        alignSelf: "center",
        alignItems: 'center',
    },
    modalRight: {
        flex: 1,
        height: "100%",
        alignSelf: "center",
        alignItems: 'center',
        marginTop: 20
    },
    modalBotItem: {
        flex: 1,
        height: "100%",
        alignSelf: "center",
        marginTop: 20
    },
    buttonDelete: {
        borderRadius: 20,
        backgroundColor: "#CC3333",
        margin: 10,
    },
    buttonCancel: {
        borderRadius: 20,
        backgroundColor: "#0099FF",
        margin: 10,
    },
    buttonOK: {
        borderRadius: 20,
        backgroundColor: "#33CC66",
        margin: 10,
    },
    iconModal: {
        margin: 20,
        width: 27,
        height: 27
    },
    btnIn:{
        backgroundColor: '#6666FF',
        borderRadius: 5,
        paddingHorizontal: 25,
        paddingVertical: 12,
        marginLeft: 10,
    },
})

export default styles;