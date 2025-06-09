using UnityEngine;

[CreateAssetMenu(fileName = "QuestInfoSO", menuName = "Scriptable Objects/QuestInfoSO")]
public class QuestInfoSO : ScriptableObject
{
    [Header("General")]
    public string id;
    public string questName;
    public string questDescritpion;

    [Header("Quests that are needed to be completed before this quest")]
    public QuestInfoSO[] questPrerequisites;

    [Header("Quest Steps")]
    public GameObject[] questStepsPrefabs;

    private void OnValidate()
    {
        #if UNITY_EDITOR
        id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
}

