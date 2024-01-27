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

    [SerializeField] float randomVariance = 1.0f;

    public static List<Minigame> tasks = new();
    BabyController babyController;
    // Start is called before the first frame update
    void Start()
    {
        babyController = gameObject.GetComponent<BabyController>();
    }

    static void AddTask(Minigame minigameController) {
        tasks.Add(minigameController);
    }

    // Update is called once per frame
    void Update()
    {
        currentDifficulty = babyController.currentDifficulty;
        if (timeTillNextTask < 0){
            //pick a task to activate at random
            int taskToGenerate = UnityEngine.Random.Range(0,tasks.Count);
            tasks[taskToGenerate].RequestMinigame();
            //Set the time till next task to a 
            timeTillNextTask = currentDifficulty + UnityEngine.Random.Range(0,randomVariance);
        }

        timeTillNextTask -= Time.deltaTime;
    }
}
