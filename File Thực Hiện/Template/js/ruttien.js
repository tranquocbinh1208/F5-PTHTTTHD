//RÚT TIỀN
let isDebug = false
let emptyString = ''
let emptyObject = {}
let warning = 'alert-warning'
let success = 'alert-success'
let danger = 'alert-danger'
let info = 'alert-info'

let loggedUserId = 'NV001'

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
                MaGD: "GD",
                MaKH: emptyString,
                SoTien: 0,
                NoiDung: "Rut tien",
                MaNV: loggedUserId,
                NgayTao: new Date(),
                TrangThai: 0
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

                this.message.content = emptyString

                if (!isNullOrEmptyString(this.cmnd)) {
                    //Lấy khách hàng
                    axios.get('http://localhost:9006/api/khachhang/LayKhachHangTheoCMND?CMND=' + this.cmnd)
                        .then(response => {
                            if (response.data != null) {
                                this.khachHang = response.data
                                this.display.customer = true
                                this.giaoDich.MaKH = this.khachHang.MaKH
                                console.log(response.data)

                                //Lấy tài khoản của khách hàng
                                axios.get('http://localhost:9007/api/TaiKhoan/LayTaiKhoanTheoMaKH?MaKH=' + this.khachHang.MaKH)
                                    .then(response2 => {
                                        if (response2.data != null) {
                                            console.log(response2.data)

                                            this.taiKhoan = response2.data
                                            this.display.account = true

                                        } else {
                                            this.message.content = 'Không lấy được thông tin tài khoản của khách hàng ' + this.khachHang.HoTen
                                            this.message.type = danger
                                        }
                                    })
                                    .catch(e2 => {
                                        console.log(e2)
                                    })
                            } else {
                                this.message.content = 'Không tìm thấy thông tin'
                                this.message.type = info
                                this.display.customer = false
                                this.display.account = false
                            }
                        })
                        .catch(e => {
                            console.log(e)
                        })
                } else {
                    this.clear()
                }
            },

            rutTien() {
                if (this.message.content == emptyString && this.giaoDich.SoTien > 0) {

                    //Thực hiện lệnh trừ tiền vào tài khoản
                    var newTK = this.taiKhoan
                    newTK.SoDuKhaDung -= this.giaoDich.SoTien
                    newTK.SoDuThuc -= this.giaoDich.SoTien

                    axios.post('http://localhost:9007/api/taikhoan/CapNhatTaiKhoan', newTK)
                        .then(response => {
                            console.log(response.data)
                            if (response.data != null) {
                                this.taiKhoan = response.data
                            } else {
                                this.message.content = "Giao dịch thực hiện không thành công, vui lòng thử lại"
                                this.message.type = danger
                            }
                        })
                        .catch(e => {
                            this.errors.push(e)
                        })

                    //Thêm giao dịch rút tiền sau khi đã trừ tiền thành công    
                    axios.put('http://localhost:9000/api/giaodichruttien/themgiaodich', this.giaoDich)
                        .then(response2 => {
                            console.log(response2.data)
                            if (response2.data != null) {
                                this.giaoDich = response2.data
                                this.message.content = 'Giao dịch đã thực hiện thành công'
                                this.message.type = success
                            } else {
                                this.message.content = "Giao dịch thực hiện không thành công, vui lòng thử lại"
                                this.message.type = danger
                            }
                        })
                        .catch(e => {
                            this.errors.push(e)
                        })
                } else {
                    this.message.content = 'Vui lòng nhập số tiền > 0'
                }
            },

            validate() {
                this.message.content = emptyString
                this.message.type = warning

                if (isNullOrEmptyString(this.giaoDich.SoTien) || this.giaoDich.SoTien < 0) {
                    this.message.content += "Vui lòng nhập số tiền cần rút > 0 \n"
                }
                if (this.giaoDich.SoTien > this.taiKhoan.SoDuKhaDung) {
                    this.message.content += "Số dư trong tài khoản không đủ để thực hiện giao dịch này \n"
                }
                if (isNullOrEmptyString(this.giaoDich.NoiDung)) {
                    this.message.content += "Vui lòng nhập nội dung giao dịch \n"
                }
            },

            clear() {
                this.khachHang = emptyObject
                this.taiKhoan = emptyObject

                this.giaoDich.MaKH = emptyString
                this.giaoDich.SoTien = 0

                this.display.customer = false
                this.display.account = false
                this.message.content = emptyString
                this.cmnd = emptyString
            }
        }
    })
})