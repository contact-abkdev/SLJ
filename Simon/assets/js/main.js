$(document).ready(function () {
    $("#btnSubmitOuter").click(function (e) {
        e.preventDefault();
        $("#btnSubmitInner").click();
    });

    var urlstring = location.pathname;
    if (urlstring != "")
    {
        var isActive = true;
        $(".navbar-nav li").each(function (e) { $(this).removeClass("active") });
        $(".navbar-nav li").each(function (e) {
            if ($(this).children(0).attr("href") == urlstring)
            {
                $(this).addClass("active");
                isActive = false;
            }
        });
        if (!isActive)
        {
            $(".navbar-nav li").children(0).addClass("active")
        }

    }

});