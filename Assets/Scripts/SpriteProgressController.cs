using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpriteProgressController : MonoBehaviour
{
    [SerializeField] private Transform fillBar;
    //private float _progress = 0;
    [Range(0, 1)] public float progress;

    private Vector2 maxSize;

    // Start is called before the first frame update
    void Start()
    {
        maxSize = GetComponent<SpriteRenderer>().size;
    }

    // Update is called once per frame
    void Update()
    {
        fillBar.localScale = new Vector3(maxSize.x, maxSize.y * progress, 0);
    }
}
