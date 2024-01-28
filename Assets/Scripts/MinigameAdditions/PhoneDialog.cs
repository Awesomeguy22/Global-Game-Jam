using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PhoneDialog", order = 1)]
public class PhoneDialog : ScriptableObject
{
    public AudioClip audio;

    public string[] correctResponses;
    public string[] incorrectResponses;
}