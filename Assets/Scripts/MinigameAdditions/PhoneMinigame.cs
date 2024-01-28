using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;
using UnityEngine.UI;
using TMPro;

namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class IsExternalInit { }
}

public class PhoneMinigame : Minigame
{
    [SerializeField] private AudioClip ringFx;
    public PhoneDialog[] dialogs;
    public Transform buttonContainer;

    private new AudioSource audio;
    private int selectedDialog;
    private GameObject buttonFab;

    // Start is called before the first frame update
    void Awake()
    {
        audio = GetComponent<AudioSource>();
        TaskController.RegisterMinigame(this);
        buttonFab = Resources.Load<GameObject>("Button");
        //ActivateMinigame();
        //StartMinigame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        if (_enabled)
            StartMinigame();
    }

    public override void ActivateMinigame() {
        audio.clip = ringFx;
        audio.Play();
        GetComponent<Animator>().SetBool("isRinging", true);
    }

    public override void StartMinigame() {
        audio.Stop();
        GetComponent<Animator>().SetBool("isRinging", false);
        var dialogIdx = Random.Range(0, dialogs.Length);
        var dialog = dialogs[dialogIdx];
        audio.clip = dialog.audio;
        audio.Play();
        List<GameObject> options = new();
        foreach (var response in dialog.correctResponses) {
            var option = Instantiate(buttonFab);
            option.GetComponent<Button>().onClick.AddListener(EndMinigame);
            option.GetComponentInChildren<TMP_Text>().text = response;
            options.Add(option);
        }
        foreach (var response in dialog.incorrectResponses) {
            var option = Instantiate(buttonFab);
            option.GetComponentInChildren<TMP_Text>().text = response;
            options.Add(option);
        }
        foreach (var option in options) {
            option.transform.parent = buttonContainer;
        }
    }

    public override void EndMinigame() {
        base.EndMinigame();
        audio.Stop();
        foreach (Transform child in buttonContainer) {
            Destroy(child.gameObject);
        }
    }
}
