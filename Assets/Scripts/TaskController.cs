using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    BabyController babyController;
    // Start is called before the first frame update
    void Start()
    {
        babyController = gameObject.GetComponent<BabyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
