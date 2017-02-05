'use strict';

$(document).ready(function () {

    var pageUrl = window.location.href
    var pageUrlPartial = pageUrl.substr(pageUrl.lastIndexOf("/") + 1);
       
    $('#menuActive li a').each(function (element) {

        var linkUrl = $(this).attr("href");
        var linkUrlPartial = linkUrl.substr(linkUrl.lastIndexOf("/") + 1);
        if (linkUrlPartial == pageUrlPartial) {

            $(this).addClass("activeBorder");
        }
    });
});