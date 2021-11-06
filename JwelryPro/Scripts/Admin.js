/// <reference path="../areas/admin/plugins/ckeditor/config.js" />
/// <reference path="../areas/admin/plugins/ckeditor/config.js" />
$(document).ready(function () {

    //----choose file browser picture 
    $(document).on("click", ".browse", function () {
        var file = $(this).parents().find(".file");
        file.trigger("click");
    });
    $('input[type="file"]').change(function (e) {
        var fileName = e.target.files[0].name;
        $("#file").val(fileName);

        var reader = new FileReader();
        reader.onload = function (e) {
            // get loaded data and render thumbnail.
            document.getElementById("preview").src = e.target.result;
        };
        // read the image file as a data URL.
        reader.readAsDataURL(this.files[0]);
    });

    //--- nút login
    $("#Btn_login").click(function () {
        
        $.ajax({
            type: "post",
            url: "/Admin/Employee/Login",
            data: {
                users: $("#InputEmail").val(),
                pass: $("#InputPassword").val()
            },
            success: function (result) {
                if (result == "Fail") {
                    alert(result);
                }
                else {
                    window.location.href = "/Admin/Categories/TableSanPham";
                }
            }
        })
        e.preventDefault();
    });

    //<<<<<<<<modal thêm
    $("#btn_AddPro").click(function () {
        $(".modal").show();
    });

    $("#close_md").click(function () {
        $(".modal").hide();
    });

    
    $(".custom-file").click(function () {
        $(".modal").hide();

    });

   
    //---- xóa sản phẩm
    $(document).on("click", ".btn_XoaSP", function () {
        
        $.ajax({
            type: "POST",
            url: "/Admin/Categories/DelSanPham",
            data: {
                idpro: $(this).attr("dataID")
            },
            success: function (result) {
                if (result == "Fail") {
                    alert(result);
                }
                else {
                    window.location.href = "/Admin/Categories/TableSanPham";
                }
            }

        });
        e.preventDefault();
    });


    //---xử lý phần thêm ảnh , và CKEditor
    $("#btnSelectImage").click(function (e) { 
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            $('#txtImage').val(fileUrl);
        };
        finder.popup();
        e.preventDefault();
    });

    var editor = CKEDITOR.replace('txtContent', {
        customConfig:'~/Areas/Admin/plugins/ckeditor/config.js',

    });
  
    
});
