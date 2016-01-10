var socket = io.connect('http://localhost:8081');
var eigenNaam;
var eigenID;

function client_login() {
    eigenNaam = $('#inputUsername').val();
    eigenID = $('#inputID').val();
    // add user
    socket.emit('adduser', eigenNaam, eigenID);

    // delete temp_wrapper
    $('#temp_wrapper').remove();
}

// update chat when server
socket.on('updatechat', function (username, userID, data, timestamp) {
    var bericht = "";

    // master bericht
    if (username == 'SERVER') {
        bericht = '<li class="message-master"><span class="timestamp">' + timestamp + '</span><p class="message">' + data + '</p><p></p></li>';
    } else if (username != eigenNaam) {
        bericht = '<li class="message-other"><span class="owner">' + username + '</span><span class="timestamp">' + timestamp + '</span><p class="message">' + data + '</p><p></p></li>';
    } else {
        bericht = '<li class="message-own"><span class="owner">' + username + '</span><span class="timestamp">' + timestamp + '</span><p class="message">' + data + '</p><p></p></li>';
    }

    // append message to list
    $('#messages>ul').append(bericht);
});

// update people
socket.on('updaterooms', function (people, eigenID) {

    $('#list_rooms').empty();
    $('#chat_people').empty();

    $.each(people, function (key, value) {
        var color = '#000';
        if (value == eigenID) color = '#f00';

        $('#list_rooms').append('<li><a href="#" style="' + color + '" onclick="switchRoom(\'' + value + '\')">' + key + '</a></li>');

        $('#chat_people').append('<option>' + key + '</option>');
    });
});

socket.on('goToRoom', function (roomnr) {
    // Switch room if the user is the owner of the room
    if (roomnr == eigenID) {
        // Switch room to roomnr
        switchRoom(roomnr);

        // Animate to room
        animateToChat();
    }
});

// switch room function
function switchRoom(room) {
    socket.emit('switchroom', room);
};

// on load
$(function () {
    // on button click
    $('#sendmessage>button').on('click', function () {
        var message = $('#sendmessage>textarea').val();
        // empty message input
        $('#sendmessage>textarea').val('');
        // emit message
        socket.emit('sendchat', message);
    });

    $('#sendmessage>textarea').keypress(function (e) {
        // on enter press
        if (e.which == 13) {
            $(this).blur();
            $('#sendmessage>textarea').focus().click();
        }
    });

    $('#chat-go-back').on('click', function () {
        // remove chat messages
        setTimeout(function () {
            $('#messages>ul').empty();

            switchRoom('');
        }, 400);
    });
});
