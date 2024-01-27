using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TvMinigame : MonoBehaviour
{
    Interactable interactable;
    [SerializeField] float timer = 5.0f;
    [SerializeField] float maintainChannelTime = 0.3f;

    [SerializeField] float staticTransitionTime = 0.5f;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 5.0f;

        if (interactable.playingMinigame){
            
        }
    }

    void StartMinigame(){

    }

    void ChangeChannel(){

    }

    
}
