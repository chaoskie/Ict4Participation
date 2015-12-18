$('h2#username[contenteditable]').focusout(function () {
    
    // stuur async request
    $.ajax({
        type: 'POST',
        url: 'profiel.aspx/ChangeUserName',
        data: '{str: "' + $('h2#username').text() + '"}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {
            $('h2#username').text(result.d);
        }
    });

});

$('h3#userdescription[contenteditable]').focusout(function () {

    // stuur async request
    $.ajax({
        type: 'POST',
        url: 'profiel.aspx/ChangeUserDescription',
        data: '{str: "' + $('h3#userdescription').text() + '"}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {
            $('h3#userdescription').text(result.d);
        }
    });

});
