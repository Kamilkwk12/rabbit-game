using UnityEngine;

public class DisappearAfterTime : MonoBehaviour
{
    public float delay = 17f; // Time in seconds before object disappears

    void Start()
    {
        // Start the coroutine to hide the object after the delay
        StartCoroutine(HideAfterDelay());
    }

    private System.Collections.IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false); // Makes the GameObject disappear
    }
}
