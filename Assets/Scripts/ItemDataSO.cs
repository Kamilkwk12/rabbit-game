using UnityEngine;

[CreateAssetMenu(fileName = "InteractionDialogue", menuName = "Scriptable Objects/InteractionDialogue")]
public class ItemDataSO : ScriptableObject
{
    public string itemName; 
    public string itemDescription;
    public string[] dialogueLines;
}
