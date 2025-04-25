using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPendrivePickedUp { get; private set; } = false;
    public bool isPendrivePluggedToRouter { get; private set; } = false;
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
        isPendrivePickedUp = true;
    }

    public void UsePendrive()
    {
        Debug.Log("Pendrive plugged to router");
        isPendrivePickedUp = false;
        isPendrivePluggedToRouter = true;
    }
}
