using Assets.Game.Scripts.Dialogue;
using TMPro;
using UnityEngine;

namespace Assets.Game.Scripts.UI
{
    public class NameDisplay : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI Name;
        void Start()
        {
            Name.text = GetComponent<AIConversant>().GetName();
        }
    }
}
