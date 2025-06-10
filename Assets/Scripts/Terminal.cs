using System;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Terminal : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI terminalOutput;
    [SerializeField] public TMP_InputField inputField;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject desktop;
    [SerializeField] private GameObject iconPrefab;

    [SerializeField] private PlayerMovement player;

    private void Update()
    {
        if (inputField.isFocused)
        {
            player.DisableMovement(); 
        }
    }

    public void ExecuteCommand()
    {
        terminalOutput.text = terminalOutput.text + Environment.NewLine + "> " + inputField.text;
        SearchForCommands(inputField.text);
        player.EnableMovement();
    }

    private void SearchForCommands(string command)
    {

        switch (command.ToLower())
        {
            case "skip quest1": //debug command
                GameEventsManager.instance.questEvents.FinishQuest("Quest1");
                GameEventsManager.instance.questEvents.StartQuest("Quest2");
                inputField.text = string.Empty;

                break;

            case "start":
                break;
            case "yes":
                break;
            case "y":
                break;
            case "switch":
                gameManager.WorldSwitch();
                break;
            default:
                Log($"Command '{command}' not found");
                inputField.text = string.Empty;

                break;
        }
    }

    public void Log(string log)
    {
        terminalOutput.text = terminalOutput.text + Environment.NewLine + log;
    }

    public void AddIcon(DesktopIcon iconData)
    {
        GameObject icon = Instantiate(iconPrefab, desktop.transform);
        icon.GetComponent<Image>().sprite = iconData.iconSprite;
        icon.GetComponent<Icon>().content = iconData.iconContent;
    }
}
