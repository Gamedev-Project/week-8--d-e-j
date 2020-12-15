using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Carve : MonoBehaviour
{
    [Tooltip("the script that includes the alloweded Tiles to move")]
    public AllowedTiles allowedTiles ;
    [Tooltip("The Tile That we will regenrate after carving the the previous tile")]
    public TileBase ChangeToMiddle;
    [Tooltip("The Tile That we will regenrate after carving the the previous tile")]
    public TileBase ChangeToFinal;
    [Tooltip("the Tile Playground")]
    public Tilemap tileMap;
    [Tooltip("The time in floats that our players need to hold the Spacebar Button to crave the mountain")]
    public float CraveTime = 0.5f;
    [Tooltip("the realistic effect that will occur when we will crave the mountain.")]
    public Transform CarvingEffect;
    [Tooltip("son-object of the Player, this object will help up get the tile which we moving forward to.")]
    public Transform gameObject;
    [Tooltip("This string will help us get the location of the tile we moving to for the ParticleSystem to work")]
    string ParticalSystemMove;
    [Tooltip("this object will help us with Destroing the ParticalSystem after it will disapire.")]
    Transform Effect;

    
    //in update, if pressed jump --> moving to the key pressed position. also enable WASD movement and Update "CarvingEffect" Direction
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            Vector3 newTilePos = transform.position;
            if (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W))
            {
                newTilePos += Vector3.up;
                ParticalSystemMove="Up";
            }

            if (Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.S))
            {
                newTilePos += Vector3.down;
                ParticalSystemMove="Down";
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.A))
            {
                newTilePos += Vector3.left;
                ParticalSystemMove="Left";
            }

            if (Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D))
            {
              newTilePos += Vector3.right;
              ParticalSystemMove="Right";
            }
            StartCoroutine(CheckTileAndCarve(newTilePos)); 
        }
    }

    // Checks for the Tile in the moving Direction and changing it to "ChangeToMiddle" Tile and then to "ChangeToFinal" .
    IEnumerator CheckTileAndCarve(Vector3 tile)
    {
        Vector3Int FutureMovePos = tileMap.WorldToCell(tile);
        yield return new WaitForSeconds(CraveTime);
        if (!allowedTiles.Contain(tileMap.GetTile(FutureMovePos)))
        {
            tileMap.SetTile(tileMap.WorldToCell(tile), ChangeToMiddle);
            MakeBoom();
            yield return new WaitForSeconds(CraveTime);
            tileMap.SetTile(tileMap.WorldToCell(tile), ChangeToFinal);
            MakeBoom();
        }
    }

    //Func that helps to get the moving Direction of our player to make the realistic "CarvingEffect" posibile.
    public void MakeBoom(){
            switch(ParticalSystemMove){
                case "Up":
                    Effect=Instantiate(CarvingEffect, gameObject.transform.position+Vector3.up, gameObject.transform.rotation);
                    break;
                case "Down":
                    Effect=Instantiate(CarvingEffect, gameObject.transform.position+Vector3.down, gameObject.transform.rotation);
                    break;
                case "Left":
                    Effect=Instantiate(CarvingEffect, gameObject.transform.position+Vector3.left, gameObject.transform.rotation);
                    break;
                case "Right":
                    Effect=Instantiate(CarvingEffect, gameObject.transform.position+ Vector3.right, gameObject.transform.rotation);
                    break;
            }
            Destroy(Effect.gameObject,1.5f);
    }
}