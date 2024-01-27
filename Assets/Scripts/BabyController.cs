using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyController : MonoBehaviour
{

    [SerializeField] float laughterMeter = 0;
    //Counting down from 3 minutes
    public float timer = 180;
    public float currentDifficulty = 1;
    //Difficulty is measured in time before the next task appears
    [SerializeField]float difficultylvl0 = 10;
    [SerializeField]float milstone1 = 25;
    [SerializeField]float difficultylvl1 = 7.5f;

    [SerializeField]float milstone2 = 50;
    [SerializeField]float difficultylvl2 = 6;

    [SerializeField]float milstone3 = 75;
    [SerializeField]float difficultylvl3 = 4f;

    public float milstone4 = 100;
    // Start is called before the first frame update
    void Start()
    {
        currentDifficulty = difficultylvl0;
    }

    // Update is called once per frame
    void Update()
    {


        timer -= Time.deltaTime;
        if (timer < 0){
            BabyController.Lose();
        }
    }

    void Win(){
        Debug.Log("You Win!");
        //change scene
        //laugh.mp3
        //play cutscene
        //display score
    }

    //Tasks can call this when they expire to trigger a loss
    public static void Lose(){
        Debug.Log("You lost");
        //Display loss message
        //restart current scene
    }

    public void increaseLaughter(int increaseBy){
        laughterMeter += increaseBy;
        if (laughterMeter > milstone4){
            Win();
        } else if (laughterMeter > milstone3) {
            currentDifficulty = difficultylvl3;
        } else if (laughterMeter > milstone2) {
            currentDifficulty = difficultylvl2;

        } else if (laughterMeter > milstone1) {
            currentDifficulty = difficultylvl1;
        }
    }
}
