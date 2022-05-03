# **Asleep**

## _Game Design Document_

---

##### ** Designed and built by Magic Mole Studios / Copyright notice / author information / boring legal stuff nobody likes**

##
## _Index_

---

1. [Index](#index)
2. [Game Design](#game-design)
    1. [Summary](#summary)
    2. [Gameplay](#gameplay)
    3. [Mindset](#mindset)
3. [Technical](#technical)
    1. [Screens](#screens)
    2. [Controls](#controls)
    3. [Mechanics](#mechanics)
4. [Level Design](#level-design)
    1. [Themes](#themes)
        1. Ambience
        2. Objects
            1. Ambient
            2. Interactive
        3. Challenges
    2. [Game Flow](#game-flow)
5. [Development](#development)
    1. [Abstract Classes](#abstract-classes--components)
    2. [Derived Classes](#derived-classes--component-compositions)
6. [Graphics](#graphics)
    1. [Style Attributes](#style-attributes)
    2. [Graphics Needed](#graphics-needed)
7. [Sounds/Music](#soundsmusic)
    1. [Style Attributes](#style-attributes-1)
    2. [Sounds Needed](#sounds-needed)
    3. [Music Needed](#music-needed)
8. [Schedule](#schedule)

## _Game Design_

---

### **Summary**

Videojuego del género "puzzle platformer" y tipo "maker" que
sigue la historia de una niña atrapada en sus sueños la cual para despertar debe de alcanzar una luz. <br>

A puzzle platformer videogame that offers a "maker" modality. It follows the story of a girl trapped in her dreams and in order to wake up she has to reach the light.  

### **Gameplay**

Con respecto a la narrativa del juego, como se mencionó anteriormente, sigue las aventuras de la protagonista y lo que necesita hacer para despertar, alcanzar la luz. Para poder despertar, ella necesita resolver diferentes puzzles bajo determinado tiempo antes de que la alcance la pesadilla. <br>
El propósito del juego con respecto al usuario es lograr reforzar conceptos como el diseño y la construcción gráfica de un videjuego por medio de la modalidad "maker" del mismo. Dicha modalidad permite que el usuario cree y customice sus propios niveles y la dificultad de ellos. <br>
El obstáculo principal que enfrenta el usuario es armar el nivel que le permita llegar a la meta, otros obstáculos son las cajas, el enemigo y la pesadilla. 

### **Mindset**

Lo que se quiere provocar en el jugador es que sea capaz de resolver puzzles bajo presión (estar cronometrado), sabiendo que hay algo persiguiendolo. Aunque se provoque en el jugador emociones como la ansiedad o los nervios, el usuario necesitará guardar la calma. 

## _Technical_

---

### **Screens**

1. Title Screen
    1. Options
2. Level Select
3. Game
    1. Inventory
    2. Assessment / Next Level
4. End Credits

_(example)_

### **Controls**

How will the player interact with the game? Will they be able to choose the controls? What kind of in-game events are they going to be able to trigger, and how? (e.g. pressing buttons, opening doors, etc.)

### **Mechanics**

Are there any interesting mechanics? If so, how are you going to accomplish them? Physics, algorithms, etc.

## _Level Design_

---

_(Note : These sections can safely be skipped if they&#39;re not relevant, or you&#39;d rather go about it another way. For most games, at least one of them should be useful. But I&#39;ll understand if you don&#39;t want to use them. It&#39;ll only hurt my feelings a little bit.)_

### **Themes**

1. Forest
    1. Mood
        1. Dark, calm, foreboding
    2. Objects
        1. _Ambient_
            1. Fireflies
            2. Beams of moonlight
            3. Tall grass
        2. _Interactive_
            1. Wolves
            2. Goblins
            3. Rocks
2. Castle
    1. Mood
        1. Dangerous, tense, active
    2. Objects
        1. _Ambient_
            1. Rodents
            2. Torches
            3. Suits of armor
        2. _Interactive_
            1. Guards
            2. Giant rats
            3. Chests

_(example)_

### **Game Flow**

1. Player starts in forest
2. Pond to the left, must move right
3. To the right is a hill, player jumps to traverse it (&quot;jump&quot; taught)
4. Player encounters castle - door&#39;s shut and locked
5. There&#39;s a window within jump height, and a rock on the ground
6. Player picks up rock and throws at glass (&quot;throw&quot; taught)
7. … etc.

_(example)_

## _Development_

---

### **Abstract Classes / Components**

1. BasePhysics
    1. BasePlayer
    2. BaseEnemy
    3. BaseObject
2. BaseObstacle
3. BaseInteractable

_(example)_

### **Derived Classes / Component Compositions**

1. BasePlayer
    1. PlayerMain
    2. PlayerUnlockable
2. BaseEnemy
    1. EnemyWolf
    2. EnemyGoblin
    3. EnemyGuard (may drop key)
    4. EnemyGiantRat
    5. EnemyPrisoner
3. BaseObject
    1. ObjectRock (pick-up-able, throwable)
    2. ObjectChest (pick-up-able, throwable, spits gold coins with key)
    3. ObjectGoldCoin (cha-ching!)
    4. ObjectKey (pick-up-able, throwable)
4. BaseObstacle
    1. ObstacleWindow (destroyed with rock)
    2. ObstacleWall
    3. ObstacleGate (watches to see if certain buttons are pressed)
5. BaseInteractable
    1. InteractableButton

_(example)_

## _Graphics_

---

### **Style Attributes**

What kinds of colors will you be using? Do you have a limited palette to work with? A post-processed HSV map/image? Consistency is key for immersion.

What kind of graphic style are you going for? Cartoony? Pixel-y? Cute? How, specifically? Solid, thick outlines with flat hues? Non-black outlines with limited tints/shades? Emphasize smooth curvatures over sharp angles? Describe a set of general rules depicting your style here.

Well-designed feedback, both good (e.g. leveling up) and bad (e.g. being hit), are great for teaching the player how to play through trial and error, instead of scripting a lengthy tutorial. What kind of visual feedback are you going to use to let the player know they&#39;re interacting with something? That they \*can\* interact with something?

### **Graphics Needed**

1. Characters
    1. Human-like
        1. Goblin (idle, walking, throwing)
        2. Guard (idle, walking, stabbing)
        3. Prisoner (walking, running)
    2. Other
        1. Wolf (idle, walking, running)
        2. Giant Rat (idle, scurrying)
2. Blocks
    1. Dirt
    2. Dirt/Grass
    3. Stone Block
    4. Stone Bricks
    5. Tiled Floor
    6. Weathered Stone Block
    7. Weathered Stone Bricks
3. Ambient
    1. Tall Grass
    2. Rodent (idle, scurrying)
    3. Torch
    4. Armored Suit
    5. Chains (matching Weathered Stone Bricks)
    6. Blood stains (matching Weathered Stone Bricks)
4. Other
    1. Chest
    2. Door (matching Stone Bricks)
    3. Gate
    4. Button (matching Weathered Stone Bricks)

_(example)_


## _Sounds/Music_

---

### **Style Attributes**

A great soundtrack often defines the overall ambience and immersion of a game. The main theme of the game are dreams so it just makes sense to have a dreamy soundtrack. The main goal of the in-game music is to create an atmosphere of relaxation, beauty and challenge that evokes feelings of fantasy, fun and excitement.

To make music sound dreamy we will be relying on a bunch of musical components such as slow tempos, Major 7th chords, Lydian mode and whole tone musical scales, repetition, among many others. For the instruments and sounds we will be using mainly synthesizers, which offer flexibility and variety in the creation and customization of sounds; string instruments such as guitar and harp, and soft percussive elements. Pair all of that with a bunch of reverb and you got the perfect music for the game.

To aid the nightmare mechanics of the game, progressive noise and chaos will be introduced to the songs to create a more tense feeling.

Some of our influences and inspiration:
- https://www.youtube.com/watch?v=7aDWVDuRCiA
- https://www.youtube.com/watch?v=M3hFN8UrBPw
- https://www.youtube.com/watch?v=34UutDrXV2Q
- https://www.youtube.com/watch?v=0HbnqjGirFg

Because of our limited time we plan on composing three songs for the user to choose when creating a level, a song for the game maker and all the sound effects of the buttons of the UI, player movement and player interaction with the map.

For the sound effects mentioned previously we will also make use of synthesizers and percussion. The style of the effects should be subtle and should be able to blend in with the atmosphere of the game, with no exaggerated high-pitched noises just to put an example. To blend this elements together we will consider the key, volume and frequencies of the whole musical environment, so that the player can clearly hear the auditory feedback from the level maker and the gameplay over the background music.


### **Sounds Needed**

1. Maker Effects
    1. Grid attachment
    2. Element selection
    3. Element placement
    4. Elements dragged to trash
    5. Element parameter selection
    6. Play button

2. Gameplay Effects
    1. Player footsteps
    2. Player jump
    3. Landing on box
    4. Landing on platform
    5. Grabbing dream catcher
    6. Going though a portal
    7. Appearing in other portal
    8. Box dragging
    9. Box landing on platform
    10. Box landing on other box
    9. Lever/door activation
    10. Going through final portal
    11. Not having dream catcher and trying to go through portal
    12. Increasing nightmare sound

2. Feedback
    1. Effort grunt while moving boxes
    2. Surprised sound when grabbing dream catcher
    3. Scared gasp when reached by nightmare

### **Music Needed**

1. Playful, repetitive &quot;maker&quot; track
2. Dreamy &quot;in-game&quot; track 1
3. Dreamy &quot;in-game&quot; track 2
4. Dreamy &quot;in-game&quot; track 3
5. Exciting, achievement &quot;game stats&quot; track

## _Schedule_

---

_(define the main activities and the expected dates when they should be finished. This is only a reference, and can change as the project is developed)_

1. develop base classes
    1. base entity
        1. base player
        2. base enemy
        3. base block
  2. base app state
        1. game world
        2. menu world
2. develop player and basic block classes
    1. physics / collisions
3. find some smooth controls/physics
4. develop other derived classes
    1. blocks
        1. moving
        2. falling
        3. breaking
        4. cloud
    2. enemies
        1. soldier
        2. rat
        3. etc.
5. design levels
    1. introduce motion/jumping
    2. introduce throwing
    3. mind the pacing, let the player play between lessons
6. design sounds
7. design music

_(example)_
