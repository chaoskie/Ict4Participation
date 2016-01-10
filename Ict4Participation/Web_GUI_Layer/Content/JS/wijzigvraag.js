// TODO: check elke input

// Functie om skills toe te voegen
$('#btnSkillVoegToe').on('click', function () {

    // Haal geselecteerde skill op
    var $option = $('#select_skills').find('option:selected');

    // Plak de skill in de output
    $('#select_skills_output').append($option);

    // Valideer fields
    valideerFields();

    // Synchroniseer de skills met de serverside
    VoegSkillsToeServerSide();
});

// Functie om skills te verwijderen
$('#btnSkillVerwijder').on('click', function () {

    // Onthoud vooraf geselecteerde option
    var laatstgeselecteerde = $('#select_skills').val();

    // Haal geselecteerde skill op
    var $option = $('#select_skills_output').find('option:selected');

    // Plak de skill terug in het select element
    $('#select_skills').append($option);
    
    $('#select_skills_output').val($('#select_skills_output option:first').val());

    // Synchroniseer de skills met de serverside
    VoegSkillsToeServerSide();

    // Sorteer de input lijst
    var options = $('#select_skills option');
    var arr = options.map(function (_, o) { return { t: $(o).text(), v: o.value }; }).get();
    arr.sort(function (o1, o2) { return o1.t > o2.t ? 1 : o1.t < o2.t ? -1 : 0; });
    options.each(function (i, o) {
        o.value = arr[i].v;
        $(o).text(arr[i].t);
    });

    // Zet de geselecteerde optie naar de laatstgeselecteerde option
    if (laatstgeselecteerde != undefined) {
        $('#select_skills').val(laatstgeselecteerde);
    }
});

// Functie om skills serverside toe te voegen
// De reden waarom dit op deze manier wordt gedaan is omdat de codebehind niet weet dat
// er iets is toegevoegd aan het element select_skills_output
function VoegSkillsToeServerSide() {

    var skills = '';
    var skills_output = document.getElementById('select_skills_output');

    // Push elke skill naar de skills array
    for (i = 0; i < skills_output.length; i++) {

        skills += skills_output[i].value;

        // Na elke skill (behalve de laatste) wordt een | geplaatst, zodat de
        // server de skills kan onderscheiden
        if (i < skills_output.length - 1) {
            skills += '|';
        }

    }

    // stuur async request met skills parameter
    $.ajax({
        type: 'POST',
        url: 'wijzigvraag.aspx/UpdateSkills',
        data: '{skills: "' + skills + '"}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {
            // er worden geen resultaten teruggegeven dus deze functie is leeg
        }
    });

};

// Na het laden van de pagina worden de huidige data ingevuld voor gebruiksvriendelijkheid
// en worden de fields gevalideerd
$(function () {

    // Zet de datum naar de huidige datum
    var d = new Date();
    var d_day = d.getDate();
    var d_month = d.getMonth() + 1;
    var d_year = d.getFullYear();
    var d_hour = d.getHours();
    var d_min = d.getMinutes() + (5 - (d.getMinutes() % 5));

    $('#input_startdate_1 option[value="' + d_day + '"]').prop('selected', true);
    $('#input_startdate_2 option[value="' + d_month + '"]').prop('selected', true);
    $('#input_startdate_3 option[value="' + d_year + '"]').prop('selected', true);
    $('#input_startdate_4 option[value="' + d_hour + '"]').prop('selected', true);
    $('#input_startdate_5 option[value="' + d_min + '"]').prop('selected', true);

    $('#input_einddate_1 option[value="' + d_day + '"]').prop('selected', true);
    $('#input_einddate_2 option[value="' + d_month + '"]').prop('selected', true);
    $('#input_einddate_3 option[value="' + d_year + '"]').prop('selected', true);
    $('#input_einddate_4 option[value="' + (d_hour + 1) + '"]').prop('selected', true);
    $('#input_einddate_5 option[value="' + d_min + '"]').prop('selected', true);

    // Valideer fields als de DOM geladen is
    valideerFields();

    // Functie om de inputs client-side te valideren
    $('.form-control, .input-group-btn').on('keyup click', function () {

        // Valideer fields
        valideerFields();

    });

});

// Functie om de fields te valideren door middel van reguliere expressies
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

    // Valideer aantal hulpverleners
    if ($('#input_max_accs').val() >= 1 ||
        $('#input_max_accs').val() <= 8) {
        $('#input_max_accs').removeClass('form-fail').addClass('form-success');
    } else {
        $('#input_max_accs').removeClass('form-success').addClass('form-fail');
        allesgoed = false;
    }
};

// Functie om alle controls van startdatum de klasse 'form-fail' te geven
function fouteStartdateIngevoerd() {
    $('#input_startdate_1, #input_startdate_2, #input_startdate_3, #input_startdate_4, #input_startdate_5').removeClass('form-success').addClass('form-fail');
    allesgoed = false;
};

// Functie om alle controls van einddatum de klaase 'form-fail' te geven
function fouteEinddateIngevoerd() {
    $('#input_einddate_1, #input_einddate_2, #input_einddate_3, #input_einddate_4, #input_einddate_5').removeClass('form-success').addClass('form-fail');
    allesgoed = false;
};
