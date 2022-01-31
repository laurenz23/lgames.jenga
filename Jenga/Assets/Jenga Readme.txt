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
		• d for Development: v1.1.1d  
		• b for Beta: v1.1.1b
		• a for Alpha:  v1.1.1a
		• r for Release: v1.1.1r


NOTE: ALWAYS UPDATE VERSION IN UNITY ------------------------------------------


To do for next updates: v0.1.2d
	- Added MainMenu Scene
	- Added UI Navigation and UI Buttons 
	- Create a initial functions for UI
	- Create functionality for Time limit for each player moves
	- Improve Jenga Piece Pick Functionality 
	- Improve Game Physics 
	- Refactor 


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