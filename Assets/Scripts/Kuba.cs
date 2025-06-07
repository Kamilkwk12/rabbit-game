using System.Collections;
using TMPro;
using UnityEngine;

public class Kuba : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    private DialogueSystem dialogueSystem;

    private void Start()
    {
        dialogueSystem = GetComponent<DialogueSystem>();

        dialogueSystem.StartDialogue(dialogue);
    }
}
