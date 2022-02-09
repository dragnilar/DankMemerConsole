function ShowSideBar() {
    var results = getElementsByXPath('/html/body/div[1]/div[2]/div/div[2]/div/div/div/div/div[1]', document);
    var sideBar = results[0];
    sideBar.style.visibility = 'visible';
    sideBar.style.width = '240px';

}

function HideSideBar() {
    var results = getElementsByXPath('/html/body/div[1]/div[2]/div/div[2]/div/div/div/div/div[1]', document);
    var sideBar = results[0];
    sideBar.style.visibility = 'collapse';
    sideBar.style.width = '0px';
}

function ClickButtons(buttonIndex, messageIndex = 2) {
    var lastMessage = $("ol li:nth-last-child("+messageIndex+")");
    var lastMessageButtons = lastMessage.find('button');
    //If for some reason we entered a button index that exceeds number of buttons, click the last button by default.
    if (buttonIndex > lastMessageButtons.length) {
        buttonIndex = lastMessageButtons.length - 1;
    }
    lastMessageButtons[buttonIndex].click();
}

function ChangeDiscordFont(fontName = 'Montserrat') {
    document.body.style.fontFamily = fontName;
}