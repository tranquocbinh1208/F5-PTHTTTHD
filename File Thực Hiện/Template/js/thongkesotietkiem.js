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

var giaoDichs = []

function LoadTable() {
   $('#giaoDichs').dataTable({
      destroy: true,
      data: giaoDichs,
      columns: [{
            data: "MaGD",
            orderable: false,
            visible: false
         },
         {
            data: "MaKH",
            title: "Mã khách hàng",
         },
         {
            data: "SoTien",
            title: "Số tiền",
            render: function (data, type, row) {
               return data.toLocaleString()
            }
         },
         {
            data: "LaiSuat",
            title: "Lãi suất (%)",
            render: function (data, type, row) {
               return data.toLocaleString()
            }
         },
         {
            data: "KyHan",
            title: "Kỳ hạn (tháng)",
         },
         {
            data: "MaNV",
            title: "NV thực hiện",
         },
         {
            data: "TrangThai",
            title: "Trạng thái",
            render: function (data, type, row) {
               return data == 0 ? 'Đang xử lý' : (data == 1 ? 'Thành công' : (data == 2 ? 'Thất bại' : 'Hủy'))
            }
         },
         {
            data: "NgayTao",
            title: "Ngày lập sổ",
            render: function (data, type, row) {
               return moment(data).format('MM/DD/YYYY HH:mm:ss')
            }
         }
      ],
   });
}

$(function () {

   var thongKeGiaoDichApp = new Vue({

      el: '#thongKeGiaoDichApp',

      data: {
         tuNgay: moment().add(-14, 'days').format('MM/DD/YYYY'),
         denNgay: moment().format('MM/DD/YYYY'),

         gdTheoNgays: [],
         gdTheoThangs: [],
         gdTheoNams: [],

         message: {
            content: emptyString,
            type: warning
         },

         display: {
            gdTheoNgay: true
         }
      },
      methods: {

         formatDate(date) {
            return moment(date, 'YYYY-MM-DD').format('MM/DD/YYYY')
         },

         fetchData() {

            var dayDiff = moment(this.denNgay).dayOfYear() - moment(this.tuNgay).dayOfYear()
            if (dayDiff > 14) {
               this.message.content = 'Chỉ hỗ trợ xem báo cáo này trong vòng 2 tuần'
               this.message.type = warning
               this.display.gdTheoNgay = false
            } else {
               this.display.gdTheoNgay = true
               this.message.content = emptyString

               axios.get('http://localhost:9001/api/GiaoDichLapSoTietKiem/ThongKeGiaoDichTheoNgay?tuNgay=' + this.tuNgay + '&denNgay=' + this.denNgay)
                  .then(res => {
                     if (res.data != null) {
                        this.gdTheoNgays = res.data

                        var points = []
                        for (var index = 0; index < this.gdTheoNgays.length; index++) {
                           var a = this.gdTheoNgays[index];
                           var p = {
                              x: moment(a.Ngay).get('date'),
                              y: a.Count
                           }
                           points.push(p)
                        }
                        this.loadChartNgay(points)
                     } else {}
                  })
                  .catch(e2 => {
                     console.log(e2)
                  })
            }

            axios.get('http://localhost:9001/api/GiaoDichLapSoTietKiem/ThongKeGiaoDichTheoThang?tuNgay=' + this.tuNgay + '&denNgay=' + this.denNgay)
               .then(res => {
                  if (res.data != null) {
                     this.gdTheoThangs = res.data

                     var points = []
                     for (var index = 0; index < this.gdTheoThangs.length; index++) {
                        var a = this.gdTheoThangs[index];
                        var p = {
                           x: a.Thang,
                           y: a.Count
                        }
                        points.push(p)
                     }
                     this.loadChartThang(points)
                  } else {}
               })
               .catch(e2 => {
                  console.log(e2)
               })

            axios.get('http://localhost:9001/api/GiaoDichLapSoTietKiem/ThongKeGiaoDichTheoNam?tuNgay=' + this.tuNgay + '&denNgay=' + this.denNgay)
               .then(res => {
                  if (res.data != null) {
                     this.gdTheoNams = res.data

                     var points = []
                     for (var index = 0; index < this.gdTheoNams.length; index++) {
                        var a = this.gdTheoNams[index];
                        var p = {
                           x: a.Nam,
                           y: a.Count
                        }
                        points.push(p)
                     }
                     this.loadChartNam(points)
                  } else {}
               })
               .catch(e2 => {
                  console.log(e2)
               })

            axios.get('http://localhost:9001/api/GiaoDichLapSoTietKiem/LayGiaoDichTheoThoiGian?tuNgay=' + this.tuNgay + '&denNgay=' + this.denNgay)
               .then(res => {
                  if (res.data != null) {
                     giaoDichs = res.data
                     LoadTable()
                  } else {}
               })
               .catch(e2 => {
                  console.log(e2)
               })
         },

         loadChartNgay(points) {
            var chart = new CanvasJS.Chart("chartTheoNgay", {
               theme: "theme1",
               title: {
                  text: "Giao dịch mới theo ngày"
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
         },

         loadChartThang(points) {
            var chart = new CanvasJS.Chart("chartTheoThang", {
               theme: "theme1",
               title: {
                  text: "Giao dịch mới theo tháng"
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
         },

         loadChartNam(points) {
            var chart = new CanvasJS.Chart("chartTheoNam", {
               theme: "theme1",
               title: {
                  text: "Giao dịch mới theo năm"
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