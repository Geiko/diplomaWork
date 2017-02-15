'use strict';

$(document).ready(function () {

    var pageUrl = window.location.href
    var pageUrlPartial = pageUrl.split("/")[4]
    if (pageUrlPartial === undefined) {
        pageUrlPartial = 'Dashboard';
    }

    $('#menuActiveAdmin li a').each(function (element) {

        var linkUrl = $(this).attr("href");
        var linkUrlPartial = linkUrl.split("/")[2]
        if (linkUrlPartial === undefined) {
            linkUrlPartial = 'Dashboard';
        }
        
        //console.log(pageUrlPartial + '   ' + linkUrlPartial);

        if (linkUrlPartial == pageUrlPartial ) {

            $(this).addClass("activeBorderAdmin");
        }

    });

    $('.navbar-right').children().last().addClass('activeBorder');
});