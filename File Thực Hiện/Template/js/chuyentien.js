//CHUYỂN TIỀN
let isDebug = true
let emptyString = ''
let emptyObject = {}
let warning = 'alert-warning'
let success = 'alert-success'
let danger = 'alert-danger'
let info = 'alert-infos'

let loggedUserId = 'NV001'

function isNullOrEmptyString(str) {
    return (str == emptyString || str == undefined || str == null)
}

$(function () {
    var chuyenTienApp = new Vue({
        el: '#chuyenTienApp',
        data: {
            nguoiGui: {
                HoTen: emptyString,
                CMND: emptyString
            },
            nguoiNhan: {
                HoTen: emptyString,
                CMND: emptyString
            },
            taiKhoanGui: {
                MaSoTaiKhoan: emptyString,
                MaKH: emptyString
            },
            taiKhoanNhan: {
                MaSoTaiKhoan: emptyString,
                MaKH: emptyString
            },
            giaoDich: {
                MaKHGoi: emptyString,
                MaKHNhan: emptyString,
                SoTien: 0,
                NoiDung: emptyString,
                MaNV: loggedUserId,
            },
            display: {
                soTienChuyen: false,
                btnSubmit: false,
            },
            message: {
                content: emptyString,
                type: warning
            },
            soTaiKhoanGui: emptyString,
            soTaiKhoanNhan: emptyString,
            soTien: 0,
            noiDung: emptyString
        },
        methods: {
            validate() {

            },
            clear() {

            },
            kiemTraTaiKhoanGui() {
                if (isDebug) {
                    this.nguoiGui.HoTen = "Mai Van Truong"
                    this.nguoiGui.CMND = "321494498"
                } else {
                    //TODO
                }
            },
            kiemTraTaiKhoanNhan() {
                if (isDebug) {
                    this.nguoiNhan.HoTen = "Pham Hoang Nhan"
                    this.nguoiNhan.CMND = "321654987"

                    if (this.nguoiGui != emptyObject && this.nguoiNhan != emptyObject) {
                        this.display.soTienChuyen = true
                    }
                } else {
                    //TODO
                }
            },
            kiemTraKhachHang(maKH) {

            },
            chuyenTien() {

            }

        }
    })
})