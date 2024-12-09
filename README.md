<<<<<<< HEAD
# DarkSoulButWorse
 But worse mini project
=======
# DarkSoulsButWorse-butbetter-
>>>>>>> b34fede2c512cdf850b8fbfa402d4e899525f52c
MINI-PROJECT
DARK SOULS (But worse (but also better))
Sigurd Reseke Juul



1. Overview of the Idea and Project Parts
Idea Overview
 My idea for the "But Worse" Mini-project is to make Dark Souls, but worse, an infamous and notorious game known for it’s revolutionizing game mechanics and difficulty. While my project could never live up to the standards of this beloved game, I still wanted to get a crack at it and see if I could get the controls and “feel” down. This is done to explore the core mechanics of the game while introducing intentional design limitations to make the experience more clunky, less polished, and intentionally "worse" than the original.

Core Concept:
Dark Souls, known for its challenging combat, exploration, and atmosphere, is reimagined with deliberately poor mechanics. This includes slower, less responsive character control, clunkier animations, unintuitive user interface (UI), and exaggerated physics interactions.
Key elements like combat, movement, enemy AI, and ragdoll physics are implemented with simpler, less polished mechanics to give the player a frustrating and humorous version of the game.


Simple player and enemy models imported from Blender FBX



Project Parts
I chose to focus on the following components: 
An interactive camera that is focused on the player which can be turned with mouse movement (Like in Dark Souls)

A fully animated character that can be controlled directly through WASD and additional input
Objects and characters in the 3D world that can be interacted with by the player (mainly by hitting) primarily with use of rigidbodies
Enemy AI that follows you via NavMesh
Level creation made with terrain tools
animated Player and Enemies
Here’s a list of the key project parts I used with short descriptions of each component, their use, and what they do in the game:
Scripts:
PlayerMovement.cs:
Purpose: Controls the player character’s movement and combat actions.
Implementation: Allows the player to move with keyboard inputs, rotate toward the movement direction, and execute basic combat actions like swinging the sword. It also manages animations (like idle and walking) and the hitbox during the sword swing.
SwordHitbox.cs:
Purpose: Manages the sword hitbox during attacks.
Implementation: When the player or enemy swings the sword, this script enables a collider that detects collisions with other objects (enemies or physics objects) and applies damage and force. It also disables the collider once the attack animation is over.
EnemyAI.cs:
Purpose: Controls enemy behavior, such as patrolling and attacking the player.
Implementation: Includes logic for the enemy to chase the player when in range, attack using its sword when close, and trigger its own SwordHitbox to deal damage to the player. Also manages the enemy's death animation (ragdoll) when health reaches zero.
EnemyHealth.cs:
Purpose: Manages the health of the enemy.
Implementation: Tracks the enemy's health, reduces it when damaged, and triggers the enemy’s death (ragdoll physics) when health reaches zero.
PlayerHealth.cs:
Purpose: Handles the player’s health and damage.
Implementation: Similar to EnemyHealth.cs, it tracks the player’s health and triggers player death when health is depleted.
One of the bigger hurdles with the code was normalizing the input directions with the camera direction. Since the mouse and WASD input are independent of one another, to not desorient the player (me) I need to find a way to get the standard unity movement input to correlate with the current direction of the where the player (me again) is pointing the camera with the mouse, so that for example W is always the direction you point the camera. This was done by retrieving the forward and right vectors of the camera via these lines of code:
 Vector3 cameraForward = cameraTransform.forward;
Vector3 cameraRight = cameraTransform.right;




Hierarchy Objects:
Player:
Components: Character controller, animator, and sword (with a collider).
Purpose: Represents the player character, with logic for movement, combat, and health.
Enemy:
Components: NavMesh Agent, animator, sword (with a collider), health script.
Purpose: Represents enemy NPCs with basic AI for movement, chasing the player, and attacking.
Sword:
Components: Collider (set as a trigger), linked to the SwordHitbox script.
Purpose: The sword of both the player and enemy, used for performing attack animations and detecting hits.
Camera:
Components: Third-person camera script.
Purpose: Follows the player’s character from behind and allows the player to control camera orientation.

Materials:
Player Materials:
Purpose: Defines the look of the player, including clothing, sword, and overall texture for the character model.
Enemy Materials:
Purpose: Similar to the player, defines the materials applied to the enemy character model, including textures for its body and armor.
Ground and Environmental Materials:
Purpose: Textures and materials for the environment (terrain, obstacles, etc.), using basic or simplified textures to give it a "worse" visual style.
Levels:
Level 1 (Simplified):
Purpose: The game environment where the player first spawns and interacts with enemies.
Implementation: A small area with terrain, obstacles, and some basic enemy NPCs, where the player can test movement, combat, and interact with the environment.
Key Features: Simple geometry, limited environmental features, minimal UI.
The hilly terrain was accomplished via Unity’s own Terrain Sample Pack from unity assets store, using the terrain brush to draw desired terrain!
2. Time Schedule and References
This section includes the estimated time for different parts of the project:
Project Part
Estimated Time (Hours/Min)
Scripts


PlayerMovement.cs
1H
SwordHitbox.cs
10M
EnemyAI.cs
1H
EnemyHealth.cs
15M
PlayerHealth.cs
15M
Hierarchy Objects


Player
3H
Enemy
1H
Sword
5M
Camera
10M
Materials


Player Materials
30M
Enemy Materials
15M
Ground and Environment Materials
1H
Levels


Level 1 (Environment Setup)
1H
Physics (Ragdoll)


Ragdoll Physics (Enemy)
30M






The main time constraints I experienced was that of modelling and animating the player character in Blender. Though a simple model there were a lot of shortcomings when parenting the armature and getting all parts of the model to move as intended. This is also part of the reason why the model has a limp in his walk cycle (his sword is very big and heavy don’t judge him). Additionally there were some problems with normals facing the wrong way and materials not loading properly and such.

3. References.
Resources Used:
Unity Documentation for Character Controllers, Ragdoll Physics, and NavMesh:
https://docs.unity3d.com/Manual/index.html
YouTube Tutorials for Third-Person Character Controller and Basic AI:
https://www.youtube.com/watch?v=4HpC--2iowE&ab_channel=Brackeys
https://www.youtube.com/watch?v=VcNly-cMZV4&ab_channel=Unity
https://www.youtube.com/watch?v=aHFSDcEQuzQ&list=PLllNmP7eq6TSkwDN8OO0E8S6CWybSE_xC&ab_channel=LlamAcademy
Unity Asset Store for simplified assets and models for the game environment and characters.
AI (ChatGPT/Copilot) A lot of the code heavy lifting was done with the use of AI. For additional information and details for the code, each script contains comments that are easily accessible if any curiosity towards the individual lines of code persists!



Surface NavMesh baked for enemy AI usability (Didn’t know where else to put it)
