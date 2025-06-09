using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueSystem : MonoBehaviour 
{

    [SerializeField] private Canvas dialogueBox;
    [SerializeField] public TextMeshProUGUI dialogueBoxTitle;
    [SerializeField] protected TextMeshProUGUI dialogueContent;

    public bool isDialogueActive;
    protected int dialogueIndex;

    public Dialogue currentDialogue;
    protected bool isTyping;

    [SerializeField] protected float typingSpeed = 0.1f;

    private PlayerMovement player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void StartDialogue(Dialogue dialogueInput)
    {
        currentDialogue = dialogueInput;
         
        isDialogueActive = true;
        dialogueIndex = 0;
        if (dialogueBox) { 
            dialogueBox.enabled = true;
            player.canMove = false;
        }
        StartCoroutine(TypeLine());

    }
     
    protected virtual IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueContent.text = string.Empty;

        foreach (char letter in currentDialogue.dialogueLines[dialogueIndex])
        {
            dialogueContent.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    public virtual void NextLine()
    {
        if (isTyping)
        {
            //skip typin animation and show full line
            StopAllCoroutines();
            dialogueContent.text = currentDialogue.dialogueLines[dialogueIndex].ToString();
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
        if (dialogueBox && dialogueContent) { 
            dialogueBox.enabled = false;
            dialogueContent.text = string.Empty;
            player.canMove = true;
        }
    }
}
