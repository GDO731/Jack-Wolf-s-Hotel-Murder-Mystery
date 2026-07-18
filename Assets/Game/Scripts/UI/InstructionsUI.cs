using Assets.Game.Scripts.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.UI
{
    public class InstructionsUI : MonoBehaviour
    {
        [SerializeField] Button quitButton;
        [SerializeField] GameObject inctructionsUI;
        [SerializeField] InputReader inputReader;
        [SerializeField] TextMeshProUGUI instruction;

        public void Start()
        {
            quitButton.onClick.AddListener(() => CloseInstructions());
        }

        void OnEnable() => inputReader.InstructionsEvent += ToggleInstructions;
        void OnDisable() => inputReader.InstructionsEvent -= ToggleInstructions;

        void ToggleInstructions()
        => inctructionsUI.SetActive(!inctructionsUI.activeSelf);

        private void CloseInstructions()
        {
            inctructionsUI.SetActive(false);
        }

        public void UpdateText(string text)
        {
            instruction.text = text;
        }
    }
}
