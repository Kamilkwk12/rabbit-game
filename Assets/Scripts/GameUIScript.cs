using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameUIScript : MonoBehaviour
{

    private UIDocument _document;

    [SerializeField] private int alphaVersion = 0;
    private Label _buildVersionLabel;


    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        _buildVersionLabel = _document.rootVisualElement.Q<Label>("BuildNumber");
        _buildVersionLabel.text = $"Build: {alphaVersion}.0{Application.version}";
    }
}


