'use strict';
$(document).ready(function () {

    var flag = true;

    $('.sectionImg').click(function () {
            
        var img = $(this).children().first();

        if (flag) {
            $(img).addClass("Enlarged");
        }
        else {
            $(img).removeClass("Enlarged");
        }

        (flag) ? flag = false : flag = true;
    });
});