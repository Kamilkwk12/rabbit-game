using TMPro;
using UnityEngine;

public class BuildInfo : MonoBehaviour
{
    [SerializeField] private int alphaVersion = 0;


    private void Awake()
    {
        GetComponent<TextMeshProUGUI>().text = $"Build: {alphaVersion}.1{Application.version}";
    }
}