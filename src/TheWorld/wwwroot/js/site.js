//site.js
(function () {
    
    //var el = $("#username");
    //el.text("Watt?");
    //var main = $("#main");
    //main.onmouseenter("mouseenter", function() {
    //main.style = "background-color: #888;"; works on iee and firefox but not on chrome
    //main.style["background-color"]="#888;";
    //    main.css('background-color','#888');
    //});
    //main.onmouseleave("mouseleave", function() {
    //    main.css('background-color', '');
    //});

    //var menuitems = $("ul.menu li a");

    //menuitems.onclick("click", function () {
    //    var me = $(this);
    //    alert(me.text());
    //});

    var $sidebarAndWrapper = $("#sidebar,#wrapper");
    var $icon = $("#sidebarToggle i.fa");
    $("#sidebarToggle").on("click", function() {
        $sidebarAndWrapper.toggleClass("hide-sidebar");
        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $icon.removeClass("fa-angle-left");
            $icon.addClass("fa-angle-right");
        } else {
            $icon.removeClass("fa-angle-right");
            $icon.addClass("fa-angle-left");
        }
    });
    
})();

