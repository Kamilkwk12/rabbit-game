using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/New Quest")]
public class Quest : ScriptableObject
{
    public int questId;
    public string questName;
    public string questDescription;

    public bool isQuestActive = false;
    public bool isQuestCompleted = false;

    public string[] questConditions;

    public string[] kubaDialogueLines;
}
