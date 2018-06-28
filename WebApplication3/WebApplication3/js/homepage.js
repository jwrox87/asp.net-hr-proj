jQuery(function($){

    // Touch Device Detection
    var isTouchDevice = 'ontouchstart' in document.documentElement;
    if( isTouchDevice ) {
        $('html').removeClass('no-touch');
    }

});

jQuery(document).ready(function($) {

    jQuery('#feature-banner .owl-carousel').owlCarousel({
        loop: false,
        mouseDrag: true,
        nav: false,
        margin: 0,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
            },
            991: {
                items: 1,
            },
            992: {
                items: 1,
            }
        }
    });

    jQuery('#nus-highlights .owl-carousel').owlCarousel({
        loop: false,
        mouseDrag: true,
        nav: false,
        margin: 0,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,

            },
            991: {
                items: 1,
            },
            992: {
                items: 4,
            }
        }
    });

    jQuery('#instagram .owl-carousel').owlCarousel({
        loop: false,
        mouseDrag: true,
        nav: false,
        margin: 0,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
            },
            600: {
                items: 2,
            },
            767: {
                items: 3,
            },
            992: {
                items: 5,
            }
        }
    });
   
    if (jQuery('#thought-leadership .resizeHeight').length) {
        resizeHighlightsHeight();
        resizeTLHeight();
        jQuery(window).resize(function() {
            resizeHighlightsHeight();
            resizeTLHeight();
        });
    }

});

function resizeTLHeight() {

    var name = "#thought-leadership .resizeHeight";
    var maxHeight = 0;

    jQuery(name).css("height", "auto");

    jQuery(name).each(function(index, value) {
        if (jQuery(this).height() > maxHeight) {
            maxHeight = jQuery(this).height();
        }
    });

    jQuery(name).height(maxHeight);

}

function resizeHighlightsHeight() {

    var name = "#nus-highlights .headline";
    var maxHeight = 0;

    jQuery(name).css("height", "auto");

    jQuery(name).each(function(index, value) {
        if (jQuery(this).height() > maxHeight) {
            maxHeight = jQuery(this).height();
        }
    });

    jQuery(name).height(maxHeight+15);

}