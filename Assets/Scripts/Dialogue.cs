using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Scriptable Objects/Dialogue")]
public class Dialogue : ScriptableObject
{
    public enum DialogueType
    {
        Kuba, 
        Item, 
        Rabbit
    };

    public DialogueType dialogueType;

    public string[] dialogueLines;
}
