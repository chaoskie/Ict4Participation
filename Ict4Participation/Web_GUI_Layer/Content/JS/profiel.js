$('h2#username[contenteditable]').focusout(function () {
    
    // stuur async request
    $.ajax({
        type: 'POST',
        url: 'profiel.aspx/ChangeUserName',
        data: '{str: "' + $('h2#username').text() + '"}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {
            $('h2#username').text(result.d);
        }
    });

});

$('h3#userdescription[contenteditable]').focusout(function () {

    // stuur async request
    $.ajax({
        type: 'POST',
        url: 'profiel.aspx/ChangeUserDescription',
        data: '{str: "' + $('h3#userdescription').text() + '"}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {
            $('h3#userdescription').text(result.d);
        }
    });

});

// Script met de functionaliteiten om profiel info te zoeken en weer te geven
$(function () {

    $('a[data-id]').hover(function (event) {

        // Haal het data-id op van de op te halen gebruiker
        var id = $(this).attr('data-id');

        $.ajax({
            type: 'POST',
            url: 'profiel.aspx/GetUser',
            data: '{id: "' + id + '"}',
            contentType: 'application/json;charset=utf-8',
            dataType: 'json',
            success: function (result) {
                // Haal het overlay element op
                var hoofdelement = $('#zoek_profiel_overlay');

                // Haal de data uit de string
                var profiel_naam = result.split('|')[0];
                var profiel_type = result.split('|')[1];
                var profiel_quote = result.split('|')[2];
                var profiel_foto = result.split('|')[3];

                console.log(result.d);

                // Zet de data naar het element
                $(hoofdelement).find('.zoek-profiel-foto').attr('src', profiel_foto);
                $(hoofdelement).find('.zoek-profiel-naam').text(profiel_naam);
                $(hoofdelement).find('.zoek-profiel-type').text(profiel_type);
                $(hoofdelement).find('.zoek-profiel-quote').text(profiel_quote);

                // Zet het element naar 'actief' om het zichtbaar te maken
                $(hoofdelement).addClass('actief');

                // Zet de positie van de overlay naar 50px onder de muispositie
                var posX = event.pageX;
                if ((posX + $(hoofdelement).width()) > (window.innerWidth)) {

                    posX = window.innerWidth - $(hoofdelement).width() - 50;

                }

                // Zet het element naar de positie
                $(hoofdelement).css({ left: posX, top: event.pageY + 10 });
            }
        });

    }, function (event) {

        // Haal de klasse 'actief' weg om het element onzichtbaar te maken
        $('#zoek_profiel_overlay').removeClass('actief');

    });

});