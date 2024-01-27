using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] GameObject buttonprompt;
    
    //The minigame object will activate when interacted with
    public GameObject minigame;

    public bool playingMinigame = false;
    bool playerIsNear = false;

    PlayerController playerController;
    void Start(){
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playingMinigame){
            buttonprompt.SetActive(playerIsNear);
        }

        if (playerIsNear && Input.GetKeyDown(KeyCode.E)){
            StartMinigame();
        }

    }

    //minigames will read playingMinigame and wait till a true result is found
    void StartMinigame(){
        Debug.Log("Minigame started!");
        playingMinigame = true;
        playerController.canWalk = false;
    }

    //minigames will call FinishMinigame when they conclude
    public void FinishMinigame(){
        playingMinigame = false;
        playerController.canWalk = true;
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
