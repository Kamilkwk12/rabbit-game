using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ComputerUI : MonoBehaviour
{

    private UIDocument _document;
    private VisualElement _terminalIcon;
    public VisualTreeAsset IconTemplate;
    private Label _terminalLog;
    private VisualElement _terminalWindow;
    private Button _terminalCloseButton;
    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        _terminalIcon = _document.rootVisualElement.Q<VisualElement>("TerminalIcon");
        _terminalWindow = _document.rootVisualElement.Q<VisualElement>("Terminal");
        _terminalCloseButton = _terminalWindow.Q<Button>();
        _terminalLog = _document.rootVisualElement.Q<Label>("TerminalLog");

        _terminalLog.text = "rabbit@rabbit ~ $ system init";

        _terminalIcon.RegisterCallback<ClickEvent, VisualElement>(IconClick, null);
        _terminalCloseButton.RegisterCallback<ClickEvent>(CloseWindow);
        
    }

    

    private void OnDisable()
    {
        //disable all callbacks from all icons
        List<VisualElement> icons = _document.rootVisualElement.Query<VisualElement>(className: "desktopIcon").ToList();
        Debug.Log(icons.Count);
        foreach (var icon in icons)
        {
            icon.UnregisterCallback<ClickEvent, VisualElement>(IconClick);
        }
        

    }

    public void AddDesktopIcon(DesktopIcon iconData)
    {
        VisualElement icon = IconTemplate.Instantiate();
        icon.name = iconData.IconName;
        icon.Q<Label>("IconCaption").text = iconData.IconName;
        icon.Q<VisualElement>("Icon").style.backgroundImage = new StyleBackground(iconData.IconSprite);
        

        icon.RegisterCallback<ClickEvent, VisualElement>(IconClick, icon);

        _document.rootVisualElement.Q<VisualElement>("Desktop").Add(icon);
    }

    private void IconClick(ClickEvent evt, VisualElement icon)
    {
        if (evt.currentTarget == _terminalIcon)
        {
            OpenWindow(_terminalWindow);
        }
        else
        {
            Log(icon.name);

        }
    }

    public void Log(string logText) //log something in computers terminal
    {
        _terminalLog.text = _terminalLog.text + Environment.NewLine + logText;
    }
    private void OpenWindow(VisualElement element)
    {
        element.style.display = DisplayStyle.Flex;
    }
    private void CloseWindow(ClickEvent evt)
    {
        _terminalWindow.style.display = DisplayStyle.None;
    }
}
