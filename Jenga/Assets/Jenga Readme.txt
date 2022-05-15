Jenga Game : Created Jan 15 2022
For Versioning:
	- vX.Y.Zphase / Major.Minor.Patch+Phase
	- Major Increments:
		• Software Reskinned
		• Adding System like Multiplayer or Achievements
	- Minor Update:
		Increments at:
			• Each Minor Release:
				Adding Functionality
				Adding Music
				Adding Sound FX
				Fixed Bugs
				And more...
		Reset at:
			• Each Major Release 
	- Patch:
		Increments at:
			• Each Updates of Major or Minor changes 
		Reset at:
			• Reset Every Release
	- Phases:
		• d for develop: v1.1.1d  
		• b for beta: v1.1.1b
		• a for alpha:  v1.1.1a
		• r for release: v1.1.1r


NOTE: ALWAYS UPDATE VERSION IN UNITY ------------------------------------------
Target Relase On Last Sunday of February: Feb 27 2022
To do for next updates: v0.1.4d
	- Start working on game arts
	- Start creating game background
	- Start creating on UI to push, pull or rotate jenga piece when selected
	- Create a function that display the number of stories of Jenga Pieces
	- Improve Jenga Piece Pick Functionality  
	- Replace a camera to Cinemachine
	- Create 3 cameras:
		• First Camera for player selecting and removing the jenga piece from stack
		• Second Camera for transition, moving the first camera to third camera
		• Third Camera for arranging the jenga piece to new story indicator


Doing for this updates: v0.1.3d
	- Improve Game Physics 
	- Add functionality where the new story indicator back to previous position when jenga piece is remove
	on where it is place
	- Add functionality for Camera to zoom in and zoom out
	- Refactor 

Bugs:
	- When Switching between main menu and in game scenes.
	The lightning at in game scene is not in correct lightning.


Updates Feb 12 - 16 2022: v0.1.3d
	- Bug Fixes:
		• New Story Indicator hides all when one jenga piece is trigger the piece indicator all at once
		• New Story Indicator is trigger multiple times, setting new y position very high
		• Remove JengaPiece annoying movement when stack is getting higher.
	- Refactor
	- Improve game physics:
		• Modified JengaPiece Prefab mass to 100,000
		• Modified Game Gravity force at GameManager to -20f
	- Added a action phase when stacking the jenga piece
	- Added a functionality to check if inside or outside of the stack
	- Added a functionality when a selected jenga piece is removed successfully from the stack
	it will move automatically to the highest point of jenga story


Updates Feb 5 - 7 2022: v0.1.2d
	- Added MainMenu Scene
	- Added UI Navigation and UI Buttons 
	- Added UI that display the stories of Jenga Pieces
	- Created initial functions for UI
	- Created functionality for Time 
	- Created scene template
	- Improve Camera Functionality Rotation, Moving
	- For Camera Rotate at xAxis only, move at yAxis, and zoom at zAxis
	- Created an initial highlighted story 
	- Created an function to auto rotate the jenga piece when put at highlighted piece
	- Create a function to get higher the highlighted story when all are occupied


Updates Jan 29 - 30 2022: v0.1.1d
	- Created Branch for Development. Master is Release version
	- Implemented Game Version
	- Added JengaManager Script
	- The manual adding of JengaPiece is remove and change to
		instantiating when the game is started
	- Added three colors to identify the JengaPiece much easier
	- Added more JengaPiece
	- Change the default monobehaviour templates 
	- Refactor 


Updates Jan 23 - 24 2022: Initial
	- Added GameManager
	- Added GameStateManager, interface, and enums 
	- Added more Jenga Pieces 
	- Implemented Resume and Pause for JengaPieces and InputController
	- Implemented Game State for the following scripts:
		• JengaPiece
		• MainUIManager
	- Implemented Listener for ScreenInputs
	- Fix bugs:
		• Camera Controller
		• Jenga Piece pick function
	- Refactor 


Created Jan 15 - 16 2022: Initial
	- Pull project from Github
	- Created Project structure
	- First initial commit
	- Added Jenga piece physics
	- Created a class that handles screen input: 
		• Added functionality to emphasize jenga piece when hover or selected
		• Added functionality to drag a jenga pieces
	- Created a class that handles Camera Controls:
		• Added a function to able the camera to rotate at the target object