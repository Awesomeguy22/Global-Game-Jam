using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingMinigame : Minigame
{
    [SerializeField] private GameObject ui;
    [SerializeField] private PitchVisualizer controller;

    private string targetNote;

    // Start is called before the first frame update
    void Start()
    {
        TaskController.RegisterMinigame(this);
    }

    private void Update() {
        if (_enabled) {
            if (controller.CurrentNote == targetNote) {
                EndMinigame();
            }
        }
    }

    public override void ActivateMinigame() {
        // No-op
    }

    private void OnMouseDown() {
        if (_enabled)
            StartMinigame();
    }

    public override void StartMinigame() {
        print("starting sound minigame...");
        ui.SetActive(true);
        controller.Begin();
        targetNote = PitchVisualizer.names[Random.Range(0, PitchVisualizer.names.Length)];
        print("target: " + targetNote);
    }

    public override void EndMinigame() {
        base.EndMinigame();
        ui.SetActive(false);
        controller.End();
    }
}
