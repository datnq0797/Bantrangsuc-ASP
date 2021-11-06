$(document).ready(function () {



    //----add cart
    $(".addcart").click(function (e) {

        $.ajax({
            url: "/Home/AddCart",
            data: {
                idPro: $(this).attr("dataPro"), namePro: $(this).attr("dataNamePro"),
                pricePro: $(this).attr("dataPricePro"), pathPro: $(this).attr("dataPath"), detailPro: $(this).attr("dataDetail")
            },
            success: function (response) {
                $("#QuatityMyCart").text(response);
                alert("đã thêm sản phẩm");              
            }

        });
        e.preventDefault();
    });

    //----delete cart
    $(".DelCart").click(function (e) {
        $.ajax({
            type: "post",
            url: "/Home/DelCart/",
            data: {
                idPro: $(this).attr("dataIdPro")
            },
            success: function (response) {
                if (response == 1)
                    alert("đã xóa");
                else
                    alert("chưa xóa");

                window.location.href = "/Cart/ShowCart";
            }

        });
        e.preventDefault();
    });

    

    //--- tăng số lượng trong cart
    $(".quantityPro").change(function () {
        var id = "#totalSP_" + $(this).attr("dataIdPro");
        $.ajax({
            url: "/Cart/UpdateCart",
            data: { idPro: $(this).attr("dataIdPro"), quantity: $(this).val() },
            success: function (reponse) {

                $(id).text(reponse);

                $.ajax({
                    url: "/Cart/TotalCart",
                    success: function (reponse) {
                        $("#subTotal").text(reponse);
                        $("#subTotal2").text(reponse);
                    }
                })
            }
        })
    });

    //----phân trang
    $(".page-link1").click(function () {
       
        var pagelinkThis = $(this);
        $.ajax({
            url: "/Products/PageNaviProduct/",
            data: { page: $(pagelinkThis).attr("data-page"), idcate: $(pagelinkThis).attr("data-cate")},
            success: function (response) {

                $(".pagenavPro").html(response);

                $(".page-item").removeClass("active");

                $(pagelinkThis).parent().addClass("active");

            }
        })
        e.preventDefault();
    });

});