using System;

/**
 * This class is used to generate a random "cave" map.
 * The map is generated as a two-dimensional array of ints, where "0" denotes floor and "1" denotes wall.
 * Initially, the boundaries of the cave are set to "wall", and the inner cells are set at random.
 * Then, a cellular automaton is run in order to smooth out the cave.
 * 
 * Based on Unity tutorial https://www.youtube.com/watch?v=v7yyZZjF1z4 
 * Code by Habrador: https://github.com/Habrador/Unity-Programming-Patterns/blob/master/Assets/Patterns/7.%20Double%20Buffer/Cave/GameController.cs
 * Using a double-buffer technique explained here: https://github.com/Habrador/Unity-Programming-Patterns#7-double-buffer
 * 
 * Adapted by: Erel Segal-Halevi
 * Since: 2020-12
 */
public class CaveGenerator {
    //private double GrassField=0.10;
    //Used to init the cellular automata by spreading random dots on a grid,
    //and from these dots we will generate caves.
    //The higher the fill percentage, the smaller the caves.
    protected float randomFillPercent;

    //The height and length of the grid
    protected int gridSize;

    //The double buffer
    private int[,] bufferOld;
    private int[,] bufferNew;


    private Random random;

    public CaveGenerator(float randomFillPercent, int gridSize) {
        this.randomFillPercent = randomFillPercent;
        this.gridSize = gridSize;

        this.bufferOld = new int[gridSize, gridSize];
        this.bufferNew = new int[gridSize, gridSize];

        random = new Random();
    }

    public int[,] GetMap() {
        return bufferOld;
    }



    /**
     * Generate a random map.
     * The map is not smoothed; call Smooth several times in order to smooth it.
     */
    public void RandomizeMap()  {
        //Init the old values so we can calculate the new values
        for (int x = 0; x < gridSize; x++) {
            for (int y = 0; y < gridSize; y++) {
                if (x == 0 || x == gridSize - 1 || y == 0 || y == gridSize - 1) {
                    //We dont want holes in our walls, so the border is always a wall
                    bufferOld[x, y] = 1;
                } else {
                    //Random walls and caves
                    double rand = random.NextDouble();
                    if (rand < randomFillPercent) {
                        bufferOld[x, y] = 0; 
                    }
                    else if (rand < (2*randomFillPercent)) {
                        bufferOld[x, y] = 2; 
                    }
                    else {
                    bufferOld[x, y] = 1; 
                    }
                }
            }
        }
    }


    /**
     * Generate caves by smoothing the data
     * Remember to always put the new results in bufferNew and use bufferOld to do the calculations
     */
    public void SmoothMap()   {
        for (int x = 0; x < gridSize; x++) {
            for (int y = 0; y < gridSize; y++) {
                //Border is always wall
                if (x == 0 || x == gridSize - 1 || y == 0 || y == gridSize - 1) {
                    bufferNew[x, y] = 1;
                    continue;
                }

                //Uses bufferOld to get the wall count
                int [,] surroundingWalls = GetSurroundingWallCount(x, y);

                //Use some smoothing rules to generate caves

                if (surroundingWalls[1,0] > 4) 
                {
                    bufferNew[x, y] = 0;
                } 
                else if (surroundingWalls[1,0] == 4) 
                {
                    bufferNew[x, y] = bufferOld[x, y];
                } 
                else if (surroundingWalls[1,1] > 4)
                {
                    bufferNew[x, y] = 1;
                }
                else if (surroundingWalls[1,1] == 4)
                {
                    bufferNew[x, y] = bufferOld[x, y];
                }
                else if (surroundingWalls[1,2] > 4)
                {
                    bufferNew[x, y] = 2;
                }
                else if (surroundingWalls[1,2] == 4)
                {
                    bufferNew[x, y] = bufferOld[x, y];
                }
            }
        }

        //Swap the pointers to the buffers
        (bufferOld, bufferNew) = (bufferNew, bufferOld);
    }



    //Given a cell, how many of the 8 surrounding cells are walls?
    private int[,] GetSurroundingWallCount(int cellX, int cellY) {
        int [,]TileCount = new int[,] { {0,1,2}, {0,0,0} }; 
        for (int neighborX = cellX - 1; neighborX <= cellX + 1; neighborX ++) {
            for (int neighborY = cellY - 1; neighborY <= cellY + 1; neighborY++) {
                //We dont need to care about being outside of the grid because we are never looking at the border
                //This is the cell itself and no neighbor!
                if (neighborX == cellX && neighborY == cellY) {
                    continue;
                }
                TileCount[1,bufferOld[neighborX, neighborY]]+=1;
            }
        }
        //Debug.Log(TileCount);
        return TileCount;
    }
}
