using System;
using UnityEngine;

[Serializable]
public class QuestItem
{
    public bool isQuestRelated = false;
    public string questCondition;
    [Tooltip("Id of the related quest")][Range(0, 10)] public int relatedQuest;
}
