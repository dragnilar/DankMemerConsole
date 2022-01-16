var buttons = document.querySelectorAll('button');
if (buttons)
{
    for (i = 0; i < buttons.length; i++) {
        if (buttons[i].innerText === 'Login')
        { console.log('found the dumb button'); buttons[i].click(); }
    }
}