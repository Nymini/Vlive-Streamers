# Vlive Streamers
A collection of Vlive streamers which I worked on for personal use in the past. I've updated them such that they work with the new vlive site. Be warned however, this is fairly old code and it's pretty awful to look through. However, if you don't care about any of that, the programs itselves are fine.


# Streamer 1
An AutoHotKey script which will open Chrome tabs for the videos chosen.
#### Usage
Open up chrome yourself, login, and be sure to set the video resolution to 144P. Then format a "input.txt" file exactly as how it is in some of my examples. Then simply run the script.

**NOTE: You may have to edit the script to point to the correct location of chrome. 
You will also be unable to use the device while it is running, as it requires chrome to be focused.**

# Streamer 2
A Winforms program which will do exactly the same thing as Streamer 1. I wouldn't recommend using this, Streamer 3 works the same.
#### Usage
Run "Vlive Streamer.exe" and paste video links into the corresponding textboxes roughly to how long the video duration is. Then simply click start. You can also load a .txt file of the same format from Streamer 1. Make sure you follow the steps for Streamer 1, where you log in and set the resolution (and keep that tab open).

**NOTE: Quick Mode must be checked on to ensure it does not crash. This is due to changes in the vlive site.**

# Streamer 3
A WPF program which is pretty much streamer 2 but a bit prettier I guess. Has the same flaws with Streamer 1 & 2 where the device is unusable when it is running.
#### Usage
Run "WpfApplication1.exe", then add videos in the 2nd tab similar to streamer 2. Then simply click start. Make sure you follow the steps for Streamer 1, where you log in and set the resolution (and keep that tab open).

**NOTE: Quick Mode must be on (but it should be on by default) for similar reasons to streamer 2.**

# Streamer 4
A UWP program which given the html code of a group's channel, turns it into a list of videos and plays them. This is the best option as it can quickly retrieve every video you need, as well as using an internal browser, and as such, allowing you to continue using the device.
#### Usage
Go into the Dependencies folder, and install all dependencies. Then install the certificate. You can then install the appxpackage which will then install the program. Simply then run the program, and go to your channel's video page. Inspect element, and search for "content-list". Right click and copy the outer html, and copy it into the textbox. Note that if you want more videos, scroll down more to load more videos up. Then simply click "Convert". On the "Home" tab, make sure to login and set a resolution (144P/270P). Then when all that's done, simply start.

These were a fun way for me to learn a bit of C#, and were also my first attempts of automating something a bit difficult. I'll probably be updating this soon. I had a "Streamer 5" which works fine, and is much better overall, but due to it storing files locally, it takes up gigabytes of space, and isn't suitable to upload. I'll probably update this for fun and use a remote database instead to retrieve content.
