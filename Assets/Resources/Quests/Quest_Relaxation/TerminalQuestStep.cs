using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TerminalQuestStep : QuestStep
{
    [SerializeField] private Terminal terminal;
    private Item tv; 
    private bool wasTvStarted = false;
    private bool isGamePlayed = false;

    [SerializeField] private Dialogue tvGameDialogue;
    private void OnEnable()
    {
        tv = GameObject.FindGameObjectWithTag(gameObject.tag).GetComponent<Item>();
        terminal = GameObject.FindGameObjectWithTag("Terminal").GetComponent<Terminal>();
        terminal.Log("transmition device not activated");
    }
    private void Start()
    {
        terminal.inputField.onEndEdit.AddListener(delegate { CheckForQuestCommands(); });
    }
    private void CheckForQuestCommands()
    {
        if (terminal.inputField.text == "start" && !wasTvStarted)
        {
            terminal.Log("Activating...");
            terminal.Log("Play Game yes/no");
            terminal.inputField.text = string.Empty;
            wasTvStarted = true;
        }
        else if ((terminal.inputField.text == "yes" || terminal.inputField.text == "y" || terminal.inputField.text == "Y") && wasTvStarted)
        {
            isGamePlayed = true;
            tv.dialogue = tvGameDialogue;
            terminal.inputField.text = string.Empty;
            FinishQuestStep();
        }
    }

    //private void OnDestroy()
    //{
    //    terminal.inputField.onEndEdit.RemoveListener(delegate { CheckForQuestCommands(); });

    //}
}
