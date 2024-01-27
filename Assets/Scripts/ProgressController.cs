using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ProgressController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer fillBar;
    //private float _progress = 0;
    [Range(0, 1)] public float progress;
    //public float Progress {
    //    get {
    //        return _progress;
    //    }
    //    set {
    //        _progress = value;
    //        fillBar.size = new Vector2(maxWidth * _progress, fillBar.size.y);
    //    }
    //}

    private float maxWidth;

    // Start is called before the first frame update
    void Start()
    {
        maxWidth = GetComponent<SpriteRenderer>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        fillBar.size = new Vector2(maxWidth * progress, fillBar.size.y);
    }
}
