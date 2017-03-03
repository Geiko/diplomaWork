'use strict';
$(document).ready(function () {
    (function () {

        var local = {
            titleArray: ['Transform a dummy to JSON (using Bézier curves)',
                         'Переведи макет в JSON (с помощью кривых Безье)',
                         'Переведи макет в JSON (за допомогою кривих Безьє)'],
            dblClickArray: [' - create new dot.', ' - создать новую точку.', ' - створити нову точку.'],
            deleteDotArray: [' - delete a dot.', ' - удалить точку.', ' - знищити точку.'],
            dragDotArray: [' a dot.', ' точку.', ' точку.'],

            sheetArray: ['Sheet', 'Лист', 'Лист'],
            uploadDummyArray: ['Upload Dummy', 'Загрузить макет', 'Завантажити макет'],
            deleteDummyArray: ['Delete Dummy', 'Удалить макет', 'Знищити макет'],
            opacityArray: ['Opacity: ', 'Непрозрачность: ', 'Непрозорість: '],
            colorArray: ['Color: ', 'Цвет', 'Колір'],

            dotsArray: ['Dots', 'Точки', 'Точки'],
            curveArray: ['Curve', 'Кривая', 'Крива']
        };
        //-----------------------------------------------------------------------------------------------

        var setLanguage = function () {
            $('#TitleSpan').text(local.titleArray[+$('#language').find(":selected").val()]);
            $('#dblClick').text(local.dblClickArray[+$('#language').find(":selected").val()]);
            $('#deleteDot').text(local.deleteDotArray[+$('#language').find(":selected").val()]);
            $('#dragDot').text(local.dragDotArray[+$('#language').find(":selected").val()]);

            $('#adjustPlateButton').val(local.sheetArray[+$('#language').find(":selected").val()]);
            $('#getvalLabel').html(local.uploadDummyArray[+$('#language').find(":selected").val()]);
            $('#deleteImg').html(local.deleteDummyArray[+$('#language').find(":selected").val()]);
            $('.opacityMenu').text(local.opacityArray[+$('#language').find(":selected").val()]);
            $('#colorPickerButton').val(local.colorArray[+$('#language').find(":selected").val()]);

            $('#adjustDotsButton').val(local.dotsArray[+$('#language').find(":selected").val()]);
            $('#adjustLineButton').val(local.curveArray[+$('#language').find(":selected").val()]);
        };
        //-----------------------------------------------------------------------------------------------

        setLanguage();

        $('#language').change(function () {
            setLanguage();
        });


    })();
});