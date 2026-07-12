using UnityEngine;

public class koopa : MonoBehaviour

{
    public Sprite shellSprite;
    private bool shelled;
    private bool pushed;
    public float shellSpeed = 12f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!shelled && collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (collision.transform.DotTest(transform, Vector2.down))
            {
                EnaterShell();
            }
            else
            {
                player.Hit();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (shelled && other.CompareTag("Player"))
        {
            if (!pushed)
            {
                Vector2 direction = new Vector2(transform.position.x - other.transform.position.x, 0f);
                PushShell(direction);
            }
            else
            {

                Player player = other.GetComponent<Player>();
                player.Hit();
            }
        }else if(!shelled && other.gameObject.layer == LayerMask.NameToLayer("shell"))
        {
            Hit();
        }
    }
    private void EnaterShell()
    {
        shelled = true;
        GetComponent<EntityMovement>().enabled = false;
        GetComponent<AnimationScript>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = shellSprite;

    }
    private void PushShell(Vector2 direction)
    {
        pushed = true;
     
        EntityMovement movement = GetComponent<EntityMovement>();
        movement.direction = direction.normalized;
        movement.speed = shellSpeed;
        movement.enabled = true;

        gameObject.layer = LayerMask.NameToLayer("shell");
    }
    private void Hit()
    {
        GetComponent<AnimationScript>().enabled = false;
        GetComponent<deadAnimation>().enabled = true;
        Destroy(gameObject, 3f);
    }
}
