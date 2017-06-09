//RÚT TIỀN
let isDebug = true
let emptyString = ''
let emptyObject = {}
let warning = 'alert-warning'
let success = 'alert-success'
let danger = 'alert-danger'
let info = 'alert-infos'

function isNullOrEmptyString(str) {
    return (str == emptyString || str == undefined || str == null)
}

$(function () {

    var rutTienApp = new Vue({
        el: '#rutTienApp',
        data: {
            khachHang: emptyObject,
            taiKhoan: emptyObject,
            giaoDich: emptyObject,
            message: {
                content: emptyString,
                type: warning
            },
            display: {
                customer: false,
                account: false,
            },
            cmnd: emptyString,
        },
        methods: {
            kiemTraTaiKhoan () {
                if (!isNullOrEmptyString(this.cmnd)) {
                    if (isDebug) {
                        let kh = {
                            MaKH: 'KH001',
                            HoTen: 'Mai Van Truong',
                            CMND: '321494498',
                            TrangThai: 1
                        }
                        this.khachHang = kh
                        this.display.customer = true

                        let tk = {
                            MaSoTaiKhoan: 'TK001',
                            MaKH: 'KH001',
                            SoDuThuc: 5100000,
                            SoDuKhaDung: 5000000,
                            TrangThai: 1
                        }
                        this.taiKhoan = tk
                        this.display.account = true
                    }
                    else {
                        //Lấy khách hàng
                        $.get('http://localhost:9006/api/khachhang/LayKhachHangTheoCMND?CMND=' + this.cmnd, function (response) {
                            console.log(response);
                            if (response != null) {
                                //TODO hiển thị khách hàng
                                //Lấy tài khoản theo khách hàng
                                //hiển thị tài khoản
                            }
                        })
                    }
                }
                else {
                    this.clear()
                }
            },
            rutTien () {
                //console.log(this.giaoDich);
                if (this.message.content == emptyString) {
                    if (isDebug) {
                        this.message.content = 'Giao dịch đã thực hiện thành công'
                        this.message.type = success
                    }
                    else {
                        $.post('http://localhost:9006/api/giaodichruttien/themgiaodich', this.giaoDich, function (response) {
                            console.log(response);
                            if (response != null) {
                                //TODO post giao dịch chuyển tiền
                                //Post lệnh trừ tiền vào tài khoản

                                this.message.content = 'Giao dịch đã thực hiện thành công'
                                this.message.type = success
                            }
                        })
                    }
                }
            },
            validate () {
                this.message.content = emptyString
                this.message.type = warning

                if (isNullOrEmptyString(this.giaoDich.SoTien) || this.giaoDich.SoTien < 0) {
                    this.message.content += "Vui lòng nhập số tiền cần rút > 0 \n"
                }
                if (this.giaoDich.SoTien > this.taiKhoan.SoDuKhaDung) {
                    this.message.content += "Số tiền trong tài khoản không đủ để thực hiện giao dịch này \n"
                }
            },
            clear () {
                this.khachHang = emptyObject
                this.taiKhoan = emptyObject
                this.giaoDich = emptyObject
                this.display.customer = false
                this.display.account = false
                this.message.content = emptyString
                this.cmnd = emptyString
            }
        }
    })
})