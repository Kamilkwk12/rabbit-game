using UnityEngine;
using UnityEngine.EventSystems;

public class Icon : MonoBehaviour, IPointerClickHandler
{
    public string content;
    private Terminal terminal;

    private void Start()
    {
        terminal = GameObject.FindGameObjectWithTag("Terminal").GetComponent<Terminal>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        terminal.Log(content);
    }
}
