using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    public float currentDifficulty = 1;
    float timeTillNextTask = 3;

    int lastTaskGenerated = -1;

    [SerializeField] float miniGameDuration = 10f;

    [SerializeField] float difficultyVariance = 1.0f;

    public static List<Minigame> tasks = new();
    public static List<float> minigameTimers = new();
    BabyController babyController;
    // Start is called before the first frame update
    void Start()
    {
        babyController = gameObject.GetComponent<BabyController>();
    }

    public static void RegisterMinigame(Minigame minigameController) {
        tasks.Add(minigameController);
        minigameTimers.Add(100);
    }

    // Update is called once per frame
    void Update()
    {
        currentDifficulty = babyController.currentDifficulty;

        //time to generate a task
        if (timeTillNextTask < 0 && !babyController.hasWon){
            int taskToGenerate;
            /*
            do{
            //pick a task to activate at random
            taskToGenerate = UnityEngine.Random.Range(0,tasks.Count);
            } while (!tasks[taskToGenerate].RequestMinigame()); 
            */
            //repeat until an inactive task is found

            //Don't generate the same task twice in a row
            do {
                taskToGenerate = UnityEngine.Random.Range(0,tasks.Count);
            } while(taskToGenerate == lastTaskGenerated);
            
            tasks[taskToGenerate].RequestMinigame();
            minigameTimers[taskToGenerate] = miniGameDuration;
            lastTaskGenerated = taskToGenerate;
            Debug.Log("Task #" + taskToGenerate + " Generated");
            
            //Set the time till next task to the difficulty plus some random number for variance
            timeTillNextTask = currentDifficulty + UnityEngine.Random.Range(0,difficultyVariance);
        }

        for (int i = 0; i < tasks.Count; i++){
            if (tasks[i]._enabled){
                //if the minigame is enabled, count it down
                minigameTimers[i] -= Time.deltaTime;
                if (minigameTimers[i] < 0){
                    BabyController.Lose("Lost due to minigame #" + i);
                }
            }


        }

        timeTillNextTask -= Time.deltaTime;
    }
}