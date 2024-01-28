using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyMinigame : Minigame
{
    int inputIndex;

    //the sequence the player must match to complete the baby game
    int[] inputSequence; 

    [SerializeField] int sequenceLength = 4;
    
    [SerializeField] GameObject[] keys;
    [SerializeField] Vector3[] IndicatorPositions;

    int currentIndex;

    [ContextMenu("ActivateMinigame")]
    public override void ActivateMinigame()
    {
        Debug.Log("Baby Task Starting");
        inputSequence = new int[sequenceLength];
        //generate input sequence
        for(int i = 0; i < sequenceLength; i++){
            inputSequence[i] = UnityEngine.Random.Range(0,4);
            Instantiate(keys[inputSequence[i]],IndicatorPositions[i], Quaternion.identity, transform);
        }
        
    }

    public override void EndMinigame()
    {
        throw new System.NotImplementedException();
    }

    public override void StartMinigame()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!_enabled){
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
        }

        KeyCode currentKeyCode = (KeyCode) System.Enum.Parse(typeof(KeyCode), currentChar);
        if(Input.GetKeyDown(currentKeyCode)){
            Debug.Log("Hello");
        }

    }


    
}
