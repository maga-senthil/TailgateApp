$(window).scroll(function () {
    if ($(this).scrollTop() > 250) {
        $('.scrollToTop').fadeIn();
    } else {
        $('.scrollToTop').fadeOut();
    }
});


$('.scrollToTop').click(function () {
    $('html, body').animate({ scrollTop: 0 }, 1000);
    return false;
});