﻿var tekstVoorEdit = '';
$('p.comment-body[contenteditable]').focus(function () {
    tekstVoorEdit = $(this).text();
});
$('p.comment-body[contenteditable]').focusout(function () {

    var $ele = $(this);
    var updatedTekst = $(this).text();
    var postID = $(this).attr('data-comment-id');

    // stuur async request
    $.ajax({
        type: 'POST',
        url: 'vraag.aspx/UpdateComment',
        data: '{str: "' + updatedTekst + '", _postID: "' + postID + '"}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {
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