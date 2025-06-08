using System;
using System.Collections.Generic;
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

    public List<string> questConditions;

    public string[] kubaDialogueLines;
}
