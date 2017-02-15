'use strict';
$(document).ready(function () {
    (function () {
        var sendFeedback = $('#send-feedback');

        sendFeedback.click(function (event) {

            event.preventDefault();

            var capthaResponsePlace = $('#capthaResponsePlace');
            var responsePlace = $('.feedbackResponsePlace');
            var feedbackForm = $("#feedbackForm");

            capthaResponsePlace.html('');

            feedbackForm.validate();

            if (feedbackForm.valid() === true) {
                $.ajax({
                    url: '/Feedbacks/Create',
                    type: 'POST',
                    data: {
                        UsersEmail: $('#UsersEmail').val(),
                        Content: $('#Content').val(),
                        CaptchaResponse: grecaptcha.getResponse()
                    },
                    dataType: 'text',
                    success: function (message) {
                        responsePlace.html('<span>' + message + '</span>');
                        if (message.localeCompare("Ваше повідомлення надіслано. Дякуємо!")) {
                            string_a.localeCompare(string_b);
                        }
                        sendFeedback.addClass("disabled");
                        //$('#UsersEmail').val('');
                        $('#Content').val('');
                    },
                    error: function (message) {
                        responsePlace.html('<span>Error: ' + message + '</span>');
                    },
                    beforeSend: function () {
                        responsePlace.html('<img src="/Content/Images/Misc/ajax-loader5.gif" alt="Wait" />');
                    }
                });
            }
        });
    })();
});