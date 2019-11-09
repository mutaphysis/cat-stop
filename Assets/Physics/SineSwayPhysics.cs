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

        protected override void ApplyPhysics(IReadOnlyList<CatStacker.StackedCat> stack)
        {
            var time = Time.time;

            for (var index = 0; index < stack.Count; index++)
            {
                var sway = _amplitude * Mathf.Sin(_frequency * (time + index));
                var stackedCat = stack[index];
                var catTransform = stackedCat.Cat.transform;

                var swayedPosition = catTransform.localPosition;
                swayedPosition.x = sway + stackedCat.Position;
                catTransform.localPosition = swayedPosition;
            }
        }
    }
}
