using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildShower : MonoBehaviour
{

    [SerializeField] private int alphaVersion = 0;
    private TMP_Text versionField;
    private void Awake() {
        versionField = GetComponent<TMP_Text>();
        versionField.SetText($"Build: {alphaVersion}.{Application.version}");
    }
}
