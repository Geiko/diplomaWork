'use strict'
$(document).ready(function () {
    (function () {
        $('#createNewWork').click(function () {

            var sec = $('#sectionTitle').find(":selected").text();
            $('#secTitle').val(sec);
            $("#createWorkForm").submit();
        });


        $('#createNewPage').click(function () {

            //var sec = $('#sectionTitle').find(":selected").text();
            var wor = $('#workName').find(":selected").text();

            //$('#secTitle').val(sec);
            $('#worName').val(wor);

            $("#createWorkForm").submit();
        });

    })();
});
