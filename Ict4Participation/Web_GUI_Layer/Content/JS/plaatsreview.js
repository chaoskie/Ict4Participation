// Functie om het aantal sterren te selecteren en op te slaan in het data-attribuut van de wrapper
$(function () {
    $('#review_rating>span').click(function (event) {
        // Haal het nr op van de geklikte ster
        var ratingNr = event.target.id.substr(evsent.target.id.length - 1);

        // Zet het data-attribuut van de wrapper naar de review score
        $('#review_rating').attr('data-rating-nr', ratingNr);

        // Zet de inhoud van alle sterren naar lege sterren
        $('#review_rating span').html('&#9734;');

        // Voor elke ster <= het geklikte nummer, vul een volle ster in
        for (var j = 1; j <= ratingNr; j++)
        {
            $('#review_rating span:nth-child(' + (6 - j) + ')').html('&#9733;');
        }
    });
});