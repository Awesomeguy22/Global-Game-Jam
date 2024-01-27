using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;

namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class IsExternalInit { }
}

public class PhoneMinigame : Minigame
{
    [SerializeField] private AudioClip ringFx;
    [SerializeField] private AudioClip[] audioSources;
    // Seperate by commas
    [SerializeField] private string[] correctResponses;
    [SerializeField] private string[] incorrectResponses;

    private new AudioSource audio;
    private int selectedDialog;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        TaskController.RegisterMinigame(this);
        ActivateMinigame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ActivateMinigame() {
        audio.clip = ringFx;
        audio.Play();
        GetComponent<Animator>().SetBool("isRinging", true);
    }

    public override void StartMinigame() {
        audio.Stop();
        GetComponent<Animator>().SetBool("isRinging", false);
        selectedDialog = Random.Range(0, audioSources.Length);
        audio.clip = audioSources[selectedDialog];
        audio.Play();
        GameObject[] options = new GameObject[5];
    }

    public override void EndMinigame() {
        audio.Stop();
    }
}
