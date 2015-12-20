$('#inputZoeken').on('keyup click', function () {
    var val = $(this).val();

    $.ajax({
        type: 'POST',
        url: 'gebruikers.aspx/SearchUsers',
        data: '{str: "' + val + '"}',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {
            // Maak lijst leeg
            $('#gebruikers_lijst').empty();

            // Split string
            var gebruikers = result.d.split(':');

            // Loop door de gebruikers array
            for (var i = 0; i < gebruikers.length; i++) {
                // Split de gebruiker om de naam en het id van de gebruiker te scheiden
                gebruikers[i] = gebruikers[i].split(',');

                // append nieuwe gebruiker in lijst
                $('#gebruikers_lijst').append('<li><a href="#" data-id="' + gebruikers[i][1] + '">' + gebruikers[i][0] + '</li>');
            }
        }
    });

});