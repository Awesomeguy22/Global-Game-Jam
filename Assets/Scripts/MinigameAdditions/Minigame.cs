using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    protected bool _enabled = false;
    public GameObject alertObj;


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
            var size = GetComponent<SpriteRenderer>().size;
            //print(size);
            Instantiate(alertObj).transform.position = transform.position + new Vector3(0, transform.localScale.y * size.y, 0);
            return true;
        } else {
            return false;
        }
    }

    /// <summary>
    /// When the player is next to the minigame and is locked into completing it
    /// </summary>
    public abstract void StartMinigame();

    /// <summary>
    /// Make the Minigame active so the player must finish it
    /// </summary>
    public abstract void ActivateMinigame();

    //
    public abstract void EndMinigame();

}
