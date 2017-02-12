'use strict';

$(document).ready(function () {

    var pageUrl = window.location.href
    var pageUrlPartial = pageUrl.split("/")[3]
    var pageUrlPartial = pageUrlPartial.split("?")[0]
       
    $('#menuActive li a').each(function (element) {

        var linkUrl = $(this).attr("href");
        var linkUrlPartial = linkUrl.split("/")[1]

        //console.log(pageUrlPartial);
        //console.log(linkUrlPartial);
        
        if (linkUrlPartial == pageUrlPartial) {

            $(this).addClass("activeBorder");
        }

    });
});