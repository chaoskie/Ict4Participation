// Variabele die de tekst voordat de comment geëdit werd bijhoudt
// Zo kan de tekst worden teruggezet als de geupdate tekst niet wordt goedgekeurd
var tekstVoorEdit = '';

// Vul tekstVoorEdit in als er gefocused wordt
$('p.comment-body[contenteditable]').focus(function () {

    tekstVoorEdit = $(this).text();

});

// Update de tekst met de database
$('p.comment-body[contenteditable]').focusout(function () {

    var $ele = $(this);
    var updatedTekst = $(this).text();
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
            if (result.d == '')
            {
                $($ele).text(tekstVoorEdit);
            }
            else
            {
                $($ele).text(result.d);
            }

        }

    });

});
