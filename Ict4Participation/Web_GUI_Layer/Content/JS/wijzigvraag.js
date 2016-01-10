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