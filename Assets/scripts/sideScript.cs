using UnityEngine;

public class sideScript : MonoBehaviour
{
    private Transform player;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    private void LateUpdate()
    {
        Vector3 CameraPosition = transform.position;
        CameraPosition.x = Mathf.Max(CameraPosition.x, player.position.x);
        transform.position = CameraPosition;
    }
}
