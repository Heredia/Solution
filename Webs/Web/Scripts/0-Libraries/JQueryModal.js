(function ($) {
    $.modal = function () {
        return {
            alert: function (title, content, buttonText, handlerOk) {
                var alertId = "modal-alert";
                var buttonOkId = alertId + "-button-ok";

                $("#" + alertId).remove();

                var element =
                "<div id='" + alertId + "' class='modal modal-background alert'>" +
                    "<div class='modal-body'>" +
                        "<div class='modal-title'>" + title + "</div>" +
                        "<div class='modal-content'>" + content + "</div>" +
                        "<div class='modal-buttons'>" +
                            "<button id='" + buttonOkId + "'>" + buttonText + "</button>" +
                        "</div>" +
                    "</div>" +
                "</div>";

                $("body").append(element);

                $("#" + buttonOkId).click(function () {
                    $("#" + alertId).remove();
                    if (handlerOk) {
                        handlerOk();
                        handlerOk = undefined;
                    }
                });

                $("#" + alertId).show();
            },

            confirm: function (title, content, buttonYesText, buttonNoText, handlerYes, handlerNo) {
                var confirmId = "modal-confirm";
                var buttonYesId = confirmId + "-button-yes";
                var buttonNoId = confirmId + "-button-no";

                $("#" + confirmId).remove();

                var element =
                "<div id='" + confirmId + "' class='modal modal-background confirm'>" +
                    "<div class='modal-body'>" +
                        "<div class='modal-title'>" + title + "</div>" +
                        "<div class='modal-content'>" + content + "</div>" +
                        "<div class='modal-buttons'>" +
                            "<button id='" + buttonYesId + "'>" + buttonYesText + "</button>" +
                            "<button id='" + buttonNoId + "'>" + buttonNoText + "</button>" +
                        "</div>" +
                    "</div>" +
                "</div>";

                $("body").append(element);

                $("#" + buttonYesId).click(function () {
                    $("#" + confirmId).remove();
                    if (handlerYes) {
                        handlerYes();
                        handlerYes = undefined;
                    }
                });

                $("#" + buttonNoId).click(function () {
                    $("#" + confirmId).remove();
                    if (handlerNo) {
                        handlerNo();
                        handlerNo = undefined;
                    }
                });

                $("#" + confirmId).show();
            },

            custom: function (title, content, buttonsArray) {
                var customId = "modal-custom";

                $("#" + customId).remove();

                var buttons = "";
                var buttonId;
                var i;
                for (i = 0; i < buttonsArray.length; i++) {
                    buttonId = customId + "-button-" + i;
                    var buttonText = buttonsArray[i].Text;
                    buttons += "<button id='" + buttonId + "'>" + buttonText + "</button>";
                }

                var element =
                "<div id='" + customId + "' class='modal modal-background alert'>" +
                    "<div class='modal-body'>" +
                        "<div class='modal-title'>" + title + "</div>" +
                        "<div class='modal-content'>" + content + "</div>" +
                        "<div class='modal-buttons'>" +
                            buttons +
                        "</div>" +
                    "</div>" +
                "</div>";

                $("body").append(element);

                for (i = 0; i < buttonsArray.length; i++) {

                    buttonId = customId + "-button-" + i;

                    $("#" + buttonId).click(function () {
                        $("#" + customId).remove();

                        var array = $(this)[0].id.split("-");
                        var id = array[array.length - 1];

                        var buttonHandler = buttonsArray[id].Handler;
                        if (buttonHandler) { buttonHandler(); }
                    });
                };

                $("#" + customId).show();
            }
        };
    };

    $.fn.modal = function () {
        var $this = $(this);

        return {
            hide: function () {
                $this.hide();
                return $this;
            },

            show: function () {
                $this.show();
                return $this;
            }
        };
    };
}(jQuery));