'use strict';
$(document).ready(function () {
    (function () {

        $('.dart').click(function () {

            document.body.style.overflow = "hidden";

            $('.wrapper_1').slideUp(1000, function () {
                window.location.replace("/Project/Index");
            });

            $('.wrapper_2').slideDown(100, function () { });
        })
    })();
});