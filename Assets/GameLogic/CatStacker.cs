using UnityEngine;
using Random = UnityEngine.Random;

namespace GameLogic
{
    public class CatStacker : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] _cats = default;

        [SerializeField]
        private GameObject _stackRoot = null;

        public Sprite GetRandomCat()
        {
            return _cats[Random.Range(0, _cats.Length - 1)];
        }

        public void StackCat(Sprite sprite, float position)
        {
        }

        public void Clear()
        {
        }

        public class StackedCat
        {
            public Sprite Cat;
            public SpriteRenderer Renderer;
        }
    }
}
