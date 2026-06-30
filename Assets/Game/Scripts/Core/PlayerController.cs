using Assets.Game.Scripts.Dialogue;
using Assets.Game.Scripts.Interaction;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Game.Scripts.Core
{
    public class PlayerController : MonoBehaviour
    {
        PlayerConversant playerConversant;
        InputReader inputReader;

        void Awake()
        {
            playerConversant = GetComponent<PlayerConversant>();
            inputReader = GetComponent<InputReader>();
        }

        void OnEnable() => inputReader.InteractEvent += OnInteract;
        void OnDisable() => inputReader.InteractEvent -= OnInteract;

        void OnInteract()
        {
            foreach (RaycastHit hit in RaycastAllSorted())
            {
                foreach (Interactable interactable in hit.transform.GetComponents<Interactable>())
                {
                    if (IsWithinRange(interactable))
                    {
                        interactable.Interact();
                    }
                }
            }
        }

        private bool IsWithinRange(Interactable interactable)
        {
            return Vector3.Distance(transform.position, interactable.transform.position) <= interactable.GetRange();
        }

        private RaycastHit[] RaycastAllSorted()
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit[] hits = Physics.RaycastAll(ray);
            System.Array.Sort(hits, (a, b) => a.distance.CompareTo(b.distance));
            return hits;
        }
    }
}

