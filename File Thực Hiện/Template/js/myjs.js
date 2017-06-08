$(function () {
    $('[data-toggle="tooltip"]').tooltip();

    $(".side-nav .collapse").on("hide.bs.collapse", function () {
        $(this).prev().find(".fa").eq(1).removeClass("fa-angle-right").addClass("fa-angle-down");
    });

    $('.side-nav .collapse').on("show.bs.collapse", function () {
        $(this).prev().find(".fa").eq(1).removeClass("fa-angle-down").addClass("fa-angle-right");
    });

    //RÚT TIỀN

    //END RÚT TIỀN
    var rutTienApp = new Vue({
        el: '#rutTienApp',
        data: {
            cmnd: 'ok ban',
        },
        methods: {
            kiemTraTaiKhoan: function () {
                let a = "1212121212"
                this.cmnd = a
            },
            rutTien: function(){
                alert("rut tien thanh cong")
            }
        }
    })
})