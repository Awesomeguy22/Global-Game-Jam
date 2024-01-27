using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] GameObject buttonprompt;
    
    //The minigame object will activate when interacted with
    public GameObject minigame;

    public bool playingMinigame = true;
    bool playerIsNear = false;


    // Update is called once per frame
    void Update()
    {
        if (!playingMinigame){
            buttonprompt.SetActive(playerIsNear);
        }

        if (playerIsNear && Input.GetKeyDown(KeyCode.E)){
            //playing minigame until the minigame sets this to false
            playingMinigame = true;

        }

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
