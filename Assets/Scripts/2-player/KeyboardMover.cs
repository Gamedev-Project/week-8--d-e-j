using UnityEngine;

/**
 * This component allows the player to move by clicking the arrow keys.
 */
public class KeyboardMover : MonoBehaviour {

    protected Vector3 NewPosition() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.A)) {
            return transform.position + Vector3.left;
        } else if (Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D)) {
            return transform.position + Vector3.right;
        } else if (Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.S)) {
            return transform.position + Vector3.down;
        } else if (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W)) {
            return transform.position + Vector3.up;
        } else {
            return transform.position;
        }
    }


    void Update()  {
        transform.position = NewPosition();
    }
}
