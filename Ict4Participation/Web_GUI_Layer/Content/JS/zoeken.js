﻿$(function () {

    // Haal alle info op als de pagina geladen is
    haalInfoOp('');

    $('#inputZoeken').on('input', function (e) {
        var fvolunteers = $('#fvolunteers').is(':checked');
        var fhelpreq = $('#fhelpreq').is(':checked');
        var fquestions = $('#fquestions').is(':checked');
        // Haal alle info op als er op de input wordt geklikt of een toets wordt losgelaten
        haalInfoOp($(this).val(), fvolunteers, fhelpreq, fquestions);
    });

});

var xhr;

// Functie om alle gevonden resultaten op te halen, door middel van ajax
function haalInfoOp(val, b1, b2, b3) {
    // Abort de huidige ajax call als die bestaat
    if (xhr != undefined) {
        xhr.abort();
    }

    // Maak een nieuwe asynchrone request naar de server
    xhr = $.ajax({
        type: 'POST',
        url: 'zoeken.aspx/SearchInfo',
        data: '{str: "' + val + '", fvolunteers: "' + b1 + '", fhelpreq: "' + b2 + '", fquestions: "' + b3 + '"}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {
            // Maak lijst leeg
            $('#info_lijst').empty();

            // Split string
            var info = result.d.split(':');

            // Loop door de info array
            for (var i = 0; i < info.length; i++) {
                // Check of er een info is op plek i
                if (info[i] != "") {
                    // Split de infostring om de naam en het id van de info te scheiden
                    info[i] = info[i].split(',');

                    if (info[i][0] == '1') {
                        // Append nieuwe vraag in lijst
                        $('#info_lijst').append('<li><a href="#" data-vraag-id="' + info[i][2] + '" onclick="gaNaarVraag($(this).attr(\'data-vraag-id\'));">' + info[i][1] + '</a>' +
                                                  '<a href="#" data-gebr-id="' + info[i][3] + '" class="pull-right" onclick="gaNaarProfiel($(this).attr(\'data-gebr-id\'));">' + info[i][4] + '</a></li>');
                    }
                    if (info[i][0] == '2') {
                        // Append nieuwe account in lijst
                        $('#info_lijst').append('<li><a href="#" data-id="' + info[i][2] + '" onclick="gaNaarProfiel($(this).attr(\'data-id\'));">' + info[i][1] + '</a></li>');
                    }
                }
            }
            var amnts = info.length == 1 ? " Resultaat" : " Resultaten";
            if (info[0] == "")
            {
                amnts = " Resultaten";
            }

            // Update het aantal resultaten
            $('#aantalResultaten').text((info[0] == "" ? "0" : info.length) + amnts);

            // Append bericht als er geen info gevonden is
            if (info.length == 1 && info[0] == "") {
                $('#info_lijst').append('<li><a href="#">Niks gevonden!</a></li>');
            }
        }
    });
};

// Functie om naar de profielpagina te gaan
// De reden dat dit niet in de code behind staat is omdat de info dynamisch worden geladen
function gaNaarProfiel(id) {

    // Ajax call naar server om naar de profielpagina te gaan
    $.ajax({
        type: 'POST',
        url: 'zoeken.aspx/GaNaarProfiel',
        data: '{id: "' + id + '"}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {
            if (result.d != '') {
                window.location = result.d;
            }
        }
    });
};

// Functie om naar de vraagpagina te gaan
// De reden dat dit niet in de code behind staat is omdat de info dynamisch worden geladen
function gaNaarVraag(id) {

    // Ajax call naar server om naar de vraagpagina te gaan
    $.ajax({
        type: 'POST',
        url: 'zoeken.aspx/GaNaarVraag',
        data: '{id: "' + id + '"}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {
            if (result.d != '') {
                window.location = result.d;
            }
        }
    });
};
