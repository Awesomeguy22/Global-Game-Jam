using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Mathematics;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    public float currentDifficulty = 1;
    float timeTillNextTask;

    [SerializeField] float taskTimeInterval = 5.0f;
    [SerializeField] float randomVariance = 1.0f;

    [SerializeField] GameObject[] tasks;
    BabyController babyController;
    // Start is called before the first frame update
    void Start()
    {
        babyController = gameObject.GetComponent<BabyController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentDifficulty = babyController.currentDifficulty;
        if (timeTillNextTask < 0){
            //pick a task to activate at random
            int taskToGenerate = UnityEngine.Random.Range(0,tasks.Length);
            GenerateTask(taskToGenerate);
            //Set the time till next task to a 
            timeTillNextTask = currentDifficulty + UnityEngine.Random.Range(0,randomVariance);
        }

        timeTillNextTask -= Time.deltaTime;
    }

    void GenerateTask(int taskIndex) {
        //fill this in with task specific behaviour
        switch(taskIndex){
            case 1:
            break;


        }
    }
}
