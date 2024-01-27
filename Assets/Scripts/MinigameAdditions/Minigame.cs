using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    protected bool _enabled = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //return true if minigame can be activated, false otherwise
    public bool RequestMinigame() {
        if(!_enabled){
            _enabled = true;
            ActivateMinigame();
            return true;
        } else {
            return false;
        }
    }

    //When the player is next to the minigame and is locked into completing it
    public abstract void StartMinigame();

    //Make the Minigame active so the player must finish it
    public abstract void ActivateMinigame();

    //
    public abstract void EndMinigame();

}
