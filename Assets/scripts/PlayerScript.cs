using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private movementScript movement;

    public Sprite idle;
    public Sprite jump;
    public Sprite slide;
    public Animation run;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponentInParent<movementScript>();
    }
    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }
    private void OnDisable()
    {
        spriteRenderer.enabled = false;
 

    }
    private void LateUpdate()

    {
        
        if (movement.jumping)
        {
            spriteRenderer.sprite = jump;
        }
        else if (movement.sliding)
        {
            spriteRenderer.sprite = slide;
        }
        else if (!movement.running)
        {
            spriteRenderer.sprite = idle;
        }

    }
}
