using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ComputerUI : MonoBehaviour
{
    public enum WindowType
    {
        Error, 
        EditWindow
    }

    private GameManager gameManager;

    private UIDocument _document;
    public VisualTreeAsset IconTemplate;
    public VisualTreeAsset ErrorTemplate;
    public VisualTreeAsset EditWindowTemplate;
    private Label _terminalLog;
    private VisualElement _terminalWindow;
    private Button _terminalCloseButton;

    public TextField _terminalInput;

    public DesktopIcon[] DefaultDesktopIcons; //all desktop icons to add on awake
    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _document = GetComponent<UIDocument>();

        _terminalWindow = _document.rootVisualElement.Q<VisualElement>("Terminal");
        _terminalLog = _document.rootVisualElement.Q<Label>("TerminalLog");
        _terminalLog.text = "rabbit@rabbit ~ $ system init";
        _terminalInput = _document.rootVisualElement.Q<TextField>("TerminalInput");

        _terminalCloseButton = _terminalWindow.Q<Button>();
        _terminalCloseButton.RegisterCallback<ClickEvent, VisualElement>(CloseWindow, _terminalWindow);

        _terminalInput.RegisterCallback<KeyDownEvent, TextField>(ExecuteCommand, _terminalInput, TrickleDown.TrickleDown);
        _terminalInput.RegisterCallback<ClickEvent>((evt) =>
        {
            _terminalInput.Focus();
        });

        for (int i = 0; i < DefaultDesktopIcons.Length; i++) //adds all default desktop icons
        {
            AddDesktopIcon(DefaultDesktopIcons[i]);
        }
    }

    private void OnDisable()
    {
        //disable all callbacks from all icons
        List<VisualElement> icons = _document.rootVisualElement.Query<VisualElement>(className: "desktopIcon").ToList();
        Debug.Log(icons.Count);
        foreach (var icon in icons)
        {
            icon.UnregisterCallback<ClickEvent, DesktopIcon>(IconClick);
        }
    }



    public void AddDesktopIcon(DesktopIcon iconData)
    {
        VisualElement icon = IconTemplate.Instantiate().Children().FirstOrDefault();
        icon.name = iconData.IconName;
        icon.Q<Label>("IconCaption").text = iconData.IconName;
        icon.style.backgroundImage = new StyleBackground(iconData.IconSprite);
        
        icon.RegisterCallback<ClickEvent, DesktopIcon>(IconClick, iconData);

        _document.rootVisualElement.Q<VisualElement>("Desktop").Add(icon);
    }

    private void IconClick(ClickEvent evt, DesktopIcon iconData)
    {

        switch (iconData.IconName)
        {
            case "Terminal":
                OpenWindow(_terminalWindow);
                break;
                
            case "unknown.exe":
                OpenWindow(WindowType.Error);
                break;

            case "readme.txt":
                TerminalLog(iconData.Content);
                break;

            default:
                break;
        }
    }
    private void ExecuteCommand(KeyDownEvent evt, TextField terminalInput)
    {
        if (evt.keyCode == KeyCode.Return) { 
            string command = terminalInput.text;
            terminalInput.SetValueWithoutNotify("");
            TerminalLog("> " + command);
            ChceckForCommands(command);
            terminalInput.Blur();
            evt.StopPropagation();
        }
    }

    public void ChceckForCommands(string executedString)
    {
        switch (executedString)
        {
            case "exit":
                CloseWindow(_terminalWindow);
                break;

            case "objects show /a":
                if (gameManager.virtualStateActive)
                {
                    gameManager.ActivateAllObjects();
                    TerminalLog("Aktywowano wszystkie obiekty");
                } else
                {
                    TerminalLog($"Nie rozpoznano komendy '{executedString}'");
                }
                break;
            default:
                TerminalLog($"Nie rozpoznano komendy '{executedString}'");
                break;
        }
    }


    public void TerminalLog(string logText) //log something in computers terminal
    {
        _terminalLog.text = _terminalLog.text + Environment.NewLine + logText;
    }
    public void OpenWindow(WindowType windowType, EditableObject target = null) //create window with given type
    {
        VisualElement window = new();
        if (windowType == WindowType.Error) { 
             window = ErrorTemplate.Instantiate();
        }
        if (windowType == WindowType.EditWindow && target) {
            window = EditWindowTemplate.Instantiate();
            Toggle toggle = window.Q<Toggle>();
            toggle.value = target.isActive;
            toggle.RegisterCallback<ClickEvent>((context) =>
            {
                target.isActive = toggle.value;
            });
        }

        window.style.position = Position.Absolute;
        window.Q<Button>("WindowCloseButton").RegisterCallback<ClickEvent>((context) =>
        {
            window.RemoveFromHierarchy();
        });

        _document.rootVisualElement.Q<VisualElement>("ComputerScreen").Add(window);

            
    }
    public void OpenWindow(VisualElement target) //show window from hierarchy
    {
        target.style.display = DisplayStyle.Flex;
    }public void CloseWindow(VisualElement target) //show window from hierarchy
    {
        target.style.display = DisplayStyle.None;
    }
    private void CloseWindow(ClickEvent evt, VisualElement currentTarget) //hide window, dont remove it from hierarchy
    {
        currentTarget.style.display = DisplayStyle.None;
    }
    public void RemoveIcon(string iconName)
    {
        VisualElement icon = _document.rootVisualElement.Query<VisualElement>(iconName);
        icon.RemoveFromHierarchy();
    }
}
