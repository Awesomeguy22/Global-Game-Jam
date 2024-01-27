using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneMinigame : Minigame
{
    // Start is called before the first frame update
    void Start()
    {
        TaskController.RegisterMinigame(this);
        ActivateMinigame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ActivateMinigame() {
        GetComponent<AudioSource>().Play();
        GetComponent<Animator>().SetBool("isRinging", true);
    }

    public override void StartMinigame() {
        GetComponent<AudioSource>().Stop();
    }

    public override void EndMinigame() {
        
    }
}
