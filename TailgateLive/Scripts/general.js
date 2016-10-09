//tabs at details section
$(document).ready(function() {

    $(function() {
        $("#tabs").tabs();
    });
});
//Nav to all sections
jQuery(document).ready(function($) {
    jQuery('#top #top-section .menu > ul > li > a,#top #top-section .mobile-menu > ul > li > a, a#go-top, a#get-down').click(function() {
        jQuery.scrollTo($(this).attr("href"), {
            duration: 1000,
            easing: 'easeInOutExpo'
        });
        return false;
    });
});
//mobile menu
$(document).ready(function() {
    $('a#mobile').click(function() {
        $('#top-section .mobile-menu').slideToggle('fast');
        return false;
    });
});
