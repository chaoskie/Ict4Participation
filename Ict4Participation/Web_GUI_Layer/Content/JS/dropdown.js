// Script met de functionaliteit voor .dropdown
$(function () {

    $('.dropdown-dynamic .dropdown-title').on('click', function () {

        // Toggle class 'is-hiding' van ul
        $(this).next().find('ul').toggleClass('is-hiding');

        // Toggle het icoontje
        $(this).find('i.fa').toggleClass('fa-chevron-down fa-chevron-up');

	});

});
