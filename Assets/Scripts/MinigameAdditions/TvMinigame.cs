using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using Unity.VisualScripting;
using UnityEngine;

public class TvMinigame : Minigame
{
    bool minigameActivated = false;

    //how long the game will last before you fail
    [SerializeField] float miniGameDuration = 5.0f;
    float failTimer;


    //time the correct channel must be held to win
    [SerializeField] float maintainChannelTime = 0.3f;

    float succeedTimer;
    [SerializeField] float staticTransitionTime = 0.5f;

    [SerializeField] GameObject channelHolder;

    [SerializeField] GameObject desiredChannelHolder;

    [SerializeField] GameObject TVStatic;

    //.gameobject to disable
    [SerializeField] SpriteRenderer[] channels;

    [SerializeField] SpriteRenderer[] desiredChannels;
    

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

        desiredChannels = desiredChannelHolder.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in desiredChannels){
            spriteRenderer.gameObject.SetActive(false);
        }
        
        TVStatic.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (minigameActivated) {
            failTimer -= Time.deltaTime;
        }
        
        if (failTimer < 0){
            //Trigger a loss
            BabyController.Lose("Lost due to tv minigame");
        }

        if (succeedTimer < 0){
            EndMinigame();
        }

        //if on the right channel
        if (desiredChannelIndex == activeChannelIndex) {
            succeedTimer -= Time.deltaTime;
            
        } else{
            //reset the timer
            succeedTimer = maintainChannelTime;
        }

    }

    void OnMouseDown(){
        //Debug.Log("Clicked the TV");
        if(TVStatic.activeSelf){
            ChangeChannel();
            TVStatic.SetActive(false);
        } else {
            TVStatic.SetActive(true);

        }
    }

    void ChangeChannel(){
        channels[activeChannelIndex].gameObject.SetActive(false);
        activeChannelIndex = (activeChannelIndex + 1) % channels.Length;
        channels[activeChannelIndex].gameObject.SetActive(true);
    }



    public override void ActivateMinigame()
    {
        minigameActivated = true;
        failTimer = miniGameDuration;
        //The player will switch to a random channel to start
        activeChannelIndex = Random.Range(0,channels.Length);

        foreach (SpriteRenderer channel in channels){
            channel.gameObject.SetActive(false);
        }

        desiredChannelIndex = Random.Range(0,channels.Length);
        desiredChannels[desiredChannelIndex].gameObject.SetActive(true);

        TVStatic.SetActive(false);

    }

    public override void EndMinigame()
    {
        Debug.Log("Tv minigame Complete");
        minigameActivated = false;
    }

    public override void StartMinigame()
    {

    }
}
