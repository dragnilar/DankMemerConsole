# DankMemerConsole
A simple gui console app for Dank Memer (Discord Game bot).

Ever wanted to play Dank Memer with just a mouse?

Well now you can, thanks to this Selenium driven WPF program.

This program provides you with buttons to control Dank Memer from a seperate window. 

This allows you to not have to type any of the (supported) commands and you can just click the buttons in the program and Discord instead.

## Usage

1) Open the program (of course)

2) Enter your Discord Username and Password

3) Click the login to discord button

4) Selenium should open up a new browser instance and log you into Discord

5) Go to whatever chat room you normally play Dank Memer in and start plugging away.


## Known Issues
- Last received message currently does not display.
- Only works with MS Edge (no plans to provide other browser support)
- Only works on Windows (No plans on supporting other OSs)
- Sometimes Selenium leaves an instance of the web driver running in the background and you have to kill it in task manager.
- Window doesn't currently stay on top, so it is not single monitor friendly.
