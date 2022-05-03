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

A puzzle platformer videogame that offers a "maker" modality. It follows the story of a girl trapped in her dreams and in order to wake up she has to reach the light.  

### **Gameplay**

Con respecto a la narrativa del juego, como se mencionó anteriormente, sigue las aventuras de la protagonista y lo que necesita hacer para despertar, alcanzar la luz. Para poder despertar, ella necesita resolver diferentes puzzles bajo determinado tiempo antes de que la alcance la pesadilla. <br>
El propósito del juego con respecto al usuario es lograr reforzar conceptos como el diseño y la construcción gráfica de un videjuego por medio de la modalidad "maker" del mismo. Dicha modalidad permite que el usuario cree y customice sus propios niveles y la dificultad de ellos. <br>
El obstáculo principal que enfrenta el usuario es idear un nivel lógicamente retador y atractivo de resolver.
El personaje se encuentra con distintos obstáculos ****
armar el nivel que le permita llegar a la meta, otros obstáculos son las cajas, el enemigo y la pesadilla. 

### **Mindset**

Lo que se quiere provocar en el jugador es que sea capaz de resolver puzzles bajo presión (estar cronometrado), sabiendo que hay algo persiguiendolo. Aunque se provoque en el jugador emociones como la ansiedad o los nervios, el usuario necesitará guardar la calma. 
**** agregar la calma del aesthetic

## _Technical_

---

### **Screens**

Below is a breakdown of the screens that make up the "Asleep" video game.
1.	Title Screen
    1.	Game Instructions
    2.	Options (Play or Create)
2.	Maker Mode
    1. Assets 
    2. Grid
3.	Level Selection
4.	Game Mode
5.  Level Passed Screena
5.	End Credits

### **Controls**

In order for the player to have a proper interaction with the video game, the controls that govern it are defined as follows. Mainly, the player interacts with the environment and with the featured objects mentioned in the description below. It is relevant to mention, that for simplicity of the design the described controls are constant and the only option that the player has to interact with the video game.
1.	**Player Movement** 
    1.	Left movement – _left arrow key_ 
    2.	Right movement – _right arrow key_ 
    3.	Jump – _spacebar key_
2.	**Dreamcatcher Capture**
    1. The player passing through the object will trigger its capture.
3.	**Portal Unlocking** 
    1.	Enter portal – _up arrow key_ (only works when the needed dreamcatcher was recently captured) 
4.	**Lever Pulling** <br>
    1.	Activate lever – _E key_
5.	**Box Drag** <br>
    1.	The player moving towards any of the box’s walls will displace it in the same direction of the player's movement.

### **Mechanics**

**Describir seleccion de atributos y todo lo relacionado a los assets* <br>

In this section you will find the rules and mechanics that govern the behavior of the game. Particularly these mechanics are divided into two sections, Gameplay and the Builder.

1. Main Objectives
    - The game's main objective is to reach the light that represents waking up. This is accomplished by the resolution of the various puzzles that make up the level.
    - The maker mode main objective is for the user to design, create and publish a completely functional and logically attractive level.
    
2.	Builder
    1.	_Drag and Drop_: 
    2.	External Element Selection (music)
    3.  Saving and Publishing of the Level
    4.  Play the Level

3.	Gameplay
    1.	Dreamcatcher Capture: accomplished through the register of a trigger event in a collider
    2.	Portal Unlocking: accomplished through tag matching between objects
    3.	Box Drag: accomplished through the physics engine that enables a force to be imparted on an object.
    4.	Player Movement: side to side movement is accomplished through the constant increase or decrease of its position coordinates, while jumping utilizes the physics engine which for the implementation of simulated gravity. 
    5.	Lever Pulling: accomplished through a key input listener accompanied by the action to follow, in this case displacing the sliding door.


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

### **Game Flow**

1. Player starts in forest
2. Pond to the left, must move right
3. To the right is a hill, player jumps to traverse it (&quot;jump&quot; taught)
4. Player encounters castle - door&#39;s shut and locked
5. There&#39;s a window within jump height, and a rock on the ground
6. Player picks up rock and throws at glass (&quot;throw&quot; taught)
7. … etc.


## _Development_

---

### **Abstract Classes / Components**

