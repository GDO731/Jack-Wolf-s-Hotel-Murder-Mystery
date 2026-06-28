using Assets.Game.Scripts.Dialogue;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerConversant playerConversant;

    void Awake()
    {
        playerConversant = GetComponent<PlayerConversant>();
    }

    void Update()
    {
        InteractWithComponent();
    }

    bool InteractWithComponent()
    {
        foreach (RaycastHit hit in RaycastAllSorted())
        {
            foreach (AIConversant conversant in hit.transform.GetComponents<AIConversant>())
            {
                if (conversant.HandleRaycast(playerConversant))
                    return true;
            }
        }
        return false;
    }

    RaycastHit[] RaycastAllSorted()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit[] hits = Physics.RaycastAll(ray);
        System.Array.Sort(hits, (a, b) => a.distance.CompareTo(b.distance));
        return hits;
    }
}
