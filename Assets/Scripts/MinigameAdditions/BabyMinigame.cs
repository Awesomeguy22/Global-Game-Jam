using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyMinigame : Minigame
{
    int inputIndex;

    //the sequence the player must match to complete the baby game
    int[] inputSequence; 

    [SerializeField] Animator bottleAnimator;
    Animator baby;

    [SerializeField] int sequenceLength = 4;
    
    [SerializeField] GameObject[] keys;
    [SerializeField] Vector3[] IndicatorPositions;

    GameObject[] indicators;
    int currentIndex = 0;

    AudioSource audioSource;

    [SerializeField] Interactable interactable;

    [ContextMenu("ActivateMinigame")]
    public override void ActivateMinigame()
    {
        Debug.Log("Baby Task Starting");
        _enabled = true;
        
        //generate input sequence
        for(int i = 0; i < sequenceLength; i++){
            inputSequence[i] = UnityEngine.Random.Range(0,4);
            indicators[i] = Instantiate(keys[inputSequence[i]],IndicatorPositions[i], Quaternion.identity, transform);
        }

        currentIndex = 0;
        //show baby bottle
        bottleAnimator.gameObject.SetActive(true);
    }

    public override void EndMinigame()
    {
        base.EndMinigame();
        bottleAnimator.gameObject.SetActive(false);
        baby.SetTrigger("Drinking");
    }

    public override void StartMinigame()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Awake()
    {
        inputSequence = new int[sequenceLength];
        indicators = new GameObject[sequenceLength];
        baby = GameObject.FindGameObjectWithTag("Baby").GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        TaskController.RegisterMinigame(this);

    }

    // Update is called once per frame
    void Update()
    {
        if(!_enabled){
            return;
        }
        //Inputted all characters
        if(currentIndex == sequenceLength){
            EndMinigame();
            return;
        }

        string currentChar = "";
        
        switch(inputSequence[currentIndex]){
            case 0:
            currentChar = "W";
            break;
            case 1:
            currentChar = "A";
            break;
            case 2:
            currentChar = "S";
            break;
            case 3:
            currentChar = "D";
            break;
            default:
            Debug.Log("Oh no");
            break;
        }

        KeyCode currentKeyCode = (KeyCode) System.Enum.Parse(typeof(KeyCode), currentChar);
        if(Input.GetKeyDown(currentKeyCode) && interactable.playerIsNear){
            //Player successfully inputted
            //Debug.Log("you hit the right button");
            Destroy(indicators[currentIndex]);
            currentIndex++;

            bottleAnimator.SetTrigger("Shaking");
            //play sound
            audioSource.Play();
        }

    }


    
}
