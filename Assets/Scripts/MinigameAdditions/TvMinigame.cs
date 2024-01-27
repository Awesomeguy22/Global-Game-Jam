using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using Unity.VisualScripting;
using UnityEngine;

public class TvMinigame : Minigame
{
    
    //bool _enabled = false;

    //how long the game will last before you fail
    [SerializeField] float miniGameDuration = 10f;
    [SerializeField]float failTimer;


    //time the correct channel must be held to win
    [SerializeField] float maintainChannelTime = 1.0f;

    [SerializeField]float succeedTimer;
    //[SerializeField] float staticTransitionTime = 0.5f;

    [SerializeField] GameObject channelHolder;

    [SerializeField] GameObject desiredChannelHolder;

    [SerializeField] GameObject TVStatic;

    //.gameobject to disable
    SpriteRenderer[] channels;

    SpriteRenderer[] desiredChannels;
    
    int activeChannelIndex = 0;
    int desiredChannelIndex;


    // Start is called before the first frame update
    void Awake()
    {

        //getcomponentsinChildren also gets the root object, so I need to filter it out
        channels = channelHolder.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in channels){
            spriteRenderer.gameObject.SetActive(false);
        }
        channels[0].gameObject.SetActive(true);

        desiredChannels = desiredChannelHolder.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in desiredChannels){
            spriteRenderer.gameObject.SetActive(false);
            
        }
        
        //TVStatic.SetActive(true);

        //For debugging purposes activate tv at the start
        //ActivateMinigame();
    }

    // Update is called once per frame
    void Update()
    {
        //only run minigame logic when it is active
        if (!_enabled) {
           return;
        }

        failTimer -= Time.deltaTime;
        
        if (failTimer < 0){
            //Trigger a loss
            BabyController.Lose("Lost due to tv minigame");
        }

        if (succeedTimer < 0){
            EndMinigame();
        }

        //if on the right channel
        if (desiredChannelIndex == activeChannelIndex && !TVStatic.activeSelf) {
            succeedTimer -= Time.deltaTime;
            
        } else{
            //reset the timer
            succeedTimer = maintainChannelTime;
        }

    }

    void OnMouseDown(){
        //TODO
        //change the player sprite
        
        if(TVStatic.activeSelf){
            ChangeChannel();
            TVStatic.SetActive(false);
        } else {
            TVStatic.SetActive(true);
            channels[activeChannelIndex].gameObject.SetActive(false);

        }
    }

    void ChangeChannel(){
        
        activeChannelIndex = (activeChannelIndex + 1) % channels.Length;
        channels[activeChannelIndex].gameObject.SetActive(true);
    }

    [ContextMenu("ActivateMinigame")]
    public override void ActivateMinigame()
    {
        _enabled = true;
        //reset both timers
        failTimer = miniGameDuration;
        succeedTimer = maintainChannelTime;

        //The player will switch to a random channel to start
        activeChannelIndex = Random.Range(0,channels.Length);

        foreach (SpriteRenderer channel in channels){
            channel.gameObject.SetActive(false);
        }
        channels[activeChannelIndex].gameObject.SetActive(true);
        do {
            desiredChannelIndex = Random.Range(0,channels.Length);
        } while (desiredChannelIndex == activeChannelIndex);
        //if the target is the current channel, regenerate a number
        
        desiredChannels[desiredChannelIndex].gameObject.SetActive(true);

        TVStatic.SetActive(true);

    }

    public override void EndMinigame()
    {
        Debug.Log("Tv minigame Complete");
        _enabled = false;
        desiredChannels[desiredChannelIndex].gameObject.SetActive(false);

    }

    public override void StartMinigame()
    {

    }

    

}
