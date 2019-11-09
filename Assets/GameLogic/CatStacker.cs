using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace GameLogic
{
    public class CatStacker : MonoBehaviour
    {
        [FormerlySerializedAs("_catPrefabss")]
        [SerializeField]
        private StackableCat[] _catPrefabs = default;

        [SerializeField]
        private Transform _stackRoot = null;

        [SerializeField]
        private float _overlapMultiplier = .85f;

        public event Action<float> StackHeightChange;

        public IReadOnlyList<StackedCat> Stack => _stackedCats;

        public StackableCat GetRandomCat()
        {
            return _catPrefabs[Random.Range(0, _catPrefabs.Length - 1)];
        }

        public void StackCat(StackableCat catPrefab, float position, float rotation)
        {
            var height = catPrefab.DetermineHeight() * _overlapMultiplier;

            var placementHeight = height;
            var placementCenter = position;
            if (_stackedCats.Count > 0)
            {
                var lastCat = _stackedCats[_stackedCats.Count - 1];
                placementHeight += lastCat.Position.y;
                placementCenter += lastCat.InitialCenterOffset;
            }

            var placedCat = Instantiate(
                catPrefab,
                Vector3.zero,
                Quaternion.Euler(0, 0, rotation),
                _stackRoot);

            placedCat.transform.localPosition = new Vector3(placementCenter, placementHeight, 0);

            var stacked = new StackedCat
            {
                Cat = placedCat,
                InitialCenterOffset = placementCenter,
                Position = new Vector2(placementCenter, placementHeight),
            };

            _stackedCats.Add(stacked);

            StackHeightChange?.Invoke(placementHeight);
        }

        public void Clear()
        {
            foreach (var stackedCat in _stackedCats)
            {
                Destroy(stackedCat.Cat.gameObject);
                stackedCat.Cat = null;
            }

            _stackedCats.Clear();
            StackHeightChange?.Invoke(0);
        }

        private readonly List<StackedCat> _stackedCats = new List<StackedCat>();

        public class StackedCat
        {
            public StackableCat Cat = null;

            public float InitialCenterOffset = 0;

            public Vector2 Position = Vector2.zero;
        }
    }
}
