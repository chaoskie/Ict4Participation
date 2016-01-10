$(function() {
    $('input[id^="rooster"').on('click', function() {

        // Sla element op
        var ele = $(this);

        // Haal het id op
        var id = $(ele).attr('id');

        // Check of het element de klasse 'beschikbaar' heeft
        var beschikbaar = $(ele).hasClass('beschikbaar') ? 'true' : 'false';

        $.ajax({
            type: 'POST',
            url: 'hoofdmenu.aspx/UpdateAvailability',
            data: '{id: "' + id + '", beschikbaar: "' + beschikbaar + '"}',
            contentType: 'application/json;charset=utf-8',
            dataType: 'json',
            success: function(result) {
                if (result.d == 'true') {
                    $(ele).addClass('beschikbaar');
                } else if (result.d == 'false') {
                    $(ele).removeClass('beschikbaar');
                }
            }
        });

    });
});