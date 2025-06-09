using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool pendrivePickedUp { get; private set; } = false;
    public bool pendrivePluggedToRouter { get; private set; } = false;
    public bool virtualStateActive { get; private set; } = false;
    
    public SpriteRenderer Background;

    private List<GameObject> objects;
    private List<EditableObject> editableObjects;

    private void Start()
    {
        //search for all editable objects
        objects = GameObject.FindGameObjectsWithTag("Object").ToList();
        editableObjects = FindObjectsByType<EditableObject>(FindObjectsSortMode.None).ToList();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void ChangeGameState() // TODO - rework world state change
    {
        virtualStateActive = !virtualStateActive;

        if (virtualStateActive)
        {
            Background.color = Color.blue;

            foreach (var obj in editableObjects)
            {
                obj.Activate();
                obj.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
        else
        {
            Background.color = Color.gray;
            foreach (var obj in editableObjects)
            {
                obj.Activate();
                if (!obj.isActive)
                {
                    obj.Deactivate();
                }
            }
        }
    }

    public void ActivateAllObjects()
    {
        foreach (var obj in editableObjects)
        {
            obj.isActive = true;
        }
    }
}
