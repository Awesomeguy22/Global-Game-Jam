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

    [SerializeField] float difficultyVariance = 1.0f;

    public static List<Minigame> tasks = new();
    BabyController babyController;
    // Start is called before the first frame update
    void Start()
    {
        babyController = gameObject.GetComponent<BabyController>();
    }

    public static void RegisterMinigame(Minigame minigameController) {
        tasks.Add(minigameController);
    }

    // Update is called once per frame
    void Update()
    {
        currentDifficulty = babyController.currentDifficulty;
        if (timeTillNextTask < 0){
            int taskToGenerate;
            do{
            //pick a task to activate at random
            taskToGenerate = UnityEngine.Random.Range(0,tasks.Count);
            } while (!tasks[taskToGenerate].RequestMinigame());
            //repeat until an inactive task is found

            //Set the time till next task to the difficulty plus some random number for variance
            timeTillNextTask = currentDifficulty + UnityEngine.Random.Range(0,difficultyVariance);
        }

        timeTillNextTask -= Time.deltaTime;
    }
}
