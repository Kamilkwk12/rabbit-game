using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Item : MonoBehaviour, IInteractable
{
    private bool isDialogueActive = false, isTyping;
    public ItemData itemData;
    private UIDocument gameUI;
    public VisualTreeAsset dialogueUITemplate;
    private VisualElement dialogueWindow;
    private int dialogueIndex;
    public float typingSpeed; 
    private PlayerMovement player;

    private void Start()
    {
        gameUI = GameObject.FindGameObjectWithTag("GameUI").GetComponent<UIDocument>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        dialogueWindow = dialogueUITemplate.Instantiate().Children().FirstOrDefault();
        dialogueWindow.name = "DialogueWindow";
        dialogueWindow.style.display = DisplayStyle.None;
        gameUI.rootVisualElement.Q<VisualElement>("GameUI").Add(dialogueWindow);

        dialogueWindow = gameUI.rootVisualElement.Q<VisualElement>("DialogueWindow"); //search for created ui element
    }

    public bool CanInteract()
    {
        return !isDialogueActive;

    }

    public void Interact()
    {

        if (isDialogueActive) 
        {
            NextLine();
        } else
        {
            StartDialogue();
        }

    }

    private void StartDialogue()
    {
        isDialogueActive = true;
        dialogueIndex = 0;
        dialogueWindow.Q<Label>("ItemLabel").text = itemData.itemName;
        dialogueWindow.style.display = DisplayStyle.Flex;


        StartCoroutine(TypeLine());
    }

    private void NextLine()
    {
        if (isTyping)
        {
            //skip typin animation and show full line
            StopAllCoroutines();
            dialogueWindow.Q<Label>("DialogueText").text = itemData.dialogueLines[dialogueIndex].ToString();
            isTyping = false;
        } 
        else if (++dialogueIndex < itemData.dialogueLines.Length)
        {
            StartCoroutine(TypeLine());
        } 
        else
        {
            EndDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueWindow.Q<Label>("DialogueText").text = "";

        foreach (char letter in itemData.dialogueLines[dialogueIndex])
        {
            dialogueWindow.Q<Label>("DialogueText").text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
        dialogueWindow.style.display = DisplayStyle.None;
        dialogueWindow.Q<Label>("DialogueText").text = "";
    }
}
