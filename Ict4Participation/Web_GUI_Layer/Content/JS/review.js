// Functie om de reviewsterren te updating wanneer de pagina geladen is
$(function () {

    // Haal het ratingnr op uit het data attribuut van #review_rating
    var ratingNr = $('#review_rating').attr('data-rating-nr');

    // Vul een ingevulde ster in voor elke ster die tussen 1 en ratingNr zit
    for (var i = 1; i <= ratingNr; i++)
    {
        $('#rating' + i).html('&#9733;');
    }

});
