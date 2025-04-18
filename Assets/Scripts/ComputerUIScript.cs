using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ComputerUIScript : MonoBehaviour
{

    private UIDocument _document; 
    
    private VisualElement _window;
    private VisualElement _windowBar;
    private VisualElement _computerScreen;


    private bool _dragActive = false;
    private Vector3 _targetStartPosition;
    private Vector3 _pointerStartPosition;

    private void Awake()
    {
       _document = GetComponent<UIDocument>();

        _window = _document.rootVisualElement.Q("Window");
        _windowBar = _document.rootVisualElement.Q("WindowBar");
        _computerScreen = _document.rootVisualElement.Q("ComputerScreen");

        _windowBar.RegisterCallback<PointerDownEvent>(PointerDownHandler);
        _windowBar.RegisterCallback<PointerMoveEvent>(PointerMoveHandler);
        _windowBar.RegisterCallback<PointerUpEvent>(PointerUpHandler);


    }

    private void OnDisable()
    {
        _windowBar.UnregisterCallback<PointerDownEvent>(PointerDownHandler);
        _windowBar.UnregisterCallback<PointerMoveEvent>(PointerMoveHandler);
        _windowBar.UnregisterCallback<PointerUpEvent>(PointerUpHandler);


    }

    private void PointerDownHandler(PointerDownEvent evt)
    {
        _targetStartPosition = _window.transform.position;
        _pointerStartPosition = evt.position;
        _dragActive = true;

    }

    private void PointerMoveHandler(PointerMoveEvent evt)
    {
        if (_dragActive) {

            Vector3 pointerDelta = evt.position - _pointerStartPosition;

            _window.transform.position = new Vector2(
                Mathf.Clamp(_targetStartPosition.x + pointerDelta.x, 0, 960),
                Mathf.Clamp(_targetStartPosition.y + pointerDelta.y, 0, 960));
        }
    }

    private void PointerUpHandler(PointerUpEvent evt)
    {
        _dragActive = false;
    }
}
