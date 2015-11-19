# OBLITERATION NATION
AUC August'2015 Capstone Project

## PRACTICUM READ ME
ReadMe -- The Practicum Guide

###### Steps To Contribute
* Make A Github account
* Download a git application
  * [Github Desktop](https://desktop.github.com/)
* Clone the Git (NOT FORK)
  * URL :: https://github.com/lordsolrac/FurryGame2015
  * git :: git@github.com:lordsolrac/FurryGame2015.git
* [Download Unity](http://unity3d.com/get-unity/download?ref=personal)
* Open the Project with Unity
* Read The Guide Below


###### Contributing
To Add New things to the Project, the contributor must make a pull request. A list of pull requests [can be seen here](https://github.com/lordsolrac/FurryGame2015/pulls).

The pull request's commit can be done either manually by dragging objects to the pull request.

You can also export a UnityPackage and upload such.

This Segment will be updated as it continues to grow.

###### Importing Assets
In Unity, there are 3 ways to Import Packages;
* Drag and Drop Files onto their respective folders
* Right Click in the Asset Browser and select Import Asset
* Import Asset Pack > Custom Package (UnityPackage)
Please Make sure everything goes to their proper place. Keep the project clean.

###### The Game's Folder Architecture
The Game's Assets are organized by Usage Type.

* Models and Stage Parts (Just Drag-Drop and Adjust on Level)
  * Exterior Assets
    * Models > Stage Parts > Exterior
    * Models > Stage Parts > Buildings
  * Interior (Background)
    * Models > Stage Parts > Interior
  * Prefabs (Things with Specific Extras)
    * Prefabs > Stage Parts > Exterior
    * Prefabs > Stage Parts > Interior
    * Prefabs > Stage Parts > Floor
    * Prefabs > Player&Items


* Scripts and Codes (Technical Parts)
  * Prefabs > (Category) > Scripts

* Maps and Scenes
  * Maps > Dev* (The Testing Rooms)
  * Maps > Exterior (The Exterior Levels, another document goes here)
  * Maps > Interior > (AreaName)

* Enemies and Player Models and Animations and Textures
 * Models > Enemies (> Materials > Textures)
 * Models > Players (> Materials > Textures)
 * Models > Items (> Materials > Textures)

###### Making Levels
In Unity, Maps, Menus and such are considered 'Scenes'. We're keeping them organized by their type (Dev,Ext,Int,Menu,CutScene?). This keeps everything clean and easy to access. To create a new Level, there are some rules.

The Floor is Y 0. The Player is always at X 0, Thus nothing can be near it. Distances should be at least X +/- 15. Objects such as Light Posts should go near the buildings, other such as benches and cars can be closer. Some can even be an obstacle. (But they'd need to be prefabs, with colliders)

###### The Design Workflow
If you don't know how a level should be made, here's a theorical step-by-step guide.

1. Make a design (on Paper)
2. Make the Floor, and the Path.
3. Add the Background
4. Add the notable details (buildings, lamps, tv, etc)
5. Clean the place (don't make a mess)
6. Add Secondary Details (Hanging stuff, trees, plants, etc)
7. Add Obstacles (Cars, enemies, etc)
8. Add Items and NPCs (Ammo, Health, Trades, and maybe more)
9. Test the Level (Test not only is it working, is it playable?)
10. Revert to Step 5. If Finish, Push to the pull request.

* NPCs and Trades
  * The NPC system is still under development
  * Currently NPCs can only talk, nothing more
    * Add Component > NPCMsg ('___' without quotes, marks new line.)
