// Script hoort bij registreren
$(function () {

    // Valideer fields als de DOM geladen is
    valideerFields();

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

    // Functie om skills toe te voegen
    $('#btnSkillVoegToe').on('click', function () {

        // Haal geselecteerde skill op
        var $option = $('#select_skills').find('option:selected');

        // Plak de skill in de output
        $('#select_skills_output').append($option);

        // Valideer fields
        valideerFields();

    });

    // Functie om skills te verwijderen
    $('#btnSkillVerwijder').on('click', function () {

        // Haal geselecteerde skill op
        var $option = $('#select_skills_output').find('option:selected');

        // Plak de skill terug in het select element
        $('#select_skills').append($option);

        // Valideer fields
        valideerFields();

    });

    // Functie om de zichtbare fields te valideren
    function valideerFields() {

        // Variabele houdt bij of alle inputs goed zijn ingevuld
        var allesgoed;

        // Haal data-toggle id op van geselecteerde tab
        var $id = $('.nav.nav-tabs:first li.active a').attr('href');

        // Valideer Algemene gegevens
        if ($id == '#tab_form1') {

            allesgoed = true;

            // Valideer voornaam
            if ((/^\D{2,}$/).test($('#inputVoornaam').val())) {
                $('#inputVoornaam').removeClass('form-fail').addClass('form-success');
            } else {
                $('#inputVoornaam').removeClass('form-success').addClass('form-fail');
                allesgoed = false;
            }

            // Valideer tussenvoegsel als het is ingevuld
            if ($('#inputTussenvoegsel').val().length > 0) {
                if ((/^\D+$/).test($('#inputTussenvoegsel').val())) {
                    $('#inputTussenvoegsel').removeClass('form-fail').addClass('form-success');
                } else {
                    $('#inputTussenvoegsel').removeClass('form-success').addClass('form-fail');
                    allesgoed = false;
                }
            } else {
                $('#inputTussenvoegsel').removeClass('form-success form-fail');
            }

            // Valideer achternaam
            if ((/^\D{2,}$/).test($('#inputAchternaam').val())) {
                $('#inputAchternaam').removeClass('form-fail').addClass('form-success');
            } else {
                $('#inputAchternaam').removeClass('form-success').addClass('form-fail');
                allesgoed = false;
            }

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

            // Valideer woonplaats
            if ((/^\D{2,}$/).test($('#inputWoonplaats').val())) {
                $('#inputWoonplaats').removeClass('form-fail').addClass('form-success');
            } else {
                $('#inputWoonplaats').removeClass('form-success').addClass('form-fail');
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
            if ((/^[a-zA-Z0-9]{6,255}$/).test($('#inputGebruikersnaam').val())) {
                $('#inputGebruikersnaam').removeClass('form-fail').addClass('form-success');
            } else {
                $('#inputGebruikersnaam').removeClass('form-success').addClass('form-fail');
                allesgoed = false;
            }

            // valideer wachtwoord
            if ((/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,255}$/).test($('#inputWachtwoord1').val())) {
                $('#inputWachtwoord1').removeClass('form-fail').addClass('form-success');
            } else {
                $('#inputWachtwoord1').removeClass('form-success').addClass('form-fail');
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

            // valideer profielfoto
            if ((/^.{1,}(?:\.jpg|\.png){1}$/).test($($id).find('.file-caption-name').attr('title'))) {
                $($id).find('.input-group>.file-caption').removeClass('form-fail').addClass('form-success');
            } else {
                $($id).find('.input-group>.file-caption').removeClass('form-success').addClass('form-fail');
                allesgoed = false;
            }

            // Verander data-formcomplete gebaseert op allesgoed
            if (allesgoed) {
                $('#tab_form3').data('formcomplete', true);
            } else {
                $('#tab_form3').data('formcomplete', false);
            }

        }

        // Enable/Disable 'registreer als hulpbehoevende'-knop als alle forms goed zijn
        if ($('#tab_form1').data('formcomplete') &&
            $('#tab_form2').data('formcomplete') &&
            $('#tab_form3').data('formcomplete'))
        {
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

            // valideer VOG
            if ((/^.{1,}(?:\.pdf){1}$/).test($('#tab_vrijwilliger').find('.file-caption-name').attr('title'))) {
                $('#tab_vrijwilliger').find('.input-group>.file-caption').removeClass('form-fail').addClass('form-success');
            } else {
                $('#tab_vrijwilliger').find('.input-group>.file.caption').removeClass('form-success').addClass('form-fail');
                allesgoed = false;
            }

            // Verander data-formcomplete gebaseert op allesgoed
            if (allesgoed) {
                $('#tab_vrijwilliger').data('formcomplete', true);
            } else {
                $('#tab_vrijwilliger').data('formcomplete', false);
            }

        }

        // Enable/Disable 'registreer als vrijwilliger'-knop als alle forms goed zijn
        if ($('#tab_form1').data('formcomplete') &&
            $('#tab_form2').data('formcomplete') &&
            $('#tab_form3').data('formcomplete') &&
            $('#tab_vrijwilliger').data('formcomplete'))
        {
            $('#btn_registreervrijwilliger').prop('disabled', false);
        } else {
            $('#btn_registreervrijwilliger').prop('disabled', true);
        }

    };

});