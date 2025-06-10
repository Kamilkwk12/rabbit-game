using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{



    public bool isWorldReal = true; //1 yes, 0 no

    public GameObject realWorld;
    public GameObject virtualWorld;
    public SpriteRenderer routerSpriteRenderer;
    public Sprite[] routerSprites;
    [SerializeField] Key key;
    [SerializeField] BoxCollider2D endingTrigger;
    public static event Action onWorldSwitch;

    private void Start()
    {
        realWorld.SetActive(true);
        virtualWorld.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void WorldSwitch()
    {

        onWorldSwitch?.Invoke();

        realWorld.SetActive(!realWorld.activeSelf);
        virtualWorld.SetActive(!virtualWorld.activeSelf);

        isWorldReal = !isWorldReal;

        if (routerSpriteRenderer.sprite == routerSprites[0])
        {
            routerSpriteRenderer.sprite = routerSprites[1];
        }
        else
        {
            routerSpriteRenderer.sprite = routerSprites[0];

        }

        if (key.isKeyPickedUp && isWorldReal)
        {
            endingTrigger.enabled = true;
        }
        else
        {
            endingTrigger.enabled = false;
        }
    }
}
