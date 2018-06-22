# VICTRLab-FPS
## Cops and Robbers
Cops and Robbers (working title) is a game to be used in a social experiment run by VICTRLab under the guidance of Professor Pena. 

To begin editing the project on your own computer simply download the Github repository and open up the Virtual Shop.unity scene on Unity. 
This is the main scene that is the beginning of the level. Other scenes that you will need to edit will be the Main Menu.unity scene and the Level1.unity scene
The main menu is the starting scene in the game where you can choose which situation to play, to battle the cops or to battle the robbers.
Level1 is technically the second level of the game. After clearing the first building you will head through a door that leads into this scene, where the player will have to face more enemies.

In order to test the game entirely compiled you must go to the root of the project and open up VirtualShop.exe

# Scripts
This game utilizes various scripts to program the player, enemies, and the HUD. 

## Player
In the standard assets folder there are various scripts related to the first person character. 

### FirstPersonController.cs
By default the first person character comes with a script provided by Unity. However, this script had to be modified in order to enhance movement in some areas and restrict movement in others. 
For example, by default the first person character is able to use the shift key to sprint and is able to jump with the space key. These will be removed by the final version of the game, but are kept for testing. 

### Crouch.cs
One of the abilities added to the game is crouching. By pressing the C key the player's view will be shifted downward and their speed will decrease. 
The firstPersonController script is the one that calls the Crouch script in order to minimize the delay between clicking on the key and the action occurring. 

### AimDownSights.cs
The player is also able to hold down the right button on the mouse in order to bring the gun to the center of the screen to line up shots better. 
This causes the player to also slow down to about the same speed as when they are crawling. 

### GunFire.cs
If the player clicks the left button on the mouse they will be able to fire their gun. Shooting the gun is done with raycasting, so the player will definitely hit whatever they are pointing if it has a collision box. 

### Reload.cs
As the player shoots the gun they will use up their ammo. If they reach zero bullets in the gun, and they have ammo in reserve they can press the R key to reload their gun. The HUD will show the ammo has been reloaded. Since an animation plays to reload the gun other scripts are diabled for the duration of the animation.

### AmmoPickup.cs 
The enemy will leave ammo on the ground when it dies, and when the player walks over the ammo they will pick it up and the ammo will either be added to the ammo in reserve or will be automatically loaded into the gun. 

## Enemy
Many of the scripts that are used to program the enemies rely heavily on how the player interacts with the world. 

### Target.cs
This script is mostly used to keep the enemy instance updated on what its health is. We can set the enemies' health to whatever we like, but for right now it's set to 30 and the player can deal a damage of 10 hitpoints per shot. 
When the enemy is shot its health goes down the given amount. When its health reaches zero it leaves ammo on the ground for the player to pickup and begins to bleed. The ammo left behind will be in the form of a gun that is "dropped" by the enemy. 

### Follow.cs
This is the script that allows the enemy to follow the player's movements. When the player is at a similar height to the enemies they will turn towards the player and begin to shoot. 
The script allows the enemies to switch animations from being idle to shooting. Also, enemies can be designated to crouch at random times. This is done so that enemies can randomly duck behind shelves in the store to take cover from the players bullets to increase gameplay difficulty. 
The enemies are also set to raycast hit the player, so when they hit the player the player's health will go down. 

## HUD
Some of the scripts created are done to give the player feedback on how they are doing in the game. 

### PlayerHealth.cs
This script controls a "bloodsplatter" effect that goes on the screen when the player takes damage. When the player reaches certain amounts of health the script will enable images on the HUD that will blind the player. The player will regain health overtime and while their health is regenerating the images will become more and more opaque. 

### GlobalHealth.cs
This script displays the available ammo on the HUD. The bullets inside the gun are displayed on the left and the number of bullets in reserve are displayed on the right. 

## Misc
Many more scripts can be created and used for other parts of the environment though. 

### LoadLevel1.cs
This script is tied to a collision box on a door that allows the player to go to a different room to fight more enemies. Specifically this loads up the Level1 scene.

### Play.cs
This script is used in the Main Menu scene that starts up the main game after the player chooses whether to play against the cops or the robbers. 
Depending on the option selected a boolean will be set to trigger the ChangeMaterial script.

### ChangeMaterial.cs
This script causes the enemies to switch between two different materials that allow us to identify them as either the cops or the robbers. 

### PersistentManagerScript.cs
The PersistentManagerScript allows for global variables to be created. They are created once at runtime and are not destroyed after a scene change and neither are new instances allowed to be created when an instance already exists.
This allows for us to create an instance of a boolean in the main menu that can be set when the player choose an option and that boolean can be used for the rest of the scenes within the game.