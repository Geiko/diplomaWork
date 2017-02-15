'use strict'
$(document).ready(function () {
    $('#addUrl').click(function () {

        var id = $('#id').val();
        $("#Section_CoverUrl").attr("value", "/Content/Images/Sections/SectionCover_" + id + ".jpg");
        $("#Work_CoverUrl").attr("value", "/Content/Images/Works/WorkCover_" + id + ".jpg");
        $("#Page_ImgUrl").attr("value", "/Content/Images/Pages/PageCover_" + id + ".jpg");
    });
}); 