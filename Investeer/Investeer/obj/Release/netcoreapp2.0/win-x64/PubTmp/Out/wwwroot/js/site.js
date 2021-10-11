function BindData() {
    var data =
    {
        county: $("#county").val()
        , pageIndex: $("#ddPageIndex").val()
        , pageSize: $("#ddPageSize").val()
    }
    $.ajax({
        type: "POST",
        url: "/Home/GetProperty",
        data: data,
        dataType: "json",
        success: function (response) {
            bindtable(response);

        },
        failure: function (response) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Unable to connect service',
            });
        },
        error: function (data) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: data.msg,
            });
        }
    });
}
const bindtable = function (data) {
    var bindhtml = "";
    var bindPager = "";
    //var pageIndex = parseInt($("#ddPageIndex").val());
    //$("#allProperty").html(bindhtml);
    //$("#ddPageIndex").html(bindPager);

    if (data != undefined) {
        if (data.properties) {
            data.properties.forEach(myFu => {
                if (myFu.Address != "") {
                    bindhtml += "<div class='col-md-4'>" +
                        "<div class='card-box-a card-shadow'>" +
                        "<div class='img-box-a'>" +
                        "<img src='../assets/img/property-6.jpg' alt='' class='img-a img-fluid'>" +
                        "</div>" +
                        "<div class='card-overlay'>" +
                        "<div class='card-overlay-a-content'>" +
                        "<div class='card-header-a'>" +
                        "<h2 class='card-title-a'>" +
                        "<a href='Property?requestProp=" + myFu.id+"'>" + myFu.county + "</a>" +
                        "</h2>" +
                        "<p class='property-address text-light'>" + myFu.address + "</p>" +
                        "</div>" +
                        "<div class='card-body-a'>" +
                        "<a class='btn btn-primary mb-3 quicksidebar' data-prop=" + myFu.id + ">Invest<span class='bi bi-chevron-right'></span>" +
                        "</a>" +
                        "</div>" +
                        "<div class='card-footer-a'>" +
                        "<ul class='card-info d-flex justify-content-center align-self-center align-items-center'>" +
                        "<li style='text-align: center; padding-left: 13%; padding-right: 13%;'>" +
                        "<h4 class='card-info-title'>APR</h4>" +
                        "<span>6.5</span>" +
                        "</li>" +
                        "<li style='text-align: center; border-left:1px solid rgba(0, 0, 0, 0.2); padding-left: 13%; padding-right: 13%;'>" +
                        "<h4 class='card-info-title'>LTV</h4>" +
                        "<span>70%</span>" +
                        "</li>" +
                        "<li style='text-align: center; border-left:1px solid rgba(0, 0, 0, 0.2); padding-left: 13%; padding-right: 13%;'>" +
                        "<h4 class='card-info-title'>Term</h4>" +
                        "<span>24</span>" +
                        "</li>" +
                        "</ul>" +
                        "<p class='p-3 text-center text-dark border-top-white small'>+30% funded by investors of total $300,000.00</p>" +
                        "</div>" +
                        "</div>" +
                        "</div>" +
                        "</div>" +
                        "</div>";
                }
                else {
                    bindhtml += "<div class='col-md-4'>" +
                        "<div class='card-box-a card-shadow'>" +
                        "<div class='img-box-a'>" +
                        "<img src='../assets/img/property-6.jpg' alt='' class='img-a img-fluid'>" +
                        "</div>" +
                        "<div class='card-overlay'>" +
                        "<div class='card-overlay-a-content' style='bottom: 0;'>" +
                        "<div class='card-header-a'>" +
                        "<h2 class='card-title-a'>" +
                        "<a href='#!'>" + myFu.county + "</a > " +
                        "</h2>" +
                        "<p class='property-address text-light'>Coming soon.</p>" +
                        "</div>" +
                        "<div class='card-body-a'>" +
                        "</div>" +
                        "</div>" +
                        "</div>" +
                        "</div>" +
                        "</div>";
                }
            });
        }
        if (data.pagecount) {
            if (data.pagecount > 1) {
                $("#ddPageIndex").parent(0).removeAttr('style');
            }
            else {
                $("#ddPageIndex").parent(0).attr('style', 'display: none');
            }
            for (var i = 1; i <= data.pagecount; i++) {
                bindPager += "<option value="+i+" "+(i==data.pageindex?"Selected":"")+"  >"+i+"</option>"
            }

            //if (data.pagecount > 3) {

            //    bindPager += "<li class='page-item " + (pageIndex == 1 ? "disabled" : '') + "'>" +
            //        "<a class='page-link' href='#' tabindex='-1' data-prop=" + (pageIndex - 3) + ">" +
            //        "<span class='bi bi-chevron-left' data-prop=" + (pageIndex - 3) + ">" + "</span>" +
            //        "</a>" +
            //        "</li>"
            //    if (pageIndex == 1) {
            //        for (var i = pageIndex; i <= pageIndex + 2; i++) {
            //            bindPager += "<li class='page-item " + (i == pageIndex ? "active" : "") + "'>" +
            //                "<a class='page-link' href='#' data-prop=" + i+">" + i + "</a>" +
            //                "</li>"
            //        }
            //    }
            //    else if (pageIndex == data.pagecount) {
            //        for (var i = pageIndex - 2; i <= pageIndex; i++) {
            //            bindPager += "<li class='page-item " + (i == pageIndex ? "active" : "") + "'>" +
            //                "<a class='page-link' href='#' data-prop=" + i + ">" + i + "</a>" +
            //                "</li>"
            //        }
            //    }
            //    else {
            //        for (var i = pageIndex - 1; i <= pageIndex + 1; i++) {
            //            bindPager += "<li class='page-item " + (i == pageIndex ? "active" : "") + "'>" +
            //                "<a class='page-link' href='#' data-prop=" + i + ">" + i + "</a>" +
            //                "</li>"
            //        }
            //    }
            //    bindPager +=
            //        "<li class='page-item next " + (pageIndex == data.pagecount ? "disabled" : '') + "'>" +
            //    "<a class='page-link' href='#' data-prop=" + (pageIndex + 3) +">" +
            //        "<span class='bi bi-chevron-right' ></span>" +
            //        "</a>" +
            //        "</li>"

            //}
            //else {
            //    bindPager += "<li class='page-item disabled'>" +
            //        "<a class='page-link' href='#' tabindex='-1'>" +
            //        "<span class='bi bi-chevron-left'>" + "</span>" +
            //        "</a>" +
            //        "</li>"
            //    for (var i = 1; i <= data.pagecount; i++) {
            //        bindPager += "<li class='page-item " + (i == pageIndex ? "Active" : "") + "'>" +
            //            "<a class='page-link' href='#' data-prop=" + i + ">" + i + "</a>" +
            //            "</li>"
            //    }
            //    bindPager +=
            //        "<li class='page-item next disabled'>" +
            //        "<a class='page-link' href='#'>" +
            //        "<span class='bi bi-chevron-right'>" + "</span>" +
            //        "</a>" +
            //        "</li>"

            //}

        }
    }
    $("#ddPageIndex").html(bindPager);
    $("#allProperty").html(bindhtml);

}
