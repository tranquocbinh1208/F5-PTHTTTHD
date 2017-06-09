//RÚT TIỀN
let isDebug = false
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
            khachHang: {
                MaKH: emptyString,
                HoTen: emptyString,
                CMND: emptyString
            },
            taiKhoan: {
                MaSoTaiKhoan: emptyString,
                MaKH: emptyString,
                SoDuThuc: 0,
                SoDuKhaDung: 0
            },
            giaoDich: {
                MaKH: emptyString,
                SoTien: emptyString,
                NoiDung: emptyString,
                MaNV: emptyString
            },
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

            kiemTraTaiKhoan() {
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
                    } else {
                        //Lấy khách hàng
                        let kh = {}
                        let tk = {}

                        $.get('http://localhost:9006/api/khachhang/LayKhachHangTheoCMND?CMND=' + this.cmnd, function (response) {
                            if (response != null) {
                                kh = response
                                console.log(kh)

                                //Lấy tài khoản theo khách hàng
                                $.get('http://localhost:9007/api/TaiKhoan/LayTaiKhoanTheoMaKH?MaKH=' + kh.MaKH, function (response2) {
                                    if (response2 != null) {
                                        tk = response2
                                        console.log(tk)
                                    }
                                })
                            }
                        })

                        this.khachHang = kh
                        this.taiKhoan = tk
                        this.display.account = true
                        this.display.customer = true
                    }
                } else {
                    this.clear()
                }
            },

            rutTien() {
                if (this.message.content == emptyString) {
                    if (isDebug) {
                        this.message.content = 'Giao dịch đã thực hiện thành công'
                        this.message.type = success
                    } else {
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

            validate() {
                this.message.content = emptyString
                this.message.type = warning

                if (isNullOrEmptyString(this.giaoDich.SoTien) || this.giaoDich.SoTien < 0) {
                    this.message.content += "Vui lòng nhập số tiền cần rút > 0 \n"
                }
                if (this.giaoDich.SoTien > this.taiKhoan.SoDuKhaDung) {
                    this.message.content += "Số tiền trong tài khoản không đủ để thực hiện giao dịch này \n"
                }
            },

            clear() {
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