using UnityEngine;

public class RainFollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 20, 0); // Location of Rain Above Player

    void Update()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}
