// Functie om alle fields alvast te valideren als de pagina geladen is
$(function () {

    // Valideer fields als de DOM geladen is
    valideerFields();

});

// Functie om de inputs client-side te valideren
$('.form-control, .input-group-btn').on('keyup click', function () {

    // Valideer fields
    valideerFields();

});

// Functie om de inputs te valideren na het drukken op een tabje
$('.nav.nav-tabs a').on('click', function () {

    // Valideer fields na een delay van 400ms.
    // De te checken inputs zijn namelijk nog onzichtbaar voor 400ms.
    setTimeout(valideerFields, 100);

});

var xhr;

// Als inputWoonplaats nog niet success is maar wel tekst bevat,
// stuur een async request om te controlleren of de woonplaats bestaat
$('#inputWoonplaats').on('keyup click change', function () {
    var val = $(this).val();

    // Abort de huidige ajax call als die bestaat
    if (xhr != undefined) {
        xhr.abort();
    }

    // Haal woonplaatsen op
    $.ajax({
        type: 'POST',
        url: 'wijziggegevens.aspx/GetCities',
        data: '{str: "' + val + '"}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {
            var res = result.d.split('|');

            // Maak #woonplaats_result_wrapper leeg
            $('#woonplaats_results_wrapper').html("");

            var r_i, r_length = res.length;
            for (r_i = 0; r_i < r_length; r_i++) {
                $('#woonplaats_results_wrapper').append('<p class="city_gen">' + res[r_i] + '</p>');
            }
        }
    })
});

