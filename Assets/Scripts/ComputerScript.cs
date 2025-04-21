using UnityEngine;
using UnityEngine.UIElements;

public class ComputerScript : MonoBehaviour
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

    private void OpenWindow()
    {
        _noteWindow.style.display = DisplayStyle.Flex;
    }

    public void Action(GameObject _interactedObject)
    {
        if (_interactedObject.CompareTag("Item"))
        {
            Debug.Log($"Player interacted with {_interactedObject.name}");
            OpenWindow();
        } else if (_interactedObject.CompareTag("Object"))
        {
            Debug.Log($"Player opened {_interactedObject.name}");
        }
    }
}
