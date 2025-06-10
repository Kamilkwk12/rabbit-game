using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class cutscene1 : MonoBehaviour
{
    [Header("Timer Settings")]
    public float totalTime = 29.7f;

    public string nextSceneName = "MainScene";

    private float timeRemaining;
    private bool timerRunning;

    private void Start()
    {
        Cursor.visible = false;

        timeRemaining = totalTime;
        timerRunning = true;
    }

    private void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {

                timeRemaining -= Time.deltaTime;



            }
            else
            {

                timerRunning = false;
                timeRemaining = 0;


                SceneManager.LoadScene("MainScene");
            }
        }
    }


}
