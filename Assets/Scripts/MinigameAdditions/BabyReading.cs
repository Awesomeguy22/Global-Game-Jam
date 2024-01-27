using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class BabyReading : MonoBehaviour
{

    public string[] babyPrompts;
    public string selectedPrompt;
    public string response;
    public GameObject inputBox;
    public TMP_Text TMPText;

    // Start is called before the first frame update
    void Start()
    {
        pickNewPrompt();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void speakAndRespond(string input)
    {
        response = input;

        if (response == selectedPrompt)
        {
            Debug.Log("YAY YOU CAN READ");
        }
        else
        {
            Debug.Log("WTF YOU CAN'T READ");
        }
        //Debug.Log(response);
    }

    public void pickNewPrompt()
    {
        //find random prompt and print it in debug
      selectedPrompt = babyPrompts[UnityEngine.Random.Range(0, babyPrompts.Length)];
        Debug.Log(selectedPrompt);

        //change the text box to have that prompt's text
        TMPText.text = selectedPrompt;

    }
}
