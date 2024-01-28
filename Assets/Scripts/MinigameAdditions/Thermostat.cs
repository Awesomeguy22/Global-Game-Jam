using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermostat : Minigame
{
    [SerializeField] private Animator baby;
    [SerializeField] private Interactable interactable;
    
    // Start is called before the first frame update
    void Start()
    {
        TaskController.RegisterMinigame(this);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown() {
        if (interactable.playerIsNear && _enabled)
            EndMinigame();
    }

    public override void ActivateMinigame() {
        // Random number -1 or 1
        baby.SetInteger("temperature", Random.Range(0, 1) * 2 - 1);
    }

    public override void StartMinigame() {
        throw new System.NotImplementedException();
    }

    public override void EndMinigame() {
        base.EndMinigame();
        baby.SetInteger("temperature", 0);
    }
}
