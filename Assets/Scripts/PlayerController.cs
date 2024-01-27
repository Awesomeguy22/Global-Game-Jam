using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// False when in a minigame
    /// </summary>
    bool canWalk = true;

    /// <summary>
    /// Used for flipping the sprite
    /// </summary>
    bool isFacingRight = true;

    /// <summary>
    /// Furthest left the player can go in world coordinates
    /// </summary>
    public float leftBound = -5;

    /// <summary>
    /// Furthest right the player can go in world coordinates
    /// </summary>
    public float rightBound = 5;

    /// <summary>
    /// units per second
    /// </summary>
    public float walkSpeed = 0.5f;

    /// <summary>
    /// Change later when proper animation
    /// </summary>
    [SerializeField] Transform graphics;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        HandleAnimation();
    }

    void Move(){
        float walkDir = Input.GetAxis("Horizontal");
        if (math.abs(walkDir) > 0.1f){
            isFacingRight = walkDir < 0;
        }

        if(!canWalk){
            return;
        }
        //past left wall and trying to walk left
        if(transform.position.x < leftBound && walkDir < 0){
            return;
        }

        //past right wall and trying to walk right
        if(transform.position.x > rightBound && walkDir > 0){
            return;
        }
        transform.Translate(Vector3.right * walkDir * walkSpeed / 50);
    }

    void HandleAnimation(){
        if (isFacingRight) {
            graphics.rotation = Quaternion.Euler(0,0,0); 
        } else {
            graphics.rotation = Quaternion.Euler(0,180,0);
        }
    }
}
