﻿// Haal alle gebruikers op als de pagina geladen is
$(function () {
    haalGebruikersOp('');
});

// Haal alle gebruikers op als er op de input wordt geklikt of een toets wordt losgelaten
$('#inputZoeken').on('keyup click', haalGebruikersOp($(this).val()));

// Functie om de gebruikers op te halen, door middel van ajax
function haalGebruikersOp(val) {

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
                    $('#gebruikers_lijst').append('<li><a href="#" data-id="' + gebruikers[i][1] + '" onclick="gaNaarProfiel($(this).attr(\'data-id\'));">' + gebruikers[i][0] + '</a></li>');
                }
            }

            // Append bericht als er geen gebruikers gevonden zijn
            if (gebruikers.length == 1 && gebruikers[0] == "") {
                $('#gebruikers_lijst').append('<li><a href="#">Geen gebruikers gevonden</a></li>');
            }
        }
    });
};

// Functie om naar de profielpagina te gaan
// De reden dat dit niet in de code behind staat is omdat de gebruikers dynamisch worden geladen
function gaNaarProfiel(id) {

    // Ajax call naar server om naar de profielpagina te gaan
    $.ajax({
        type: 'POST',
        url: 'gebruikers.aspx/GaNaarProfiel',
        data: '{id: "' + id + '"}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {
            if (result.d != '')
            {
                window.location = result.d;
            }
        }
    });
};
