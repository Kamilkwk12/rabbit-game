using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{

    [SerializeField] private Canvas dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueTitle;
    [SerializeField] private TextMeshProUGUI dialogueText;

    public bool isDialogueActive;
    private int dialogueIndex;

    public Dialogue currentDialogue;
    private bool isTyping;

    [SerializeField] private float typingSpeed = 0.1f;


    public void StartDialogue(Dialogue dialogueInput)
    {
        currentDialogue = dialogueInput;
        isDialogueActive = true;
        dialogueIndex = 0;
        dialogueBox.enabled = true;

        StartCoroutine(TypeLine());
    }
     
    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.text = string.Empty;

        foreach (char letter in currentDialogue.dialogueLines[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    public void NextLine()
    {
        if (isTyping)
        {
            //skip typin animation and show full line
            StopAllCoroutines();
            dialogueText.text = currentDialogue.dialogueLines[dialogueIndex].ToString();
            isTyping = false;
        }
        else if (++dialogueIndex < currentDialogue.dialogueLines.Length)
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    

    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
        dialogueBox.enabled = false;
        dialogueText.text = string.Empty;
    }
}
