# Gameplay description
My final game design project will be a game where the player is falling down some giant bottomless hole and they need to dodge out of the way of incoming objects with the goal of achieving the highest score possible. The game will also feature enemies in which the player can shoot with their projectile in order to accrue points. While falling the goal of the player will be to reach as far down they can get before getting hit by an enemy or object. There are also useful items that the player could pick up like health regain items and alternate weapons. There is no proper end to this, it is arcade style meaning the goal is to get a highscore and the game ends when you die. The time spent falling is tracked on the screen. The player has a health bar which decreases each time they are hit by an object or enemy; it would take 3 hits for the health bar to drain to zero. Upon contact with the player enemies and objects will disappear. As the player survives their fall they will fall at increasing speeds based on how many minutes they've been falling.

Unity engine wise I will have the player stationary and simulate them falling through animation of the walls seeming like they are rising and the player looking like they are falling. There will be a fog at the bottom of the hole which objects will ascend out of to make it look like the player is falling further and further down. Objects will destroy themselves when they leave the camera view of the player. To simulate the player falling quicker the objects will move up quicker as time goes on.

Enemies will spawn outside the camera's view and will move on the X and Z axis unlike the objects. Different enemy types will move differently but for sure there will be a type that moves towards the player. Others could simply zig-zag across the screen. The player can choose to shoot the enemies that are non-hostile for points or let them walk off the screen freely.

power-ups will show up on the screen like the objects that will impede the player's path. They will spawn in the mist below the player and rise up.

# Input
The player will be able to move around inside the while with WASD and be able to aim and shoot with the mouse. Movement is only across the X and Z axis. the player cannot move across the Y axis. Killing an enemy adds .02 to your enemies killed multiplier which starts at 1.0. The score will be calculated at the end by multiplying the time spent falling with the enemies killed multiplier.

# Visual style
The visual style will ideally be a mix of 2D pixel art and 3d rendered objects. Objects like the player and enemies will be 2D pixel art while things to avoid like boulders or other random assortment of objects will be 3D rendered objects. Currently the idea for the style/flavor of the game will be like a dirty mine with bulky futuristic technology. This flavor is purely because I want to have the song playing while falling from the risk of rain 2 soundtrack. The closest game I can think of with a similar style would be Deep Rock Galactic.

# Audio style
Audio-wise there will be falling wind like noises and a song playing while falling. Shooting and killing enemies will also make sounds. Getting hit by a falling object will also make a sound.

# Interface Sketches

![Interface Sketches](https://github.com/ErikMelchers/csc470-fall2023/blob/main/assignments/final/Interface_Sketch.jpg)


# Targets
Low Bar: start menu and Lose game screen showing score. working movement and shooting with at least 1 enemy type and working objects coming from the fog at the bottom. This goal lacks working powerups, a variety of enemy types, and good visual style
Medium Bar: all of the above including a working power-up, at least 2-3 enemy types, and animations, particle effects. As well as a scoreboard in the start screen. This is the bar where I add pixel art to the character and enemies. (and UI).
High Bar: All of the above and more enemy types, more power-ups like a new weapon-type, a start screen that is a different scene, a scoreboard that saves scores even when game closes, and even more visual flare.

# Timeline

12/2: work on web design Final 
12/3: finish web design Final
12/4: Work on Software engineering final
12/5: Finish Software engineering final (Due)
12/6: work on Capstone Final. (Web Design final Due)
12/7: Work on Capstone, Work on Game Design Final to get core mechanics working
12/8: Work on Capstone, Work on Game Design, Work on AI Final
|
|
|
|
|
12/14: AI Final and presentation Due. Capstone Final and presentation due
|
12/15: Game Design Final Due