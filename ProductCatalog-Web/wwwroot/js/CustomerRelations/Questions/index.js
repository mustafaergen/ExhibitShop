(document).ready(function () {
    $('.answer-cell').on('click', function () {
        $(this).toggleClass('expanded');
        if ($(this).hasClass('expanded')) {
            $(this).css('white-space', 'normal');
        } else {
            $(this).css('white-space', 'nowrap');
        }
    });
});