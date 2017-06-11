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

var khachHangs = []

function LoadTable() {
      $('#khachHangs').dataTable({
            destroy: true,
            data: khachHangs,
            columns: [{
                        data: "MaKH",
                        orderable: false,
                        visible: false
                  },
                  {
                        data: "HoTen",
                        title: "Họ tên",
                  },
                  {
                        data: "NgaySinh",
                        title: "Ngày sinh",
                        render: function (data, type, row) {
                              return moment(data).format('MM/DD/YYYY');
                        }
                  },
                  {
                        data: "GioiTinh",
                        title: "Giới tính",
                        render: function (data, type, row) {
                              return data ? 'Nam' : 'Nữ';
                        }
                  },
                  {
                        data: "SDT",
                        title: "SDT",
                  },
                  {
                        data: "CMND",
                        title: "CMND",
                  },
                  {
                        data: "DiaChi",
                        title: "Địa chỉ",
                  },
                  {
                        data: "NgayTao",
                        title: "Ngày tạo",
                        render: function (data, type, row) {
                              return moment(data).format('MM/DD/YYYY HH:mm:ss');
                        }
                  }
            ],
      });
}

$(function () {

      var thongKeKhachHangApp = new Vue({

            el: '#thongKeKhachHangApp',

            data: {
                  tuNgay: moment().add(-14, 'days').format('MM/DD/YYYY'),
                  denNgay: moment().format('MM/DD/YYYY'),

                  khTheoNgays: [],
                  khTheoThangs: [],
                  khTheoNams: [],

                  message: {
                        content: emptyString,
                        type: warning
                  },

                  display: {
                        khTheoNgay: true
                  }
            },
            methods: {

                  formatDate(date) {
                        return moment(date, 'YYYY-MM-DD').format('MM/DD/YYYY')
                  },

                  fetchData() {

                        var dayDiff = moment(this.denNgay).dayOfYear() - moment(this.tuNgay).dayOfYear() //Math.abs(this.tuNgay.getTime() - this.denNgay.getTime());
                        if (dayDiff > 14) {
                              this.message.content = 'Chỉ hỗ trợ xem báo cáo này trong vòng 2 tuần'
                              this.message.type = warning
                              this.display.khTheoNgay = false
                        } else {
                              this.display.khTheoNgay = true
                              this.message.content = emptyString

                              axios.get('http://localhost:9006/api/khachhang/ThongKeKhachHangTheoNgay?tuNgay=' + this.tuNgay + '&denNgay=' + this.denNgay)
                                    .then(res => {
                                          if (res.data != null) {
                                                this.khTheoNgays = res.data

                                                var points = []
                                                for (var index = 0; index < this.khTheoNgays.length; index++) {
                                                      var a = this.khTheoNgays[index];
                                                      var p = {
                                                            x: moment(a.Ngay).get('date'),
                                                            y: a.Count
                                                      }
                                                      points.push(p)
                                                }
                                                this.loadChart(points)

                                                console.log(points)

                                          } else {}
                                    })
                                    .catch(e2 => {
                                          console.log(e2)
                                    })
                        }

                        axios.get('http://localhost:9006/api/khachhang/ThongKeKhachHangTheoThang?tuNgay=' + this.tuNgay + '&denNgay=' + this.denNgay)
                              .then(res => {
                                    if (res.data != null) {
                                          this.khTheoThangs = res.data
                                    } else {}
                              })
                              .catch(e2 => {
                                    console.log(e2)
                              })

                        axios.get('http://localhost:9006/api/khachhang/ThongKeKhachHangTheoNam?tuNgay=' + this.tuNgay + '&denNgay=' + this.denNgay)
                              .then(res => {
                                    if (res.data != null) {
                                          this.khTheoNams = res.data
                                    } else {}
                              })
                              .catch(e2 => {
                                    console.log(e2)
                              })

                        axios.get('http://localhost:9006/api/khachhang/LayKhachHangTheoThoiGian?tuNgay=' + this.tuNgay + '&denNgay=' + this.denNgay)
                              .then(res => {
                                    if (res.data != null) {
                                          khachHangs = res.data
                                          LoadTable()
                                    } else {}
                              })
                              .catch(e2 => {
                                    console.log(e2)
                              })
                  },

                  loadChart(points) {
                        var chart = new CanvasJS.Chart("chartContainer1", {
                              theme: "theme1",
                              title: {
                                    text: "Khách hàng mới theo ngày"
                              },
                              animationEnabled: true,
                              axisX: {
                                    //valueFormatString: "dd/MM",
                                    interval: 1,
                                    //intervalType: "day"
                              },
                              axisY: {
                                    includeZero: false
                              },
                              data: [{
                                    type: "line",
                                    //lineThickness: 3,
                                    dataPoints: points
                              }]
                        });

                        chart.render();
                  }
            }
      })
})