using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameLogic
{
    public class CatStacker : MonoBehaviour
    {
        [SerializeField]
        private StackableCat[] _catPrefabss = default;

        [SerializeField]
        private Transform _stackRoot = null;

        public StackableCat GetRandomCat()
        {
            return _catPrefabss[Random.Range(0, _catPrefabss.Length - 1)];
        }

        public void StackCat(StackableCat catPrefab, float position, float rotation)
        {
            var spriteRenderer = catPrefab.GetComponent<SpriteRenderer>();
            var height = spriteRenderer.size.y;

            var placementHeight = 0f;
            if (_stackedCats.Count > 0)
            {
                placementHeight = _stackedCats[_stackedCats.Count - 1].Height;
            }

            var placedCat = Instantiate(
                catPrefab,
                new Vector3(position, placementHeight * _stackRoot.lossyScale.y, 0),
                Quaternion.Euler(0, 0, rotation),
                _stackRoot);

            var stacked = new StackedCat
            {
                Cat = placedCat,
                Height = placementHeight + height
            };

            _stackedCats.Add(stacked);
        }

        public void Clear()
        {
            _stackedCats.Clear();
        }

        private readonly List<StackedCat> _stackedCats = new List<StackedCat>();

        public class StackedCat
        {
            public StackableCat Cat = null;

            public float Height = 0;

            // todo more info for bending physics
        }
    }
}
