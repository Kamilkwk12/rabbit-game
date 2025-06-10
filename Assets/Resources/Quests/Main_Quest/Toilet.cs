using UnityEngine;

public class Toilet : InteractionQuestStep
{

    [SerializeField] private DesktopIcon[] desktopIcons;

    private Terminal terminal;

    private void Start()
    {
        terminal = GameObject.FindGameObjectWithTag("Terminal").GetComponent<Terminal>();

        GameEventsManager.instance.questEvents.onAdvanceQuest += AddIcons;
    }

    private void AddIcons(string id)
    {
        foreach (DesktopIcon icon in desktopIcons)
        {
            terminal.AddIcon(icon);
        }
            FinishQuestStep();
    }

    private void OnDestroy()
    {
        GameEventsManager.instance.questEvents.onAdvanceQuest -= AddIcons;

    }
}
