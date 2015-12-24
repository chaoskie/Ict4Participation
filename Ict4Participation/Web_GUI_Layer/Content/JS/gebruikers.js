$('#inputZoeken').on('keyup click', function () {
    var val = $(this).val();

    $.ajax({
        type: 'POST',
        url: 'gebruikers.aspx/SearchUsers',
        data: '{str: "' + val + '"}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {
            // Maak lijst leeg
            $('#gebruikers_lijst').empty();

            // Split string
            var gebruikers = result.d.split(':');

            // Loop door de gebruikers array
            for (var i = 0; i < gebruikers.length; i++) {
                // Check of er een gebruiker is op plek i
                if (gebruikers[i] != "") {
                    // Split de gebruiker om de naam en het id van de gebruiker te scheiden
                    gebruikers[i] = gebruikers[i].split(',');

                    // Append nieuwe gebruiker in lijst
                    $('#gebruikers_lijst').append('<li><a href="#" data-id="' + gebruikers[i][1] + '">' + gebruikers[i][0] + '</a></li>');
                }
            }

            // Append bericht als er geen gebruikers gevonden zijn
            if (gebruikers.length == 1 && gebruikers[0] == "") {
                $('#gebruikers_lijst').append('<li><a href="#">Geen gebruikers gevonden</a></li>');
            }
        }
    });

});

/* FUNCTIE WERKT NIET! */
/*
$('body').on('click', 'a', function () {

    console.log('hallo');

    // Haal het data-id op van de op te halen gebruiker
    var id = $(this).attr('data-id');

    $.ajax({
        type: 'POST',
        url: 'gebruikers.aspx/GetUserInfo',
        data: '{id: "' + id + '"}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {
            // Haal het overlay element op
            var hoofdelement = $('#zoek_profiel_overlay');

            // Haal de data uit de string
            var profiel_naam = result.d.split('|')[0];
            var profiel_type = result.d.split('|')[1];
            var profiel_quote = result.d.split('|')[2];
            var profiel_foto = result.d.split('|')[3];

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
*/