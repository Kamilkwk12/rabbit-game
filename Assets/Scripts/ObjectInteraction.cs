using TMPro;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _interactionText;

    void Awake()
    {
        _interactionText.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _interactionText.enabled = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _interactionText.enabled = false;
    }
}
