using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using Unity.VisualScripting;
using UnityEngine;

public class TvMinigame : Minigame
{
    [SerializeField] float timer = 5.0f;
    bool minigameActivated = false;
    [SerializeField] float maintainChannelTime = 0.3f;

    [SerializeField] float staticTransitionTime = 0.5f;

    [SerializeField] GameObject channelHolder;

    [SerializeField] GameObject TVStatic;

    //.gameobject to disable
    [SerializeField] SpriteRenderer[] channels;

    [SerializeField] int activeChannelIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {

        //getcomponentsinChildren also gets the root object, so I need to filter it out
        channels = channelHolder.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in channels){
            spriteRenderer.gameObject.SetActive(false);
        }
        ActivateMinigame();
        ChangeChannel();
    }

    // Update is called once per frame
    void Update()
    {
        if (minigameActivated){
            timer -= Time.deltaTime;
        }
        
        

    }

    void OnMouseDown(){
        //Debug.Log("Clicked the TV");
        ChangeChannel();
    }

    void ChangeChannel(){
        if (TVStatic.activeSelf){
            TVStatic.SetActive(false);
        }
        channels[activeChannelIndex].gameObject.SetActive(false);
        activeChannelIndex = (activeChannelIndex + 1) % channels.Length;
        channels[activeChannelIndex].gameObject.SetActive(true);
    }



    public override void ActivateMinigame()
    {
        //The player will switch to a random channel to start
        activeChannelIndex = UnityEngine.Random.Range(0,channels.Length);
        foreach (SpriteRenderer channel in channels){
            channel.gameObject.SetActive(false);
        }
        TVStatic.SetActive(false);

    }

    public override void EndMinigame()
    {

    }

    public override void StartMinigame()
    {
        throw new System.NotImplementedException();
    }
}
