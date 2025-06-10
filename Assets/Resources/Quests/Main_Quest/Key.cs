using UnityEngine;

public class Key : Item 
{
    GameManager gameManager;
    public bool isKeyPickedUp = false;
    private bool isActive = false;
    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        UpdateSpriteAndCollider();

        GameManager.onWorldSwitch += ChangeVisibility;
    }

    

    private void ChangeVisibility()
    {
        isActive = !isActive;
        UpdateSpriteAndCollider();
    }


    public void PickUpKey()
    {
        isKeyPickedUp = true;
        isActive = false;
        GameManager.onWorldSwitch -= ChangeVisibility;
        UpdateSpriteAndCollider();
    }
    private void UpdateSpriteAndCollider()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = isActive;
        gameObject.GetComponent<BoxCollider2D>().enabled = isActive;
    }
}
