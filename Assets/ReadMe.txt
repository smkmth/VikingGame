---- In order to get the game to run ----

1. In the Project Explorer, open the 'Scenes' folder. 

2. Double click on BaseScene. 

3. After that scene loads, you should see a pink bean in the middle of the screen. 

4. Drag the sample scene from the project explorer to the bottom of the inspector. 

5. You should now see that same bean but surrounded by blocks and stuff.

---- Folder structure ----

No strict conventions atm, just following general good practice in unity- solidify and formalise this stuff later- atm 

--EntityCache -- Wierd unity stuff, dont touch, doesnt do anything in the game

--Materials -- where the different materials will be stored.

Prefabs -- prebuilt gameobjects which can be dragged and dropped into any scene 

--ItemGrid-  this is a ui prefab for an inventory grid.
-Player - this is the player, with a camera and UI and space for meshes and stuff
-NPC - this is a pathfinding guy with a schedule and stats

--Scenes -- You need both of these scenes running to make the game work.
-SampleScene is the 'world' with all the items, buildings, and landscape - all static stuff
- BaseScene is the dynamic stuff, like the player, the clock, the sun, NPCs, gamemanagers, 
anything with I/O and persistance between scenes. 

-- ScriptableObjects -- These are the data representing the itmes in the game. You can make new items by right clicking on the project window, and clicking on create, then going to the Items menu, and choosing a type of item to create.
Any Data that the item needs is held in this scriptalble object, the data is then executed by the scripts

-- Scripts. its easiest to think of the scripts as components which modify game objects in the scene. For instance, the CameraControl script makes the camera move with the mouse when attached to a game object with a camera
-Entity - stuff in the scene, like enemies, the player, itemscontainers ect
- Pathfinding - everything relating to pathfinding, complicated stuff you dont need to bother with
- ScriptableObjects - where the programing for the scriptable objects is. These scripts are pure data types so cant be dragged into the scene like the rest of the scripts
- World - stuff that holisitically effects the entire map, like Time, or locations, or enemy spawning
-BaseScene - a small script that keeps hold of whatever it is attached to and the children between loads, so we can have persistant stuff between loading different scenes

--Sprites - where all the sprites for the ui are kept. At the momement i just picked a pixle art style for this stuff, but we can replace the sprites with whatever we want at runtime 

--TextmeshPro - Unity UI stuff - not anything i did. 





