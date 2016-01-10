$('#collapse').on('click', function () {
    // toggle show and hide
    if ($('#chatwrapper').hasClass('hide')) {
        $('#chatwrapper').animate({ height: 650 }, 400).removeClass('hide');
    } else {
        $('#chatwrapper').animate({ height: 45 }, 400).addClass('hide');
    }
    // toggle caret icon
    $('#collapse i').toggleClass('fa-caret-down fa-caret-up');
});

$('#chat-go-back').on('click', function () {
    animateToHome();
});

$('#list_rooms').on('click', 'a', function () {
    animateToChat();
});

function animateToChat() {
    $('#chat-scene-wrapper').stop().animate({ left: -400 }, 400).addClass('hide');
};

function animateToHome() {
    $('#chat-scene-wrapper').stop().animate({ left: 0 }, 400).removeClass('hide');
};
