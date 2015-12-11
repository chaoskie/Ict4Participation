$(function() {

	$('a[data-id]').hover(function(event) {
		var id = $(this).attr('data-id');
		
		
		laadprofiel(function(result) {
			
			// zet de data naar de overlay
			var hoofdelement = $('#zoek_profiel_overlay');
			var profiel_naam = result.split('|')[0];
			var profiel_type = result.split('|')[1];
			var profiel_quote = result.split('|')[2];
			var profiel_foto = result.split('|')[3];
			$(hoofdelement).find('.zoek-profiel-foto').attr('src', profiel_foto);
			$(hoofdelement).find('.zoek-profiel-naam').text(profiel_naam);
			$(hoofdelement).find('.zoek-profiel-type').text(profiel_type);
			$(hoofdelement).find('.zoek-profiel-quote').text(profiel_quote);
			
			// zet positie van overlay naar onder de link
			$(hoofdelement).addClass('actief');
			var posX = event.pageX;
			if ((posX + $(hoofdelement).width()) > (window.innerWidth)) {
				posX = window.innerWidth - $(hoofdelement).width() - 50;
			}
			$(hoofdelement).css({left: posX, top: event.pageY+10});
			
		}, id);
	}, function(event) {
		$('#zoek_profiel_overlay').removeClass('actief');
	});

});

function laadprofiel(callback, id) {
	try {
		var xhttp = new XMLHttpRequest();
		xhttp.onreadystatechange = function() {
			if (xhttp.readyState == 4 && xhttp.status == 200) {
				callback(xhttp.responseText);
			}
		};
		xhttp.open('GET', 'zoekprofiel.php?id=' + id, true);
		xhttp.send();
	} catch (err) {
		console.log(err.message);
	}
};