using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //[SerializeField] GameObject buttonprompt;
    
    //The minigame object will activate when interacted with
    public Minigame minigame;

    public bool playingMinigame = false;
    public bool playerIsNear = false;

    PlayerController playerController;
    void Start(){
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!playingMinigame){
            buttonprompt.SetActive(playerIsNear);
        }

        if (playerIsNear && Input.GetKeyDown(KeyCode.E)){
            Debug.Log("Minigame started!");
            playingMinigame = true;
            playerController.canWalk = false;
            minigame.StartMinigame();
        }
        */

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")) {
            playerIsNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision){

        if (collision.gameObject.tag.Equals("Player")) {
            playerIsNear = false;

        }
    }

}
