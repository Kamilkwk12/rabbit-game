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
        QuestManager.instance.questDescriptionUI.text = "yv- éìü+ ÌÌÌÌH\r\nyv- éÜü+ ÌÌÌÌH\r\nyv- éÌü+ ÌÌÌÌL\u0005Q~F H\u0015²«- H\r\n{UF éöë  ÌÌÌÌÌÌ3À‡\u0005°UF ÃÌÌÌÌÌÌÌL\u0005!~F H\u0015z°- H";

        FinishQuestStep();
    }

    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onAdvanceQuest -= KeyCollected;

    }

}
