$(".menu").on("click", function () {
    $(".menu i").toggleClass("fa-bars fa-times");
    $("#pages").toggleClass("pages pages-show");
});
$(".page-links li a").hover(function() {
    $(this).parent("li").css({
        "background-color": "white",
        "color": "black"
    });
}, function() {
    $(this).parent("li").css({
        "background-color": "black",
        "color": "white"
    });
});

