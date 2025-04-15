using UnityEngine;

public class ItemInteractions : MonoBehaviour
{

    public Canvas ui; 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ui.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ui.enabled = false;
    }
}
