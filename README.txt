Silver HTPC README.txt


Silver HTPC opens up on the Home screen. From there user can navigate the screen to go to other screens including:
Other Applications, Music, Gallery, Recordings, Settings & Advanced Settings, TV Guide, Live TV, Search, Notifications.

=====================
Button Instructions
=====================

  ~Keyboard keys are used to simulate the button presses on the remote~

  Power = N/A
  Settings = ? (Key.OemQuestion)
  Home = h
  Volume + = +
  Volume - = -
  Mute = m
  Back = backspace
  Arrows = arrows
  OK = o (instead of 'enter')
  Rewind = <
  Play/Pause = p
  Fast forward = >
  Search = s
  Guide = g
  Info = i
  Numbers = numbers
  Notification pop-up = z
  
=====================
 Main Menu
=====================
  * Features
    - Notification pop-up: press Z, which would bring up a notification (ideally it would be done automatically)
    	- when pop-up is open, if OK is pressed, the user will be navigated to a tv screen.
    - When Notification pop-up comes up, an indicator on the notification app appears.
    - Volume could be used using + and - (works for the following range 38-53)
    

  * How to navigate this screen
    - ARROW KEYS to move between buttons
    - OK to select

  * What's not implemented
    - When Other apps is selected, the 7th (bottom left) app would be replaced by amazon prime and would reorganise the list. So app sorting doesn't work between these two interfaces

  * What should be selected
    - Select any app except Netflix and Amazon prime to go navigate to that page.
    - when the profile button (top left) is selected, a pop-up showing the profiles would appear.
  
  * Shortcuts
    - Press Search (s) on remote to go to search
    - Press Settings(?) on remote to go to settings
    - Press Guide(g) on remote to go to TV guide
    

=====================
 Profile
=====================
 * Features
    - Notification pop-up: press z, which would bring up a notification (ideally it would be done automatically)
    	- when pop-up is open, if OK is pressed, the user will be navigated to a tv screen.
    - When Notification pop-up comes up, an indicator on the notification app appears.
    - Volume could be used using + and - (works for the following range 38-53)
    

  * How to navigate this screen
    - ARROW KEYS to move between profiles options
    - OK to select
    - When adding profile use BACK to cancel adding profile
    - BACK to go back from profile screen to Home

  * What's not implemented
    - Cannot type when adding the profile and also cannot create a new profile
    - Selecting the current profile would ideally take user back to home screen but it is not implemented

  * What should be selected
    - Select Add profile only


=====================
 Other Screen
=====================
  * Features
    - Scrollable List
    

  * How to navigate this screen
    - ARROW KEYS to move between buttons
    - OK to select
    - BACK to go back to homescreen

  * What's not implemented
    - Navigation to apps other than Amazon Prime is not imlpemented

  * What should be selected
    - Select Amazon prime to go navigate to that page.
  
  * Shortcuts
    - Press Search (s) on remote to go to search
    - Press Settings(?) on remote to go to settings
    - Press Guide(g) on remote to go to TV guide
    - Press Home(h) on remote to go to home screen
    
    
=====================
 Notification
=====================
  * Features
    - Scrollable List
    - Notification expiry: Press Z, which would remove the 4th (last) notification from the list and replace it with a label for a few sec before disappearing
    

  * How to navigate this screen
    - ARROW KEYS to move between buttons
    - OK to select
    - BACK to go back to homescreen

  * What's not implemented
    - Selection of Notification other than the Live TV notification is not implemented

  * What should be selected
    - Select Notification with Live TV
  
  * Shortcuts
    - Press Search (s) on remote to go to search
    - Press Settings(?) on remote to go to settings
    - Press Guide(g) on remote to go to TV guide
    - Press Home(h) on remote to go to home screen
    
        
=====================
 TV Guide 
