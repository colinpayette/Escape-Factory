using UnityEngine;
using UnityEngine.Networking;

// cpayette: For changing player facing animations
enum Direction8Way { Up, UpRight, Right, DownRight, Down, DownLeft, Left, UpLeft };

public class PlayerController : NetworkBehaviour
{
    const float PLAYER_ROTATION_SPEED = 150.0f;
    const float PLAYER_SPEED = 5.0f;

    // cpayette: For handling animation based on player movement and direction
    Animator playerAnimator;
    Direction8Way playerDirection = Direction8Way.Down;
    // cpayette: end

    public override void OnStartLocalPlayer()
    {
        // Set the cameras target to the local player object
        GameObject camera = GameObject.Find("Main Camera");
        CameraController cc = (CameraController)camera.GetComponent(typeof(CameraController));
        cc.SetTarget(gameObject);

        GetComponent<SpriteRenderer>().material.color = Color.white;
    }

    void Start ()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(isLocalPlayer)
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * PLAYER_SPEED;
            var y = Input.GetAxis("Vertical") * Time.deltaTime * PLAYER_SPEED;

            transform.Translate(x, y, 0);

            // cpayette: Animation and movement
            bool bDirUp    = (Input.GetKey("w") || Input.GetKey("up"));
            bool bDirRight = (Input.GetKey("d") || Input.GetKey("right"));
            bool bDirDown  = (Input.GetKey("s") || Input.GetKey("down"));
            bool bDirLeft  = (Input.GetKey("a") || Input.GetKey("left"));
            bool bMoving   = (bDirUp || bDirRight || bDirDown || bDirLeft);

            playerAnimator.SetBool("Moving", bMoving);
            

            // cpayette: end


        }
	}
}
