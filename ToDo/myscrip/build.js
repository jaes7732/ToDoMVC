$(document).ready(function () {
    $.ajax({
        url: '/List/BuildTable',
        success: function (result) {
            $('#tableDiv').html(result);
        }



    });




});