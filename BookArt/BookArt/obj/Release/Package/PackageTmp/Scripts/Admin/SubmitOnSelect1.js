'use strict'
$(document).ready(function () {
    (function () {

        $('#sectionTitle').change(function () {

            $('#sectionFlag').val('yes');
            $('#filterForm').submit();
        });


        $('#workName').change(function () {

            $('#sectionFlag').val('no');
            $('#filterForm').submit();
        });

    })();
});
