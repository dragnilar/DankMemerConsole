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

function ClickButtons(buttonIndex) {
    var lastMessage = $("ol li:nth-last-child(2)");
    var lastMessageButtons = lastMessage.find('button');
    lastMessageButtons[buttonIndex].click();
}