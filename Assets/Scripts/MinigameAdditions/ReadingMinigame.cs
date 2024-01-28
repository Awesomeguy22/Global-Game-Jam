using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadingMinigame : Minigame
{
    [SerializeField] string[] prompts;
    int promptIndex;
    string prompt;
    string currentChar;
    [SerializeField]int inputIndex;

    Animator baby;

    [SerializeField] Interactable interactable;

    
    [SerializeField] GameObject[] promptOneIndicators;
    [SerializeField] GameObject[] promptTwoIndicators;
    [SerializeField] GameObject[] promptThreeIndicators;



    public override void ActivateMinigame()
    {
        inputIndex = 0;
        currentChar = "";
        promptIndex = Random.Range(0,prompts.Length);
        switch(promptIndex){
            case 0:
            foreach (GameObject indicator in promptOneIndicators)
            {
                indicator.SetActive(true);
            }
            break;
            case 1:
            foreach (GameObject indicator in promptTwoIndicators)
            {
                indicator.SetActive(true);
            }
            break;
            case 2:
            foreach (GameObject indicator in promptThreeIndicators)
            {
                indicator.SetActive(true);
            }
            break;
        }


    }

    public override void StartMinigame()
    {
        throw new System.NotImplementedException();
    }

    public override void EndMinigame()
    {
        inputIndex = 0;
        base.EndMinigame();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_enabled){
            return;
        }

        currentChar = prompts[promptIndex][inputIndex].ToString();
        KeyCode currentKeyCode = (KeyCode) System.Enum.Parse(typeof(KeyCode), currentChar);
        if(Input.GetKeyDown(currentKeyCode) && interactable.playerIsNear){
            //Player successfully inputted
            //Debug.Log("you hit the right button");
            if (promptIndex == 0){
                promptOneIndicators[inputIndex].SetActive(false);
                
                if (inputIndex == promptOneIndicators.Length - 1){
                    EndMinigame();
                    return;
                }
            } else if (promptIndex == 1){
                promptTwoIndicators[inputIndex].SetActive(false);
                if (inputIndex == promptTwoIndicators.Length - 1){
                    EndMinigame();
                    return;
                }
            } else if (promptIndex == 2){
                promptThreeIndicators[inputIndex].SetActive(false);
                if (inputIndex == promptThreeIndicators.Length - 1){
                    EndMinigame();
                    return;
                }
            }
            
            inputIndex++;
            
        }
        
    }
}
