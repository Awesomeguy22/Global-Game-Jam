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

    public void RequestMinigame() {
        _enabled = true;
    }

    public abstract void StartMinigame();

    public abstract void EndMinigame();
    
}