function validateName(textbox) {
    var allesgoed = true;
    var message;
    var s = $(textbox).val();

    //Check if the string is longer than 255
    if (s.length > 255) {
        message = "Uw naam is te lang.";
        allesgoed = false;
    }

    //Check if the full name contains at least 1 space (= 2 words)
    if (s.split(' ')[1] == undefined) {
        message = "Uw volledige naam bestaat uit minimaal twee delen";
        allesgoed = false;
    }
    if (s.split(' ')[1] != undefined) {
        if (s.split(' ')[1].length < 1) {
            message = "Uw volledige naam bestaat uit minimaal twee delen";
            allesgoed = false;
        }
    }

    for (var i = 0; i < s.length; i++) {

        var current = s[i];
        var prev = i == 0 ? ' ' : s[i - 1];
        var next = i >= s.length - 1 ? ' ' : s[i + 1];
        var nextdot = i >= s.length - 2 ? ' ' : s[i + 2];

        //Check if the dots are preceded by a letter, and have a space placed after, or another dot 2 places further
        if (current == '.') {
            //If a space is placed before this character, it is wrong
            if (prev == ' ') {
                message = "Een puntteken zoals in 'J.K. Rowling' moet altijd worden geplaatst na een letter.";
                allesgoed = false;
            }

            //If a letter comes after, but not another dot, it is wrong
            if ((/[\u00C0-\u017Fa-zA-Z]{1}/).test(next) && nextdot != '.') {
                message = "Een puntteken zoals in 'J.K. Rowling' moet alleen met een letter staan, of nog een afkorting";
                allesgoed = false;
            }
        }

        //Check if the minus symbol is surrounded by letters
        if (current == '-') {
            if (!((/[\u00C0-\u017Fa-zA-Z]{1}/).test(prev) && (/[\u00C0-\u017Fa-zA-Z]{1}/).test(next))) {
                message = "Een streepje zoals in 'Henk van Bart-Veldden' moet altijd tussen letters komen te staan";
                allesgoed = false;
            }
        }
    }
    while (s.split(' ')[1] != undefined) {
        s = s.replace(" ", "");
    }
    //Check if every symbol is what it needs to be
    if (!(/^[\u00C0-\u017Fa-zA-Z'-.]{1,}$/).test(s)) {
        message = "Naam bevat ongeldige tekens!";
        allesgoed = false;
    }
    if (!allesgoed && s.length > 0) {
        $('#Label1').removeClass("error-hidden");
        $('#Label1').text(message);
    }
    else {
        $('#Label1').addClass("error-hidden");
        $('#Label1').text();
    }
    return allesgoed;
};

// Functie om de zichtbare fields te valideren
function valideerFields() {

    // Variabele houdt bij of alle inputs goed zijn ingevuld
    var allesgoed;

    // Haal data-toggle id op van geselecteerde tab
    var $id = $('.nav.nav-tabs:first li.active a').attr('href');

    // Valideer Algemene gegevens
    if ($id == '#tab_form1') {

        allesgoed = true;

        // Validate full name
        allesgoed = validateName('#inputFullName');

        // Valideer straatnaam
        if ((/^\D{2,}$/).test($('#inputStraatnaam').val())) {
            $('#inputStraatnaam').removeClass('form-fail').addClass('form-success');
        } else {
            $('#inputStraatnaam').removeClass('form-success').addClass('form-fail');
            allesgoed = false;
        }

        // Valideer huisnr
        if ((/^\d+(?:[a-zA-Z]){0,}$/).test($('#inputHuisnummer').val())) {
            $('#inputHuisnummer').removeClass('form-fail').addClass('form-success');
        } else {
            $('#inputHuisnummer').removeClass('form-success').addClass('form-fail');
            allesgoed = false;
        }

        // Valideer telefoonnummer
        //if ((/(^\+[0-9]{2}|^\+[0-9]{2}\(0\)|^\(\+[0-9]{2}\)\(0\)|^00[0-9]{2}|^0)([0-9]{9}$|[0-9\-\s]{10}$)/).test($('#inputTelefoonnummer').val())) {
        if ((/([+]\d{2} ){0,1}\d{3}[-.]?\d{3}[-.]?\d{4}/).test($('#inputTelefoonnummer').val())) {
            $('#inputTelefoonnummer').removeClass('form-fail').addClass('form-success');
        } else {
            $('#inputTelefoonnummer').removeClass('form-success').addClass('form-fail');
            allesgoed = false;
        }

        // Valideer geslacht (man|vrouw)
        if ((/^man|vrouw$/i).test($('#input_geslacht').val())) {
            $('#input_geslacht').removeClass('form-fail').addClass('form-success');
        } else {
            $('#input_geslacht').removeClass('form-success').addClass('form-fail');
            allesgoed = false;
        }

        // Valideer birthdate dag
        if ((/^(:?[1-9]|[1-2][0-9]|3[0-1])$/).test($('#input_birthdate_1').val())) {
            $('#input_birthdate_1').removeClass('form-fail').addClass('form-success');
        } else {
            $('#input_birthdate_1').removeClass('form-success').addClass('form-fail');
            allesgoed = false;
        }

        // Valideer birthdate maand
        if ((/^([1-9]|1[0-2])$/).test($('#input_birthdate_2').val())) {
            $('#input_birthdate_2').removeClass('form-fail').addClass('form-success');
        } else {
            $('#input_birthdate_2').removeClass('form-success').addClass('form-fail');
            allesgoed = false;
        }

        // Valideer birthdate jaar
        if ((/^19[1-9][0-9]$/).test($('#input_birthdate_3').val())) {
            $('#input_birthdate_3').removeClass('form-fail').addClass('form-success');
        } else {
            $('#input_birthdate_3').removeClass('form-success').addClass('form-fail');
            allesgoed = false;
        }

        function fouteDagIngevoerd() {
            $('#input_birthdate_1, #input_birthdate_2, #input_birthdate_3').removeClass('form-success').addClass('form-fail');
            allesgoed = false;
        }

        // Check illegale data
        var bd_dag = $('#input_birthdate_1').val();
        var bd_maand = $('#input_birthdate_2').val();
        var bd_jaar = $('#input_birthdate_3').val();

        // Disable dag 31 bij enkele maanden
        if ((/2|4|6|9|11/).test(bd_maand)) {
            if (bd_dag == '31') {
                fouteDagIngevoerd();
            }
        }
        // Test februari
        if (bd_maand == '2') {
            // Disable dag 30
            if (bd_dag == '30') {
                fouteDagIngevoerd();
            }
            // Disable 29 bij schrikkeljaar
            if (bd_dag == '29' &&
                bd_jaar % 4 != 0) {
                fouteDagIngevoerd();
            }
        }

        // Verander data-formcomplete gebaseert op allesgoed
        if (allesgoed) {
            $('#tab_form1').data('formcomplete', true);
        } else {
            $('#tab_form1').data('formcomplete', false);
        }
    }

    // Valideer Accountgegevens
    if ($id == '#tab_form2') {

        allesgoed = true;

        // valideer email
        if ((/^[-a-z0-9~!$%^&*_=+}{\'?]+(\.[-a-z0-9~!$%^&*_=+}{\'?]+)*@([a-z0-9_][-a-z0-9_]*(\.[-a-z0-9_]+)*\.(aero|arpa|biz|com|coop|edu|gov|info|int|mil|museum|name|net|org|pro|travel|mobi|[a-z][a-z])|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(:[0-9]{1,5})?$/i).test($('#inputEmail').val())) {
            $('#inputEmail').removeClass('form-fail').addClass('form-success');
        } else {
            $('#inputEmail').removeClass('form-success').addClass('form-fail');
            allesgoed = false;
        }

        // valideer gebruikersnaam
        var username = $('#inputGebruikersnaam').val();
        var usernamevalid = true;
        if ((/^[a-zA-Z0-9-._]{6,255}$/).test(username)) {
            $('#inputGebruikersnaam').removeClass('form-fail').addClass('form-success');
            $('#Label1').addClass("error-hidden");
            usernamevalid = true;
        } else {
            $('#inputGebruikersnaam').removeClass('form-success').addClass('form-fail');
            if (username.length > 0) {
                $('#Label1').removeClass("error-hidden");
                if (username.length < 6) {
                    $('#Label1').text("Uw gebruikersnaam moet minimaal 6 tekens bevatten");
                }
                if (username.length > 255) {
                    $('#Label1').text("Uw gebruikersnaam mag niet meer dan 255 tekens bevatten");
                }
                if (username.length <= 255 && username.length >= 6) {
                    $('#Label1').text("Uw gebruikersnaam mag geen andere tekens bevatten dan letters, underscores, hyphes en punten");
                }
                usernamevalid = false;
            }
            else {
                $('#Label1').addClass("error-hidden");
            }
            allesgoed = false;
        }

        // valideer wachtwoord
        var pass = $('#inputWachtwoord1').val();
        if ((/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,255}$/).test(pass)) {
            $('#inputWachtwoord1').removeClass('form-fail').addClass('form-success');
            $('#Label1').addClass("error-hidden");
        } else {
            $('#inputWachtwoord1').removeClass('form-success').addClass('form-fail');
            if (pass.length > 0 && usernamevalid) {
                $('#Label1').removeClass("error-hidden");
                if (pass.length < 8) {
                    $('#Label1').text("Uw wachtwoord moet minimaal 8 tekens bevatten");
                }
                if (pass.length > 255) {
                    $('#Label1').text("Uw wachtwoord mag niet meer dan 255 tekens bevatten");
                }
                if (pass.length <= 255 && pass.length >= 6) {
                    $('#Label1').text("Uw wachtwoord moet minimaal 1 hoofdletter en 1 speciaal karakter bevatten");
                }
            }
            else {
                if (usernamevalid) {
                    $('#Label1').addClass("error-hidden");
                }
            }
            allesgoed = false;
        }

        // valideer herhaal wachtwoord
        if ($('#inputWachtwoord2').val() === $('#inputWachtwoord1').val()) {
            $('#inputWachtwoord2').removeClass('form-fail').addClass('form-success');
        } else {
            $('#inputWachtwoord2').removeClass('form-success').addClass('form-fail');
            allesgoed = false;
        }

        // Verander data-formcomplete gebaseert op allesgoed
        if (allesgoed) {
            $('#tab_form2').data('formcomplete', true);
        } else {
            $('#tab_form2').data('formcomplete', false);
        }

    }

    // Valideer Profielfoto
    if ($id == '#tab_form3') {

        allesgoed = true;

        // Verander data-formcomplete gebaseert op allesgoed
        if (allesgoed) {
            $('#tab_form3').data('formcomplete', true);
        } else {
            $('#tab_form3').data('formcomplete', false);
        }

    }

    // Valideer vervoer
    if ($id == '#tab_form4') {
        $('#tab_form4').data('formbekeken', true);
    }

    // Enable/Disable 'registreer als hulpbehoevende'-knop als alle forms goed zijn
    if ($('#tab_form1').data('formcomplete') &&
        $('#tab_form2').data('formcomplete') &&
        $('#tab_form3').data('formcomplete') &&
        $('#tab_form4').data('formbekeken')) {
        $('#btn_registreerhulpbehoevende').prop('disabled', false);
    } else {
        $('#btn_registreerhulpbehoevende').prop('disabled', true);
    }

    // Valideer Vrijwilliger
    if ($('#tab_vrijwilliger').hasClass('active')) {

        allesgoed = true;

        // Valideer of er minimaal 1 skill is toegevoegd
        if ($('#select_skills_output option').length > 0) {
            $('#select_skills_output').removeClass('form-fail').addClass('form-success');
        } else {
            $('#select_skills_output').removeClass('form-success').addClass('form-fail');
            allesgoed = false;
        }

        // Verander data-formcomplete gebaseert op allesgoed
        if (allesgoed) {
            $('#tab_vrijwilliger').data('formcomplete', true);
        } else {
            $('#tab_vrijwilliger').data('formcomplete', false);
        }

    }

};

// Functie om woonplaats uit suggesties te halen en in tekstbox te zetten
$('body').on('click', '#woonplaats_results_wrapper > p', function () {

    $('#inputWoonplaats').val($(this).text());

});

// Functie om de woonplaats wrapper zichtbaar te maken als de input focus heeft
$('#inputWoonplaats').on('focus click keyup', function () {

    $('#woonplaats_results_wrapper').css({ 'display': 'block' });
    isChecked = false;

});

$('#inputWoonplaats').on('keyup', function () {
    isChecked = false;
});

// Functie om de woonplaats wrapper onzichtbaar te maken als de input geen focus heeft
$('#inputWoonplaats').focusout(function () {

    // Wacht 200 milliseconde zodat de geklikte woonplaats nog verwerkt kan worden
    setTimeout(function () {
        $('#woonplaats_results_wrapper').css({ 'display': 'none' });
    }, 1000);

    valideerWoonplaats();

});

var prevTekst;

$('#woonplaats_results_wrapper').on('click', 'p', function () {
    prevTekst = $(this).text();
});

Loop();

var isChecked = false;

function Loop() {
    if (($('#inputWoonplaats').val() == prevTekst) &&
        !isChecked &&
        (!$('#inputWoonplaats').hasClass('form-success'))) {
        $('#woonplaats_results_wrapper').css({ 'display': 'none' });

        valideerWoonplaats();

        isChecked = true;

    }

    requestAnimationFrame(Loop);
};

function valideerWoonplaats() {

    // Valideer woonplaats
    $.ajax({
        type: 'POST',
        url: 'wijziggegevens.aspx/IsCity',
        data: '{str: "' + $('#inputWoonplaats').val() + '"}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {
            if (result.d == "true") {
                $('#inputWoonplaats').removeClass('form-fail').addClass('form-success');
            } else {
                $('#inputWoonplaats').removeClass('form-success').addClass('form-fail');
            }
        }
    });

}


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

    // Valideer fields
    valideerFields();

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
        url: 'wijziggegevens.aspx/UpdateSkills',
        data: '{skills: "' + skills + '"}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {
            // er worden geen resultaten teruggegeven dus deze functie is leeg
        }
    });

};

