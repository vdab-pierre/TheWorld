//site.js
(function () {
    
    var el = $("#username");
    el.text("Watt?");
    var main = $("#main");
    main.on("mouseenter", function() {
        main.css('background-color','#888');
    });
    main.on("mouseleave", function() {
        main.css('background-color', '');
    });

    var menuitems = $("ul.menu li a");

    menuitems.on("click", function() {
        alert("Hallo!");
    });

})();

