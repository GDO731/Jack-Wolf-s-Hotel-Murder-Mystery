using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.Core
{
    public class SpriteSwap : MonoBehaviour
    {
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] Image image;
        private Sprite defaultSprite;

        void Awake()
        {
            defaultSprite = GetSprite();
        }

        public void Swap(Sprite sprite)
        {
            SetSprite(sprite);
        }

        public void ResetSprite()
        {
            SetSprite(defaultSprite);
        }

        private Sprite GetSprite()
        {
            if (spriteRenderer != null) return spriteRenderer.sprite;
            if (image != null) return image.sprite;
            return null;
        }

        private void SetSprite(Sprite sprite)
        {
            if (spriteRenderer != null) spriteRenderer.sprite = sprite;
            else if (image != null) image.sprite = sprite;
        }
    }
}
