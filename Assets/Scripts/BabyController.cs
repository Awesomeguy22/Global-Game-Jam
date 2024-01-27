using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyController : MonoBehaviour
{

    [SerializeField] float laughterMeter = 0;
    //Counting down from 3 minutes
    public float timer = 180;
    public float currentDifficulty = 1;
    [SerializeField]float milstone1 = 25;
    [SerializeField]float difficultylvl1 = 2;

    [SerializeField]float milstone2 = 50;
    [SerializeField]float difficultylvl2 = 3;

    [SerializeField]float milstone3 = 75;
    [SerializeField]float difficultylvl3 = 3.5f;

    public float milstone4 = 100;
    // Start is called before the first frame update
    void Start()
    {
        
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
        //change scene
        //laugh.mp3
        //play cutscene
        //display score
    }

    //Tasks can call this when they expire to trigger a loss
    public static void Lose(){

    }

    public void increaseLaughter(int increaseBy){
        laughterMeter += increaseBy;
        if (laughterMeter > milstone4){
            Win();
        } else if (laughterMeter > milstone3) {

        } else if (laughterMeter > milstone2) {

        } else if (laughterMeter > milstone1) {

        }
    }
}
