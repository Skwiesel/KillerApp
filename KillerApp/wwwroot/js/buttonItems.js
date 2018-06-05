var buyItem = function (element) {
    $(element).click(function (event) {
        $.get($(this).data('url')).done(function (data) {

        });
    });
};
