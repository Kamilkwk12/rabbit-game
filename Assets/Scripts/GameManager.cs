using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool pendrivePickedUp { get; private set; } = false;
    public bool pendrivePluggedToRouter { get; private set; } = false;
    public bool virtualStateActive { get; private set; } = false;
    
    public SpriteRenderer Background;

    private List<GameObject> editableObjects;

    private void Start()
    {
        editableObjects = GameObject.FindGameObjectsWithTag("Object").ToList();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        
    }

    public void PendrivePickedUp()
    {
        Debug.Log("Pendrive picked up");
        pendrivePickedUp = true;
    }

    public void UsePendrive()
    {
        Debug.Log("Pendrive plugged to router");
        pendrivePickedUp = false;
        pendrivePluggedToRouter = true;
    }

    public void ChangeGameState()
    {
        virtualStateActive = !virtualStateActive;

        if (virtualStateActive)
        {
            Background.color = Color.blue;

            foreach (var obj in editableObjects)
            {
                obj.GetComponent<SpriteRenderer>().color = Color.red;
                obj.GetComponent<SpriteRenderer>().enabled = true;
                obj.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        else
        {
            Background.color = Color.gray;
            foreach (var obj in editableObjects)
            {
                obj.GetComponent<SpriteRenderer>().color = Color.white;
                if (!obj.GetComponent<EditableObjectScript>().isActive)
                {
                    obj.GetComponent<SpriteRenderer>().enabled = false;
                    obj.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
    }
}
