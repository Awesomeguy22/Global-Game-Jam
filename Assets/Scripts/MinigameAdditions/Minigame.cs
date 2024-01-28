using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    public bool _enabled = false;
    private static GameObject alertFab;

    private GameObject alertObject;


    // Start is called before the first frame update
    void Start()
    {
        alertFab = Resources.Load<GameObject>("Alert");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //return true if minigame can be activated, false otherwise
    [ContextMenu("RequestMinigame")]
    public bool RequestMinigame() {
        if(!_enabled){
            _enabled = true;
            ActivateMinigame();
            var size = new Vector2();
            if (TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer)){
                size = spriteRenderer.size;
            } else {
                size = new Vector2(1,1);
            }
            
            alertObject = Instantiate(alertFab);
            alertObject.transform.position = transform.position + new Vector3(0, transform.localScale.y * size.y, 0);
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
    public virtual void EndMinigame() {
        _enabled = false;
        BabyController babyController = GameObject.FindGameObjectWithTag("GameController").GetComponent<BabyController>();
        babyController.increaseLaughter(1);
        Destroy(alertObject);
    }

}
