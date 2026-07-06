using UnityEngine;

public class RainFollowPlayer : MonoBehaviour
{
    public Transform player;
    // Location of the Rain Particle above the player
    public Vector3 offset = new Vector3(0, 20, 0);

    void Update()
    {
        if (player != null)
        {
            // Update Rain Particle to follow player position plus its offset
            transform.position = player.position + offset;
        }
    }
}
