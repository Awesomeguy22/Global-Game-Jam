using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingMinigame : Minigame
{
    private AudioPitchEstimator pitchEstimator;
    private AudioSource microphone;

    // Start is called before the first frame update
    void Start()
    {
        pitchEstimator = GetComponent<AudioPitchEstimator>();
        microphone = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        print(pitchEstimator.Estimate(microphone));
    }

    public override void ActivateMinigame() {
        throw new System.NotImplementedException();
    }

    public override void StartMinigame() {
        throw new System.NotImplementedException();
    }

    public override void EndMinigame() {
        base.EndMinigame();
        //TODO
    }
}
