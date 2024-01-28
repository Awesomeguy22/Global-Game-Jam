using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyMinigame : Minigame
{
    int inputIndex;
    String[] inputSequence; 

    [SerializeField] GameObject[] keys;
    public override void ActivateMinigame()
    {
        //generate input sequence
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
        
    }
}
