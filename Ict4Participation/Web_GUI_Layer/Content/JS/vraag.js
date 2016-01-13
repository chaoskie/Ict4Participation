// Variabele die de tekst voordat de comment geëdit werd bijhoudt
// Zo kan de tekst worden teruggezet als de geupdate tekst niet wordt goedgekeurd
var tekstVoorEdit = '';

// Vul tekstVoorEdit in als er gefocused wordt
$('#comment_section').on('focus', 'p.comment-body[contenteditable]', function () {

    tekstVoorEdit = $(this).text();

});

// Update de tekst met de database
//$('p.comment-body[contenteditable]').focusout(function () {
$('#comment_section').on('focusout', 'p.comment-body[contenteditable]', function() {

    var ele = $(this);
    var updatedTekst = $(ele).text();
    var postID = $(this).attr('data-comment-id');

    // Stuur de geupdate tekst naar de database
    $.ajax({
        type: 'POST',
        url: 'vraag.aspx/UpdateComment',
        data: '{str: "' + updatedTekst + '", _postID: "' + postID + '"}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {

            // Zet de oude tekst terug als het resultaat leeg is
            if (result.d.length == 0)
            {
                $(ele).text(tekstVoorEdit);
            }
            else
            {
                $(ele).text(result.d);
            }

        }

    });

});

$('#tb_vraag').on('change keyup keydown', function() {
    if ($(this).val().trim() == '') {
        $('#btnPlaatsReactie').addClass('disabled');
    } else {
        $('#btnPlaatsReactie').removeClass('disabled');
    }
});

$('#btnPlaatsReactie').on('click', function () {

    var bericht = $('#tb_vraag').val();

    // Stuur de geupdate tekst naar de database
    $.ajax({
        type: 'POST',
        url: 'vraag.aspx/PlaceComment',
        data: '{str: "' + bericht + '"}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {

            if (result.d.length > 30) {
                // Append de nieuwe comment
                $('#comment_section').append(result.d);

                // Maak tekstbox leeg
                $('#tb_vraag').val('');

                // Verwijder h4 van #comment_section
                $('#comment_section').find('h4').parent().remove();
            }

        }

    });

    return false;

});

$('#comment_section').on('click', 'button[data-comment-id]', function() {

    var id = $(this).attr('data-comment-id');
    var ele = $(this);

    // Stuur de geupdate tekst naar de database
    $.ajax({
        type: 'POST',
        url: 'vraag.aspx/DeleteComment',
        data: '{id: "' + id + '"}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {

            if (result.d == 'true') {
                // Verander tekst naar 'Gebruiker heeft reactie verwijderd.'
                $(ele).parent().parent().next().find('.comment-body').removeAttr('contenteditable').text('Gebruiker heeft reactie verwijderd.');
                $(ele).remove();
            }
        }

    });

    return false;

});
