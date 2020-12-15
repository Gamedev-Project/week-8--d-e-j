# tilemap-pathfinding


![](https://i.imgur.com/OZA30lH.gif)   

## [Game link !](https://aviniv.itch.io/tilemap-path-finding)  
The homework assigminet which we follows is [right here!](https://github.com/gamedev-at-ariel/gamedev-5781/blob/master/08-unity-tilemap-algorithms/homework.pdf)

we've added a minimap on the top right of the screen to create a better user experience.
This way the player will be able to see his entire screen and know where he should go according to the many mountains along the way.

### q_4
In this section, we were required to change the given game so that at the beginning of the stage when creating the automatic map, three types of tiles will be created and not just two. In addition, we were required that the map that would be created would make sense with similar tiles that are close to each other.  
To do this we changed the code The code of:
[CaveGenerator](https://github.com/Gamedev-Project/week-8--d-e-j/blob/main/Assets/Scenes/4-generation/4-generation/CaveGenerator.cs)   

[TilemapCaveGenerator](https://github.com/Gamedev-Project/week-8--d-e-j/blob/main/Assets/Scenes/4-generation/4-generation/TilemapCaveGenerator.cs) 

We added to "TilemapCaveGenerator" FOREST TILE to the map, and now instead of dividing the percentage of TIL by half at the beginning of the phase creation we have now divided by three meaning 33.3% percent per part.
In addition, in order to maintain the position of the TILES so that they will logically close to each other we created a 2X3 matrix so that in the first row there are the types of TILE numbered from 1 to 3, and in the second row the amount of similar TILS around it. And thus we can preserve the function and algorithm that was in the creation of the game.

![](https://i.imgur.com/Kc8HvD5.png)   

In the picture we can see that we also put in forest tiles,rocks and grass.


### q_5
In this section, we were asked to add to the main player the option to carve his way in TILES that he is unable to pass.
To do this we created a script called [Carve ](https://github.com/Gamedev-Project/week-8--d-e-j/blob/main/Assets/Scenes/4-generation/4-generation/CaveGenerator.cs) .  
In this sarcipt, the player knows on which tile he cam move, and when he can not move, he must press the "space" key continuously and while moving in the direction he wants to move.
Displacement: One of the additional changes we have made is that the player will be able to move not only with the arrows but also with the W S A D keys to create a more comfortable gaming experience for some users.
Quarrying: In the quarrying process we added a PARTICAL SYSTEM to create a real quarrying effect, so that small sparks are created with this help.
In addition, when quarrying, the rock changes its shape to a more broken stone, there is again an effect of sparks and then the rock disappears. This is to give a real and beautiful feeling of quality quarrying.

![](https://i.imgur.com/QzcLuVo.png)  




### q_5
In this section, we were asked to select a game from a given site and draw with tiles some stage from that game.
A link to the original game is  [HERE]( https://www.myabandonware.com/game/bubble-ghost-ey).  

We selected this level:
![](https://i.imgur.com/dYJdmaI.png) 

link to the tiles is [here](https://github.com/Gamedev-Project/week-8--d-e-j/tree/main/Assets/Spritesheets)






 
