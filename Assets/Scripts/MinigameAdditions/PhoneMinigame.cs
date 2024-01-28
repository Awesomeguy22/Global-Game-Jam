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
    [SerializeField] private Animator phoneAnimator;
    public PhoneDialog[] dialogs;
    public Transform buttonContainer;

    private new AudioSource audio;
    private GameObject buttonFab;
    private bool isShowing = false;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Awake()
    {
        audio = GetComponent<AudioSource>();
        TaskController.RegisterMinigame(this);
        buttonFab = Resources.Load<GameObject>("Button");
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    void OnMouseDown() {
        if (_enabled && !isShowing)
            StartMinigame();
    }

    public override void ActivateMinigame() {
        audio.clip = ringFx;
        audio.Play();
        phoneAnimator.SetBool("isRinging", true);
    }

    public override void StartMinigame() {
        isShowing = true;
        audio.Stop();
        phoneAnimator.SetBool("isRinging", false);
        playerAnimator.SetBool("isCalling", true);
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
            option.transform.SetParent(buttonContainer,false);
        }
    }

    public override void EndMinigame() {
        base.EndMinigame();
        isShowing = false;
        audio.Stop();
        playerAnimator.SetBool("isCalling", false);
        foreach (Transform child in buttonContainer) {
            Destroy(child.gameObject);
        }
    }
}
