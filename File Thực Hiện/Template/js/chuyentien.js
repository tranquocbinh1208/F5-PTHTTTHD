//CHUYỂN TIỀN
let isDebug = true
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
    var chuyenTienApp = new Vue({
        el: '#chuyenTienApp',
        data: {
            nguoiGui: {
                MaKH: emptyString,
                HoTen: emptyString,
                CMND: emptyString
            },
            nguoiNhan: {
                MaKH: emptyString,
                HoTen: emptyString,
                CMND: emptyString
            },
            taiKhoanGui: {
                MaSoTaiKhoan: emptyString,
                MaKH: emptyString,
                SoDuThuc: 0,
                SoDuKhaDung: 0
            },
            taiKhoanNhan: {
                MaSoTaiKhoan: emptyString,
                MaKH: emptyString,
                SoDuThuc: 0,
                SoDuKhaDung: 0
            },
            giaoDich: {
                MaGD: "GD",
                MaKHGui: emptyString,
                MaKHNhan: emptyString,
                SoTien: 0,
                NoiDung: "Chuyen tien",
                MaNV: loggedUserId,
                NgayTao: new Date(),
                TrangThai: 0,
            },
            display: {
                soTienChuyen: false
            },
            message: {
                content: emptyString,
                type: warning
            },
            soTaiKhoanGui: emptyString,
            soTaiKhoanNhan: emptyString,
            daXacNhanThongTin: false
        },
        methods: {
            validate() {
                this.clearMessage()
                if (isNullOrEmptyString(this.giaoDich.SoTien) || this.giaoDich.SoTien < 1) {
                    this.message.content += 'Vui lòng nhập số tiền > 0 \n'
                }
                if (this.giaoDich.SoTien > this.taiKhoanGui.SoDuKhaDung) {
                    this.message.content += "Số dư trong tài khoản không đủ để thực hiện giao dịch này \n"
                }
                if (isNullOrEmptyString(this.giaoDich.NoiDung)) {
                    this.message.content += "Vui lòng nhập nội dung giao dịch \n"
                }
            },
            clear() {
                this.message.content = emptyString

                this.giaoDich.MaKHGui = emptyString
                this.giaoDich.MaKHNhan = emptyString
                this.giaoDich.SoTien = 0

                this.nguoiGui.HoTen = emptyString
                this.nguoiGui.CMND = emptyString
                this.taiKhoanGui.MaSoTaiKhoan = emptyString
                this.taiKhoanGui.SoDuKhaDung = 0

                this.nguoiNhan.HoTen = emptyString
                this.nguoiNhan.CMND = emptyString
                this.taiKhoanNhan.MaSoTaiKhoan = emptyString
                this.taiKhoanNhan.SoDuKhaDung = 0

                this.display.soTienChuyen = false
                this.daXacNhanThongTin = false
            },

            clearMessage() {
                this.message.content = emptyString
            },

            kiemTraTaiKhoanGui() {

                //Lấy tài khoản của khách hàng => MaKH
                axios.get('http://localhost:9007/api/TaiKhoan/LayTaiKhoanTheoSoTaiKhoan?soTK=' + this.taiKhoanGui.MaSoTaiKhoan)
                    .then(response => {
                        console.log('Send Account: ', response.data)
                        if (response.data != null) {
                            this.taiKhoanGui = response.data

                            //Lấy thông tin khách hàng từ MaKH
                            axios.get('http://localhost:9006/api/KhachHang/LayKhachHangTheoMaKH?MaKH=' + this.taiKhoanGui.MaKH)
                                .then(response2 => {
                                    console.log('Send customer: ', response2.data)
                                    if (response2.data != null) {
                                        this.nguoiGui = response2.data
                                        this.clearMessage()
                                    } else {
                                        this.message.content = 'Không tìm thấy thông tin khách hàng'
                                        this.message.type = warning
                                    }
                                })
                                .catch(e2 => {
                                    console.log(e2)
                                })
                        } else {
                            this.message.content = 'Không tìm thấy thông tin tài khoản'
                            this.message.type = warning
                        }
                    })
                    .catch(e => {
                        console.log(e)
                    })
            },

            kiemTraTaiKhoanNhan() {
                //Lấy tài khoản của khách hàng => MaKH
                axios.get('http://localhost:9007/api/TaiKhoan/LayTaiKhoanTheoSoTaiKhoan?soTK=' + this.taiKhoanNhan.MaSoTaiKhoan)
                    .then(response => {
                        console.log('Send Account: ', response.data)
                        if (response.data != null) {
                            this.taiKhoanNhan = response.data

                            //Lấy thông tin khách hàng từ MaKH
                            axios.get('http://localhost:9006/api/KhachHang/LayKhachHangTheoMaKH?MaKH=' + this.taiKhoanNhan.MaKH)
                                .then(response2 => {
                                    console.log('Send customer: ', response2.data)
                                    if (response2.data != null) {
                                        this.nguoiNhan = response2.data
                                        this.display.soTienChuyen = true
                                        this.clearMessage()
                                    } else {
                                        this.message.content = 'Không tìm thấy thông tin khách hàng'
                                        this.message.type = warning
                                    }
                                })
                                .catch(e2 => {
                                    console.log(e2)
                                })
                        } else {
                            this.message.content = 'Không tìm thấy thông tin tài khoản'
                            this.message.type = warning
                        }
                    })
                    .catch(e => {
                        console.log(e)
                    })
            },

            chuyenTien() {

                this.validate()

                if (isNullOrEmptyString(this.message.content)) {

                    //trừ tiền tk chuyển
                    var tkChuyen = this.taiKhoanGui
                    tkChuyen.SoDuKhaDung -= Number(this.giaoDich.SoTien)
                    tkChuyen.SoDuThuc -= Number(this.giaoDich.SoTien)

                    axios.post('http://localhost:9007/api/taikhoan/CapNhatTaiKhoan', tkChuyen)
                        .then(response => {
                            console.log(response.data)
                            if (response.data != null) {
                                this.taiKhoanGui = response.data
                            } else {
                                this.message.content = "Giao dịch thực hiện không thành công, vui lòng thử lại"
                                this.message.type = danger
                            }
                        })
                        .catch(e => {
                            this.errors.push(e)
                        })

                    //cộng tiền tk nhận
                    var tkNhan = this.taiKhoanNhan
                    tkNhan.SoDuKhaDung += Number(this.giaoDich.SoTien)
                    tkNhan.SoDuThuc += Number(this.giaoDich.SoTien)

                    axios.post('http://localhost:9007/api/taikhoan/CapNhatTaiKhoan', tkNhan)
                        .then(response => {
                            console.log(response.data)
                            if (response.data != null) {
                                this.taiKhoanNhan = response.data
                            } else {
                                this.message.content = "Giao dịch thực hiện không thành công, vui lòng thử lại"
                                this.message.type = danger
                            }
                        })
                        .catch(e => {
                            this.errors.push(e)
                        })

                    //thêm giao dịch chuyển tiền
                    //Thêm giao dịch rút tiền sau khi đã trừ tiền thành công
                    this.giaoDich.MaKHGui = this.nguoiGui.MaKH
                    this.giaoDich.MaKHNhan = this.nguoiNhan.MaKH

                    axios.put('http://localhost:9003/api/GiaoDichChuyenTien/themgiaodich', this.giaoDich)
                        .then(res => {
                            console.log(res.data)
                            if (res.data != null) {
                                this.giaoDich = res.data
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
                }
            }
        }
    })
})