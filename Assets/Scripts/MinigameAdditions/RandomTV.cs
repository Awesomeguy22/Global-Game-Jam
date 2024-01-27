using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.Experimental.Video;
using UnityEngine.UI;
using UnityEngine.Video;


public class RandomTV : MonoBehaviour
{
    public VideoClip displayVideo;
    public VideoClip[] videoList;

    public VideoPlayer videoPlayer;
    public GameObject videoPanel;

    // Start is called before the first frame update
    void Start()
    {
        tvOn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tvOn()
    {

        videoPlayer = videoPanel.GetComponentInChildren<VideoPlayer>();
        videoPlayer.clip = (VideoClip)videoList[UnityEngine.Random.Range(0, videoList.Length)];


    }
}
