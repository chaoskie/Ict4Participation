$(function() {
	$('.dropdown-dynamic .dropdown-title').on('click', function() {
		$(this).next().find('ul').toggleClass('is-hiding');
		$(this).find('i.fa').toggleClass('fa-chevron-down fa-chevron-up');
	});
});