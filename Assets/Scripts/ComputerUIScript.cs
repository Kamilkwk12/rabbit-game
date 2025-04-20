using UnityEngine;
using UnityEngine.UIElements;

public class ComputerUIScript : MonoBehaviour
{

    private UIDocument _document;
    private VisualElement _noteWindow;
    private Button _windowCloseButton;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();
        _noteWindow = _document.rootVisualElement.Q<VisualElement>("NoteWindow");
        _windowCloseButton = _document.rootVisualElement.Q<Button>("WindowCloseButton");

        _windowCloseButton.RegisterCallback<ClickEvent>(CloseWindow);
    }

    private void OnDisable()
    {
        _windowCloseButton.UnregisterCallback<ClickEvent>(CloseWindow);

    }
    private void CloseWindow(ClickEvent evt)
    {
        Debug.Log("Window closed");
        _noteWindow.style.display = DisplayStyle.None;
    }

    public void OpenWindow()
    {
        _noteWindow.style.display = DisplayStyle.Flex;
    }
}
