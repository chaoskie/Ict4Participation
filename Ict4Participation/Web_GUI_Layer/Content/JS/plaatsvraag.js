// Functie om skills toe te voegen
$('#btnVoegToe').on('click', function () {

    // Haal geselecteerde skill op
    var $option = $('#select_skills').find('option:selected');

    // Plak de skill in de output
    $('#select_skills_output').append($option);

    // Valideer fields
    valideerFields();

});

// Functie om skills te verwijderen
$('#btnVerwijder').on('click', function () {

    // Haal geselecteerde skill op
    var $option = $('#select_skills_output').find('option:selected');

    // Plak de skill terug in het select element
    $('#select_skills').append($option);

    // Valideer fields
    valideerFields();

    $('#select_skills_output').val($('#select_skills_output option:first').val());

});


$(function () {

    // Valideer fields als de DOM geladen is
    valideerFields();

    // Functie om de inputs client-side te valideren
    $('.form-control, .input-group-btn').on('keyup click', function () {

        // Valideer fields
        valideerFields();

    });

});

function valideerFields() {

    // Valideer titel
    if ((/^.+$/).test($('#inputTitel').val())) {
        $('#inputTitel').removeClass('form-fail').addClass('form-success');
    } else {
        $('#inputTitel').removeClass('form-success').addClass('form-fail');
        allesgoed = false;
    }

    // Valideer beschrijving
    if ((/^.+$/).test($('#inputBeschrijving').val())) {
        $('#inputBeschrijving').removeClass('form-fail').addClass('form-success');
    } else {
        $('#inputBeschrijving').removeClass('form-success').addClass('form-fail');
        allesgoed = false;
    }

    // Valideer toegevoegde skills
    if ($('#select_skills_output option').length > 0) {
        $('#select_skills_output').removeClass('form-fail').addClass('form-success');
    } else {
        $('#select_skills_output').removeClass('form-success').addClass('form-fail');
        allesgoed = false;
    }

    // Valideer locatie
    if ((/^.+$/).test($('#inputLocatie').val())) {
        $('#inputLocatie').removeClass('form-fail').addClass('form-success');
    } else {
        $('#inputLocatie').removeClass('form-success').addClass('form-fail');
        allesgoed = false;
    }

    // Valideer input_startdate_1
    if ((/^([1-9]|[12]\d|3[01])$/).test($('#input_startdate_1').val())) {
        $('#input_startdate_1').removeClass('form-fail').addClass('form-success');
    } else {
        $('#input_startdate_1').removeClass('form-success').addClass('form-fail');
        allesgoed = false;
    }

    // Valideer input_startdate_2
    if ((/^([1-9]|10|11|12)$/).test($('#input_startdate_2').val())) {
        $('#input_startdate_2').removeClass('form-fail').addClass('form-success');
    } else {
        $('#input_startdate_2').removeClass('form-success').addClass('form-fail');
        allesgoed = false;
    }

    // Valideer input_startdate_3
    if ((/^(2015|2016)$/).test($('#input_startdate_3').val())) {
        $('#input_startdate_3').removeClass('form-fail').addClass('form-success');
    } else {
        $('#input_startdate_3').removeClass('form-success').addClass('form-fail');
        allesgoed = false;
    }

    // Valideer input_startdate_4
    if ((/^([0-9]|1[0-9]|2[0-3])$/).test($('#input_startdate_4').val())) {
        $('#input_startdate_4').removeClass('form-fail').addClass('form-success');
    } else {
        $('#input_startdate_4').removeClass('form-success').addClass('form-fail');
        allesgoed = false;
    }

    // Valideer input_startdate_5
    if ((/^([05]|[1-5][05])$/).test($('#input_startdate_5').val())) {
        $('#input_startdate_5').removeClass('form-fail').addClass('form-success');
    } else {
        $('#input_startdate_5').removeClass('form-success').addClass('form-fail');
        allesgoed = false;
    }

    // Valideer illegale data
    // Disable dag 31 bij enkele maanden
    if ((/2|4|6|9|11/).test($('#input_startdate_2').val())) {
        if ($('#input_startdate_1').val() == '31') {
            fouteStartdateIngevoerd();
        }
    }
    // Test februari
    if ($('#input_startdate_2').val() == '2') {
        // Disable dag 30
        if ($('#input_startdate_1').val() == '30') {
            fouteStartdateIngevoerd();
        }
        // Disable 29 bij schrikkeljaar
        if ($('#input_startdate_1').val() == '29' &&
            $('#input_startdate_3').val() % 4 != 0) {
            fouteStartdateIngevoerd();
        }
    }

    // Valideer input_einddate_1
    if ((/^([1-9]|[12]\d|3[01])$/).test($('#input_einddate_1').val())) {
        $('#input_einddate_1').removeClass('form-fail').addClass('form-success');
    } else {
        $('#input_einddate_1').removeClass('form-success').addClass('form-fail');
        allesgoed = false;
    }

    // Valideer input_einddate_2
    if ((/^([1-9]|10|11|12)$/).test($('#input_einddate_2').val())) {
        $('#input_einddate_2').removeClass('form-fail').addClass('form-success');
    } else {
        $('#input_einddate_2').removeClass('form-success').addClass('form-fail');
        allesgoed = false;
    }

    // Valideer input_einddate_3
    if ((/^(2015|2016)$/).test($('#input_einddate_3').val())) {
        $('#input_einddate_3').removeClass('form-fail').addClass('form-success');
    } else {
        $('#input_einddate_3').removeClass('form-success').addClass('form-fail');
        allesgoed = false;
    }

    // Valideer input_einddate_4
    if ((/^([0-9]|1[0-9]|2[0-3])$/).test($('#input_einddate_4').val())) {
        $('#input_einddate_4').removeClass('form-fail').addClass('form-success');
    } else {
        $('#input_einddate_4').removeClass('form-success').addClass('form-fail');
        allesgoed = false;
    }

    // Valideer input_einddate_5
    if ((/^([05]|[1-5][05])$/).test($('#input_einddate_5').val())) {
        $('#input_einddate_5').removeClass('form-fail').addClass('form-success');
    } else {
        $('#input_einddate_5').removeClass('form-success').addClass('form-fail');
        allesgoed = false;
    }

    // Valideer illegale data
    // Disable dag 31 bij enkele maanden
    if ((/2|4|6|9|11/).test($('#input_einddate_2').val())) {
        if ($('#input_einddate_1').val() == '31') {
            fouteEinddateIngevoerd();
        }
    }
    // Test februari
    if ($('#input_einddate_2').val() == '2') {
        // Disable dag 30
        if ($('#input_einddate_1').val() == '30') {
            fouteEinddateIngevoerd();
        }
        // Disable 29 bij schrikkeljaar
        if ($('#input_einddate_1').val() == '29' &&
            $('#input_einddate_3').val() % 4 != 0) {
            fouteEinddateIngevoerd();
        }
    }
};

function fouteStartdateIngevoerd() {
    $('#input_startdate_1, #input_startdate_2, #input_startdate_3, #input_startdate_4, #input_startdate_5').removeClass('form-success').addClass('form-fail');
    allesgoed = false;
}

function fouteEinddateIngevoerd() {
    $('#input_einddate_1, #input_einddate_2, #input_einddate_3, #input_einddate_4, #input_einddate_5').removeClass('form-success').addClass('form-fail');
    allesgoed = false;
}