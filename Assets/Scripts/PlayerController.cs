using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// False when in a minigame
    /// </summary>
    public bool canWalk = true;

    /// <summary>
    /// Used for flipping the sprite
    /// </summary>
    bool isFacingRight = true;

    /// <summary>
    /// Furthest left the player can go in world coordinates
    /// </summary>
    [SerializeField] float leftBound = -5;

    /// <summary>
    /// Furthest right the player can go in world coordinates
    /// </summary>
    [SerializeField] float rightBound = 5;

    /// <summary>
    /// units per second
    /// </summary>
    public float walkSpeed = 0.5f;

    [SerializeField] GameObject idlePose;
    [SerializeField] GameObject runningPose;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Fixed update is called 50 times per second
    void FixedUpdate()
    {
        if (canWalk){
            Move();

            HandleAnimation();
        }

    }

    void Move(){
        float walkDir = Input.GetAxis("Horizontal");
        //if walking
        if (math.abs(walkDir) > 0.1f){
            // if walking dir is negative, we are walking right
            isFacingRight = walkDir < 0;
            idlePose.SetActive(false);
            runningPose.SetActive(true);
        } else {
            idlePose.SetActive(true);
            runningPose.SetActive(false);
        }

        //past left wall and trying to walk left
        if(transform.position.x < leftBound && walkDir < 0){
            return;
        }

        //past right wall and trying to walk right
        if(transform.position.x > rightBound && walkDir > 0){
            return;
        }

        //divide by 50 for 50 frames per second
        transform.Translate(Vector3.right * walkDir * walkSpeed / 50);
    }

    void HandleAnimation(){
        if (isFacingRight) {
            runningPose.transform.rotation = Quaternion.Euler(0,180,0); 
        } else {
            runningPose.transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
}
