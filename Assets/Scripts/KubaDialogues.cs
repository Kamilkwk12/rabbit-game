using System.Collections;
using TMPro;
using UnityEngine;

public class KubaDialogues : DialogueSystem
{
    public Dialogue dialogue;
    
    private void Start()
    {
        StartDialogue(dialogue);
    }
    protected override IEnumerator TypeLine()
    {
        dialogueContent.text = string.Empty;

        foreach (char letter in currentDialogue.dialogueLines[dialogueIndex])
        {
            dialogueContent.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
        NextLine();
    }
    public override void NextLine()
    {
        if (++dialogueIndex < currentDialogue.dialogueLines.Length)
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }
}
