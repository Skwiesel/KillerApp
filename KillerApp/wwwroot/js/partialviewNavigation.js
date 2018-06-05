var registerAjaxLink = function (element, target) {
    $(element).click(function (event) {
        $.get($(this).data('url')).done(function (data) {
            $(target).html(data);
        });
    });
};

var registerAjaxLinkLoad = function (element, target) {
    $.get($(element).data('url')).done(function (data) {
        $(target).html(data);
    });
};