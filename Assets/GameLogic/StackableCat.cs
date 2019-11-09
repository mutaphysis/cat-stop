using UnityEngine;

namespace GameLogic
{
    public class StackableCat : MonoBehaviour
    {
        [SerializeField]
        private float _weight = 1;

        public float Weight => _weight;

        public float DetermineHeight()
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            // var spriteHeight = spriteRenderer.size.y;
            var sprite = spriteRenderer.sprite;
            var border = sprite.border;
            var sizeInSprite = (border.z + border.w) / sprite.pixelsPerUnit;
            var height = sizeInSprite;
            return height;
        }
    }
}
