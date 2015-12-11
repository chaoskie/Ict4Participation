// Script met de functionaliteiten om profiel info te zoeken en weer te geven
$(function () {

    $('a[data-id]').hover(function (event) {

        // Haal het data-id op van de op te halen gebruiker
		var id = $(this).attr('data-id');
		
		// Roep de asynchrone functie 'laadprofiel' aan
		laadprofiel(function(result) {
			
		    var hoofdelement = $('#zoek_profiel_overlay');

            // Haal de data uit de string
			var profiel_naam = result.split('|')[0];
			var profiel_type = result.split('|')[1];
			var profiel_quote = result.split('|')[2];
			var profiel_foto = result.split('|')[3];

            // Zet de data naar het element
			$(hoofdelement).find('.zoek-profiel-foto').attr('src', profiel_foto);
			$(hoofdelement).find('.zoek-profiel-naam').text(profiel_naam);
			$(hoofdelement).find('.zoek-profiel-type').text(profiel_type);
			$(hoofdelement).find('.zoek-profiel-quote').text(profiel_quote);
			
            // Zet het element naar 'actief' om het zichtbaar te maken
			$(hoofdelement).addClass('actief');

		    // Zet de positie van de overlay naar 50px onder de muispositie
			var posX = event.pageX;
			if ((posX + $(hoofdelement).width()) > (window.innerWidth)) {

			    posX = window.innerWidth - $(hoofdelement).width() - 50;

			}

            // Zet het element naar de positie
			$(hoofdelement).css({left: posX, top: event.pageY+10});
			
		}, id);

    }, function (event) {

        // Haal de klasse 'actief' weg om het element onzichtbaar te maken
        $('#zoek_profiel_overlay').removeClass('actief');

	});

});

// Asynchrone functie vraagt de gegevens die bij het id horen op
function laadprofiel(callback, id) {

    try {

        var xhttp = new XMLHttpRequest();

        xhttp.onreadystatechange = function () {

            if (xhttp.readyState == 4 && xhttp.status == 200) {

                // Geef de response mee aan de callback functie
                callback(xhttp.responseText);

			}
		};

        // GET request roept het php script asynchroon aan
		xhttp.open('GET', 'zoekprofiel.php?id=' + id, true);
		xhttp.send();

    } catch (err) {

        console.log(err.message);

	}

};