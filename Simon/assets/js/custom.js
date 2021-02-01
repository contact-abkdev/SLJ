(function( $ ){
    'use strict';

    //on DOM ready
    $( document ).ready( function (e) {
        bannerImage();
        headerFixed();
        alignImage();
    });

    //on WINDOW Resize
    $(window).resize(function(e){
    	headerFixed();
    });

    //background-banner
    function bannerImage(){
        $('.banner-img').children('img').each(function(n, img) {
           var $img = $(img);
           var $imgUrl = $(this).attr('src');
           $img.closest('.banner').css({
                'background': 'transparent url(' + $imgUrl +') center center no-repeat',
                'background-size': 'cover',
                '-webkit-background-size': 'cover',
                '-moz-background-size': 'cover',
                '-o-background-size': 'cover',
                '-ms-background-size': 'cover',
           });
           $img.hide(); 
        });
    }

    //fixed-header-offset
    function headerFixed(){
        var $header_height = $('.header').outerHeight();
        var $collapse_height = $('.navbar-collapse.in').outerHeight();
        var $wrapper = $('#wrapper');

        if($(window).width() < 768){
            var $total_height = $header_height - $collapse_height;
            $wrapper.css('padding-top', $total_height +'px');
        }else{
            $wrapper.css('padding-top', $header_height +'px');
        }
    }

    //image-align
    function alignImage(){
        $('.content-img').each(function(index, e) {
           if($(this).parent().siblings().hasClass('pull-right')){
                $(this).addClass('img-left');
            }else{
                $(this).removeClass('img-left');
            } 
        });
    }
}(jQuery));

