using UnityEngine;
using System.Collections;
public class BlockHit : MonoBehaviour

{
    public Sprite emptyBlock;
    public int maxHits = -1;

    private bool animating;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!animating && collision.transform.DotTest(transform, Vector2.up))
            {
                Hit();
            }
        }
    }
    private void Hit()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        maxHits--;
        if (maxHits == 0)
        {
            spriteRenderer.sprite = emptyBlock;
        }
        //StartCoroutine(Animate());
    }
    //private IEnumerator Animate()
    //{
    //    Vector3 restingPosition = transform.localPosition;
    //    Vector3 animatedPosition = restingPosition + Vector3.up * 0.5f;
    //    animating = true;
    //}

}