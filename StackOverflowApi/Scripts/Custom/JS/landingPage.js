
$(function () {

    $('span.fa-arrow-down').click(function () {
      
        $('html,body').animate({ scrollTop: $('.textData').offset().top });
    });

});