$('#btnVorigeTab').click(function () {
    // Haal href op van huidige tab
    var href = $('.nav-tabs').find('li.active > a').attr('href');

    // Haal het tab nummer uit de href
    var nr = parseInt(href.substr(href.length - 1, href.length));

    // Ga naar de volgende tab
    $('.nav-tabs a[href="#tab_form' + (nr - 1) + '"]').tab('show');

    // Disable 'Vorige' knop als nr <= 2
    if (nr <= 2) {
        $('#btnVorigeTab').addClass('disabled');
    }

    // Enable 'Vorige' knop
    $('#btnVolgendeTab').removeClass('disabled');
});

$('#btnVolgendeTab').click(function () {
    // Haal href op van huidige tab
    var href = $('.nav-tabs').find('li.active > a').attr('href');

    // Haal het tab nummer uit de href
    var nr = parseInt(href.substr(href.length - 1, href.length));

    // Ga naar de volgende tab
    $('.nav-tabs a[href="#tab_form' + (nr + 1) + '"]').tab('show');

    // Disable 'Volgende' knop als nr >= 3
    if (nr >= 3) {
        $('#btnVolgendeTab').addClass('disabled');
    }

    // Enable 'Vorige' knop
    $('#btnVorigeTab').removeClass('disabled');
});
