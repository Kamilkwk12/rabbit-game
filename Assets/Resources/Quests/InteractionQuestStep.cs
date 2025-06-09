using UnityEngine;

public class InteractionQuestStep : QuestStep
{
    [Header("Alternative dialogue for quest purposes")]
    [SerializeField] protected Dialogue alternativeDialogue;

    [Header("Add tag to this prefab matching targeted game object")]
    [SerializeField] protected GameObject targetObject;
    protected Item targetObjectInteraction;

    private void OnEnable()
    {
        targetObject = GameObject.FindGameObjectWithTag(gameObject.tag);
        targetObjectInteraction = targetObject.GetComponent<Item>();
        Item.onInteraction += Interact;
    }

    private void OnDisable()
    {
        Item.onInteraction -= Interact;
    }

    protected void Interact()
    {
        if (GetPlayerInteractionDetector().interactableGameObject == targetObject)
        {
            if (alternativeDialogue)
            {
                targetObjectInteraction.dialogue = alternativeDialogue;
            }
            
            FinishQuestStep();
        }
    }

    protected InteractionDetector GetPlayerInteractionDetector()
    {
        return GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<InteractionDetector>();
    }
}
