$(document).ready(function () {
    getMessage();
});

function getMessage() {
    $.ajax({
        url: "/AlertMessage/GetTempData",
        type: "GET",
        dataType: "json",
        success: function (data) {
            if (data.ShowMessage) {
                var alertClass = getAlertClass(data.TypeMessage);
                showMessage(data.MessageToShow, alertClass);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function getAlertClass(typeMessage) {
    switch (typeMessage) {
        case 0:
            return "alert alert-info";
        case 1:
            return "alert alert-danger";
        case 2:
            return "alert alert-warning";
        case 3:
            return "alert alert-success";
        default:
            return "alert alert-info";
    }
}

function showMessage(message, alertClass) {
    var $alert = $("<div/>", {
        "class": alertClass,
        "role": "alert",
        "text": message
    });
    $("#container-alert-message").prepend($alert);
}