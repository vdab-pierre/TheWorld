(function() {
    "use strict";
    angular.module("simpleControls", [])
        .directive("waitCursor", waitCursor);
    function waitCursor() {
        return {
            scope: {
              show:"=displayWhen" //displayWhen kan nu gebruikt worden als attribuut van de waitcursor element 
            },
            //om de directive enkel te gebruiken als html element
            restrict:"E",
            templateUrl:"/views/waitCursor.html"
        };
    }
})();