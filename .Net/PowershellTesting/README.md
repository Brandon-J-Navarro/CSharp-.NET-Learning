# Powershell Integration Testing
This is based on the "Example" Project but is more of what I had in mind. <br>
Instead of running a Powershell script that "calls" and "renders" a GUI, I wanted to have the scripts integrated in the application and the application calls the scripts. <br>
Still mostly based on 'https://adamtheautomator.com/powershell-gui/' but reworked to function how I had in mind to serve as an example for me. <br> <br>
Probably not the best practice since the Script is being ran with Execution Policy Bypass since I dont have a code signing cert. I have to run it with Bypass when I work on it on a computer
that wasnt the original computer that the script was writen on. This needs to be looked into.
