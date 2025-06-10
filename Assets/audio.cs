using UnityEngine;

public class DelayedAudio : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        Invoke("PlayAudio", 17f);
    }

    void PlayAudio()
    {
        audioSource.Play();
    }
}
