$(function () {

    //Experience delete
    $("#expTable").on("click", ".expDelete", function () {
        var btn = $(this);
        bootbox.confirm("Deneyimi silmek istediğinize emin misiniz?", function (result) {
            if (result) {
                var btnId = btn.data("id");
                $.ajax({
                    method: "Post",
                    //dataType: "Json",
                    url: "/Experience/Delete",
                    data: { id: btnId }
                }).done(function (data) {
                    if (!data.hasError) {
                        alert(data.Message);
                        btn.parent().parent().remove();
                    } else if (data.hasError) {
                        alert(data.Message);
                    } else if (data.results) {
                        alert(data.Message);
                    }
                }).fail(function () {
                    alert('sunucu ile bağlantı kurulurken hata oluştu.')
                });
            }
        });

    });

    //ProjectsDone delete
    $("#projectDoneTable").on("click", ".projectDoneDelete", function () {
        var btn2 = $(this);
        bootbox.confirm("Projeyi silmek istediğinize emin misiniz?", function (result) {
            if (result) {
                var btnId2 = btn2.data("id");
                $.ajax({
                    method: "Post",
                    //dataType: "Json",
                    url: "/ProjectDone/Delete",
                    data: { id: btnId2 }
                }).done(function (data) {
                    if (!data.hasError) {
                        alert(data.Message);
                        btn.parent().parent().remove();
                    } else if (data.hasError) {
                        alert(data.Message);
                    } else if (data.results) {
                        alert(data.Message);
                    }
                }).fail(function () {
                    alert('sunucu ile bağlantı kurulurken hata oluştu.')
                });
            }
        });

    });
})