1. BasePhysics
    1. BasePlayer
    2. BaseEnemy
    3. BaseObject
2. BaseObstacle
3. BaseInteractable


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


## _Graphics_

---

### **Style Attributes**

#### **Color Palette**
For the design of the videogame, we intend to use a range of soft colors that convey tranquility and harmony. For the same reason, the colors will not be very saturated and will tend to be of the pastel type. Particularly to follow the nocturnal plot of the video game, colors such as purple, lilac, lavender and shades of pink that resemble dusk will be used frequently. 

The following is a color palette that encapsulates the characteristic colors of the video game. This palette is flexible and does not include all the colors used in the game. However, all of the colors in the game are consistent in style.

<img src="../GDD/img/AsleepColorPalette.png">

#### **Graphic Style**
The aesthetic sought for the game is known as "dreamy". This on the one hand has a cartoon style, but in a minimalist and elegant way. In order to go deeper into this style, a series of rules that characterize it are described below.

**General Rules**
-	No outlines or black border are used.
-	Smooth curves are emphasized.
-	_Minimalist:_ Details are kept to a minimum (character faces without facial expression, few shadows)
-	_Geometric:_ The outline of objects is very close to simple geometric figures.
- Solid materials are used (few textures, ombre effects, or complex patterns).
-	The overall look is flat and lacks of depth in terms of perspective.


#### **Visual Feedback** FALTA
Well-designed feedback, both good (e.g. leveling up) and bad (e.g. being hit), are great for teaching the player how to play through trial and error, instead of scripting a lengthy tutorial. What kind of visual feedback are you going to use to let the player know they&#39;re interacting with something? That they \*can\* interact with something?

### **Graphics Needed**
1.	**Characters**
    1.	Main Character
        1.	Emily (idle, walking, jumping, pushing, entering, pulling, landing)
    2.	Other (MAYBE ENEMIES)
2.	**Blocks**
    1.	Solid Material Block
    2.	Patterned Material Block
    3.	Solid Material Sliding Door
    5.	Pre-made Grass Platform
    6.	Pre-made Solid Material Platform
    8.	Pre-made Solid Material Platform with roof
3.	**Ambient**
    1.	Fireflies (idle, fluttering)
    1.	Moon
    2.	Stars
    3.	Flower
    4.	Tree
    5.	Bush
    6.	Leaf
    7.	Rocks

4.  **Other**
    1.	Dreamcatcher (4 different colors)
    2.	Portals (4 different colors)
    3.	Lever
    4.	Movable Box
    5.	Magic Light (game’s finish line)


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

1. Definición del videojuego
    1. Establacer Narrativa
    2. Establecer mecánicas y acciones del personaje
    3. Establecer conducta del usuario y el personaje dentro del juego
    4. Elevator Pitch - Junta con OSF
    5. Retroalimentación 
2. Definición de Requerimientos
    1. Funcionales
        1. Diagramas Casos de Uso
        2. Diagrama de Actividades
    2.  No Funcionales 
    3. Retroalimentación y Correcciones - Junta con OSF
3. Definición de Bases Datos 
    1. Diagramas Entidad-Relación
    2. Diagrama de Clases 
    3. Normalización y Correcciones
4. Creación Base de Datos
5. Desarrollo Frontend y Backend 
    1. Frontend 
        1. Creación página web
        2. Estilización página web
        3. Agregar contenido 
        4. Conexión página web - backend
        5. Funcionamiento óptimo de la página
        6. Retroalimentación 
    2. Backend
        1. Conexión con el servidor
        2. Conexión con la Base de Datos
        3. Conexión con el Videojuego
6. Desarrollo del Videojuego 
    1. Diseño de todos los elementos gráficos
    2. Diseño de los sonidos y la música
    3. Creación del bloque unitario
    4. Diseño de las escenas
    5. Programación de mecánicas de los personajes
    6. Programación de mecánicas de los objetos
    7. Programación del primer nivel del videojuego
    8. Programación modalidad "maker"
    9. Integración de modalidad maker y el primer nivel 
    10. Conexión con la Base de Datos
    11. Conexión con la Página Web
    12. Retroalimentación - Junta con OSF
7. Presentación del Proyecto
