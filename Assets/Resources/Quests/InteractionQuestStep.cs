using System.Linq;
using UnityEngine;

public class InteractionQuestStep : QuestStep
{
    [Header("Alternative dialogue for quest purposes")]
    [SerializeField] protected Dialogue alternativeDialogue;

    [Header("Add tag to this prefab matching targeted game object")]
    [SerializeField] protected GameObject[] objects;
    protected GameObject targetObject;
    protected Item targetObjectInteraction;

    private void OnEnable()
    {
        objects = GameObject.FindGameObjectsWithTag(gameObject.tag);

        if (objects.Length > 1)
        {
            foreach (GameObject obj in objects) {
                if (obj != gameObject) {
                    targetObject = obj; 
                    break;  
                }
            }
        } else
        {
            targetObject = objects.First();
        }

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
