using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        //TODO - rework game state change (virtual - real)
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
