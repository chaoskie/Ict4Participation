$(function () {

    // Script om de errors weg te halen als erop geklikt wordt
    $('.error').on('click', function () {

        $(this).addClass('error-hidden');

    });

    //Script to show and hide password
    $('.psr').hover(function () {
        $('#inputWachtwoord1').attr('type', 'text');
    }, function () {
        $('#inputWachtwoord1').attr('type', 'password');
    });

});