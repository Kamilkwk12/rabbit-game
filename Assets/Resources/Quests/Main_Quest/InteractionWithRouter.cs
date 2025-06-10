using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class InteractionWithRouter : InteractionQuestStep
{

    GameManager manager;
    Router router;
    AudioSource audioSource;
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        router = GameObject.FindGameObjectWithTag("Router").GetComponent<Router>();
        audioSource = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioSource>();
        GameEventsManager.instance.questEvents.onAdvanceQuest += RouterInteraction;

    }

    private void RouterInteraction(string id)
    {
        manager.WorldSwitch();
        router.isRouterActive = true;
        audioSource.resource = Resources.Load<AudioClip>("Audio/other");
        audioSource.Play();
        FinishQuestStep();
    }

    private void OnDestroy()
    {
        GameEventsManager.instance.questEvents.onAdvanceQuest -= RouterInteraction;

    }
}
