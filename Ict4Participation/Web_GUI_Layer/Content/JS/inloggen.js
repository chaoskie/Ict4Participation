// Function to open chat window and redirect to another url
function openNewWin(url, redirectUrl) {
    var x = window.open(url, 'mynewwin', '_blank', 'toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=0,width=300,height=500,modal=yes,alwaysRaised=yes');
    x.focus();
    window.location = redirectUrl;
};
