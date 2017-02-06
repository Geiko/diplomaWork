'use strict';
//$(document).ready(function () {

    var durationBetweenLetters = 0;
    if (isFirstEnter == 1) {
        durationBetweenLetters = 1000;
    }

    setTimeout(addName, picture.durationK + picture.durationT - durationBetweenLetters);
    setTimeout(addMenu, picture.durationK + picture.durationT);
    setTimeout(addArrow, picture.durationK + picture.durationT + durationBetweenLetters);
    setTimeout(addYear, picture.durationK + picture.durationT + 2 * durationBetweenLetters);


    function addName() {
        $('.string1_1').text('Кость Ткаченко');
        $('.string2_1').text('вільна творча одиниця');
    };

    function addMenu() {
        $('#aProjects').text('проекти');
        $('#aAbout').text('про себе');
        $('#aWrite').text('написати');
    };

    //function addArrow() {
    //    $('#aArrow').html('<img src="/Content/Images/arrow.png" alt="arrow" />');
    //};

    function addArrow() {
        $('.dart').html('<img src="/Content/Images/arrow.png" alt="arrow" height=30 />');
    };

    function addYear() {
        $('.footer').html('<p> &copy; ' + new Date().getFullYear() + ' - Дніпро, Україна</p>');
        if (isFirstEnter == 1) {
            footAnimate();
        }
    };

//});




