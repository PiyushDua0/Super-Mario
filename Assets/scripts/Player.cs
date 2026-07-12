using UnityEngine;

public class Player : MonoBehaviour

{
    public PlayerScript smallRenderer;
    public PlayerScript bigRenderer;
    private deadAnimation deathAnimation;
    public bool big => bigRenderer.enabled;
    public bool small => smallRenderer.enabled;
    public bool dead => deathAnimation.enabled;
    private void Awake()
    {
        deathAnimation = GetComponent<deadAnimation>();
    }
    public void Hit()
    {
        if (big)
        {
            Shrink();
        }
        else
        {
            Death();
        }
    }
    private void Shrink()
    {

        // TODO
    }
    private void Death()
    {
        smallRenderer.enabled = false;
        bigRenderer.enabled = false;
        deathAnimation.enabled = true;
        GameManager.Instance.ResetLevel(3f);
    }
}
