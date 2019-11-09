using System;
using System.Collections.Generic;
using GameLogic;
using UnityEngine;

namespace Physics
{
    public class SineSwayPhysics : AbstractCatStackPhysics
    {
        [SerializeField]
        private float _frequency = 1;

        [SerializeField]
        private float _amplitude = 1;

        [SerializeField]
        private int _maxSimulatedCats = 16;

        protected override void ApplyPhysics(IReadOnlyList<CatStacker.StackedCat> stack)
        {
            var time = Time.time;

            var startIndex = Math.Max(0, stack.Count - _maxSimulatedCats);
            for (var index = startIndex; index < stack.Count; index++)
            {
                var sway = _amplitude * Mathf.Sin(_frequency * (time + index));
                var stackedCat = stack[index];
                var catTransform = stackedCat.Cat.transform;

                var swayedPosition = catTransform.localPosition;
                swayedPosition.x = sway + stackedCat.InitialCenterOffset;
                catTransform.localPosition = swayedPosition;
                stackedCat.Position = swayedPosition;
            }
        }
    }
}