=====================
    Currently-on and upcoming shows are organized by category. 
    Browsing works similar to the way it is on streaming services like Netflix.
    
  * Features
    - Users can go to currently-on shows
    - or set reminders for upcoming shows by selecting them.

  * How to navigate this screen
    - ARROW KEYS to move between shows
    - OK to select
    - BACK to go back to homescreen

  * What's not implemented
    - Not all shows are viewable.
    - Which shows redirect to live tv screen and which triggers Set Reminder pop-up is not based on actual show-time but is hard-coded.
    - Setting/canceling reminder not implemented.
    - Displayed show-time hard-coded and not in sync with system time.

  * What should be selected
    - Selecting Sherlock or Top Gear (the first and second show on the guide) takes user to the Live TV screen where a screen capture is available.
    - For setting reminders, scroll to and select third show or onward from the list (category doesn't matter).



=====================
 Live TV
=====================
  Live TV screen displays live shows. 

  * Features
      -Slide-out sidebar which contains:
	      - time/date
	      - show description
	      - scheduled reminders
	      - record button

  * How to navigate this screen
    - INFO button on the remote ('i' key) to open/close info sidebar
    - BACK to go back to tv guide

  * What is not implemented
    - record button not implemented
    - show description is hard coded to be for Sherlock



=====================
Music
=====================
 This screen allows users to manage their music.
 
  * Features
    - Scrollable list which displays all music
    - Buttons
    	- Add music
	- Sort music
	- Delete multiple
    - Users can play music
    - Users can delete music
    	- Pop-up confirmation message to delete music
	- Notification when music is deleted
    
  * How to navigate this screen
    - ARROW KEY navigation to navigate through list as well as the buttons on the side
    - BACK to go back to the main menu
    - OK to select an option
    
  * What is not implemented
    - Functionality for add button
    - Functionality for sort button
    - Functionality for delete multiple button
    
  * What should be selected
    - Anything with play or delete on the actual music buttons can be selected. After selecting them you can also interact with the reverse/play/forward buttons that appear on the side.
     - Selecting delete will ask for a confirmation message with yes and no, if you would like to go through the delete
    
=====================
Recordings
=====================
  This Screen allows users to manage their recordings.

  * Features
    - Similar to music, allows users to play and delete their recordings
    - Buttons
    	- Sort By
	- Add
	- Delete Multiple

* How to navigate this screen
  - ARROW KEY navigation to navigate through list as well as the buttons on the side
  - BACK to return to the main menu
  - OK to select an option
  
* What is not implemented
   - Functionality for add button
   - Functionality for sort button
   - Functionality for delete multiple button
   
  * What should be selected
    - Any of the buttons on the screen can be selected. Play will direct you to "Recording Playing" screen
    - Selecting delete will ask for a confirmation message with yes and no, if you would like to go through the delete
    
    
=====================
Recording Playing
=====================
 This Screen shows what happens after you press play from the Recordings screen.
 
* Features
  - Slide-out sidebar which contains:
	      - time/date
	      - show description
	      - scheduled reminder
   - Progress bar which appears at the starting of the recording
   
   

* How to navigate this screen
  - BACK key to go back to the recording screen
  - I key to bring up and close the info side bar
  
* What is not implemented
  - Functionality for pulling up the progress bar again after the recording has started 
  
* What should be selected
  - There is nothing to be selected on this screen
  
  
  
=====================
Gallery
=====================
 This Screen allows users to manage their pictures and videos.
 
 * Features
    - Buttons
    	- Sort By
	- Add
	- Delete 
	
* How to navigate this screen
  - ARROW KEY navigation to navigate through pictures/videos and buttons
  - OK to either select a picture/video or button which will open a new screen
  
* What is not implemented
   - Functionality for add button
   - Functionality for sort button
   - Functionality for delete button
   
* What should be selected
  - One of the images on the screen should be selected, upon selection a new screen will open up "Viewing Gallery"
  
=====================
Viewing Gallery
=====================
 This screen allows users to view their pictures/videos in a fullscreen manner.
 
 * Features
   - Right and Left arrows
   
 * How to navigate this screen
   - LEFT ARROW KEY to navigate to pictures on the left
   - RIGHT ARROW KEY to navigate to pictures on the right
   - BACK key to return to the Gallery screen
   
* What is not implemented
   - Functionality for add button
   - Functionality for sort button
   - Functionality for delete button


=====================
Settings
=====================
This screen allows users to change the system settings

* Features
   - Text size slider to increase or decrease fontsize
   - Language options
   - Button guide to pull up instruction on which buttons to use on this screen
   - Button to go to advanced settings
   
 * How to navigate this screen
   - Text size slider: ARROW KEYS increase and decrease the font size, TAB to the languages
   - Languages combobox: ARROW KEYS to see options, TAB to move on down, O to go back up to slider
   - Button guide: ENTER to toggle, Z to activate and open up "Button Guide Settings", UP and DOWN ARROW KEYS to navigate
   - Advanced Settings: O to select, UP and DOWN ARROW KEYS to navigate
   - BACK key to return to the Main screen
   
* What is not implemented
   - Functionality for changing universal text size
   - Functionality for changing languages

=====================
Button Guide Settings
=====================
This screen is the same as Settings, but it has instructions on-screen for which buttons to use

* Features
   - Same as Settings
   
 * How to navigate this screen
   - Same as settings
   - BACK key returns to Main Menu with its button guide turned on
   - Z while hovering on the button guide takes you back to regular settings
   
* What is not implemented
   - Functionality for changing universal text size
   - Functionality for changing languages
   - No button guide for Advanced Settings

=====================
Advanced Settings
=====================
This screen provides users with more system settings to change (the less common ones)

* Features
   - Magnifier option to bring up an on-screen magnifier (not implemented)
   - Colour blind accessibility options
   - Option to turn on or off notifications
   
 * How to navigate this screen
   - Magnifier: ENTER to toggle, UP and DOWN ARROW KEYS to navigate
   - Colour blind combobox: ARROW KEYS to see options, TAB to move on down, O to go back up to slider
   - Notifications: ENTER to toggle, UP and DOWN ARROW KEYS to navigate
   - BACK key to return to the Settings
   
* What is not implemented
   - Functionality for magnifier
   - Functionality for colour blind accessibility
   - Functionality for notification preferences
  

  
  
