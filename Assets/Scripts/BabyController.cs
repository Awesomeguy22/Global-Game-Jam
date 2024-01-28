using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BabyController : MonoBehaviour
{

    [SerializeField] float laughterMeter = 0;
    //Counting down from 3 minutes
    public float timer = 180;
    public float currentDifficulty = 10;
    //Difficulty is measured in time before the next task appears
    [SerializeField]float difficultylvl0 = 10;
    [SerializeField]float milstone1 = 25;
    [SerializeField]float difficultylvl1 = 7.5f;

    [SerializeField]float milstone2 = 50;
    [SerializeField]float difficultylvl2 = 6;

    [SerializeField]float milstone3 = 75;
    [SerializeField]float difficultylvl3 = 4f;

    public float milstone4 = 100;

    public bool hasWon = false;
    [SerializeField] float endCountDown = 10f;
    [SerializeField] GameObject[] babyfaces;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        currentDifficulty = difficultylvl0;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0){
            BabyController.Lose("The Parents came home");
            gameObject.SetActive(false);
        } 

        if (hasWon){
            endCountDown -= Time.deltaTime;
        }

        if (endCountDown < 0){
            //Go to win Screen
            SceneManager.LoadScene(1);
        }
    }

    void Win(){
        Debug.Log("You Win!");
        hasWon = true;

        // TODO: shouldn't the babyController be attached to the baby object?
        GameObject.FindGameObjectWithTag("Baby").GetComponent<Animator>().Play("Laugh");
    }

    //Tasks can call this when they expire to trigger a loss
    public static void Lose(string message){
        Debug.Log("You lost");
        Debug.Log(message);

        //Display loss message
        //Go to loss scene
        SceneManager.LoadScene(2);
        //TextMeshPro lossText = GameObject.FindGameObjectWithTag("Finish").GetComponent<TextMeshPro>();
        //lossText.text = "You Lost...\n" + message;
    }

    public void increaseLaughter(int increaseBy){
        laughterMeter += increaseBy;
        if (laughterMeter >= milstone4){
            Win();
        } else if (laughterMeter >= milstone3) {
            currentDifficulty = difficultylvl3;
            babyfaces[3].SetActive(true);
        } else if (laughterMeter >= milstone2) {
            currentDifficulty = difficultylvl2;
            babyfaces[2].SetActive(true);
        } else if (laughterMeter >= milstone1) {
            currentDifficulty = difficultylvl1;
            babyfaces[1].SetActive(true);
        }
    }
}
