$(function () {
    // Haal alle vragen op als de pagina geladen is
    haalVragenOp('');

    // Haal alle gebruikers op als er op de input wordt geklikt of een toets wordt losgelaten
    $('#inputZoeken').on('keyup', function () {

        haalVragenOp($(this).val());

    });

});

// Functie om de gebruikers op te halen, door middel van ajax
function haalVragenOp(val) {

    console.log('val: ' + val);

    $.ajax({
        type: 'POST',
        url: 'vragen.aspx/SearchQuestions',
        data: '{str: "' + val + '"}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {

            // Maak lijst leeg
            $('#vragen_lijst').empty();

            // Split string
            var vragen = result.d.split(':');

            // Loop door de vragen array
            for (var i = 0; i < vragen.length; i++) {
                // Check of er een vraag is op plek i
                if (vragen[i] != "") {
                    // Split de vraag om de titel, posterid, rank en relevantie te scheiden
                    // Opzet: "titel,vraagid,posterid,posternaam:"
                    vragen[i] = vragen[i].split(',');

                    // Append nieuwe vraag in lijst
                    $('#vragen_lijst').append('<li><a href="#" data-vraag-id="' + vragen[i][1] + '" onclick="gaNaarVraag($(this).attr(\'data-vraag-id\'));">' + vragen[i][0] + '</a>' +
                                                  '<a href="#" data-gebr-id="' + vragen[i][2] + '" class="pull-right" onclick="gaNaarProfiel($(this).attr(\'data-gebr-id\'));">' + vragen[i][3] + '</a></li>');
                }
            }

            // Append bericht als er geen vragen gevonden zijn
            if (vragen.length == 1 && vragen[0] == "") {
                $('#vragen_lijst').append('<li><a href="#">Geen vragen gevonden</a></li>');
            }
        }
    });
};

// Functie om naar de vraagpagina te gaan
// De reden dat dit niet in de code behind staat is omdat de vragen dynamisch worden geladen
function gaNaarVraag(id) {

    // Ajax call naar server om naar de vraagpagina te gaan
    $.ajax({
        type: 'POST',
        url: 'vragen.aspx/GaNaarVraag',
        data: '{id: ' + id + '}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {
            if (result.d != '') {
                window.location = result.d;
            }
        }
    });
};

// Functie om naar de profielpagina te gaan
// De reden dat dit niet in de code behind staat is omdat de vragen dynamisch worden geladen
function gaNaarProfiel(id) {

    // Ajax call naar server om naar de profielpagina te gaan
    $.ajax({
        type: 'POST',
        url: 'vragen.aspx/GaNaarProfiel',
        data: '{id: ' + id + '}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {
            if (result.d != '') {
                window.location = result.d;
            }
        }
    });
};
