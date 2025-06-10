using UnityEngine;

public class CollectKey : InteractionQuestStep
{
    Key key;

    private void Start()
    {
        key = targetObject.GetComponent<Key>();
        GameEventsManager.instance.questEvents.onAdvanceQuest += KeyCollected;

    }
    private void KeyCollected(string id)
    {
        key.PickUpKey();
        QuestManager.instance.questTitleUI.text = "> E S _ A P _ !!!";
        QuestManager.instance.questDescriptionUI.text = "yv- ���+ ����H�\r\nyv- ���+ ����H�\r\nyv- ���+ ����L�\u0005Q~F H�\u0015��- H�\r\n{UF ���  ������3��\u0005�UF ��������L�\u0005!~F H�\u0015z�- H�";

        FinishQuestStep();
    }

    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onAdvanceQuest -= KeyCollected;

    }

}
