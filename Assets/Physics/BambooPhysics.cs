using System.Collections.Generic;
using GameLogic;
using UnityEngine;

namespace Physics
{
    public class BambooPhysics : AbstractCatStackPhysics
    {
        [SerializeField]
        private float _maxBendAngle = 45f;

        [SerializeField]
        private float _flexibility = 1f;

        [SerializeField]
        private float _bounciness = 0f;

        protected override void ApplyPhysics(IReadOnlyList<CatStacker.StackedCat> stack)
        {
            if (stack.Count == 0)
            {
                return;
            }

            var collected = 0;
            var pushForces = new Force[stack.Count - 1];
            var nextCat = stack[stack.Count - 1];
            var collectedWeight = 0f;
            var collectedCenterOfMass = Vector2.zero;
            for (var catIndex = stack.Count - 2; catIndex >= 0; catIndex--)
            {
                collectedWeight += nextCat.Cat.Weight;
                collectedCenterOfMass += nextCat.Position * nextCat.Cat.Weight;

                var cat = stack[catIndex];
                var direction = (cat.Position - nextCat.Position).normalized;

                pushForces[collected++] = new Force
                {
                    RootCat = cat,
                    StartIndex = catIndex,
                    Direction = direction,
                    CenterOfMass = collectedCenterOfMass / collectedWeight,
                    Mass = collectedWeight,
                };

                nextCat = cat;
            }

            foreach (var force in pushForces)
            {
                Debug.Log($"i:{force.StartIndex} m:{force.Mass} c:{force.CenterOfMass} d:{force.Direction}");
                force.Apply(stack);
            }
        }

        public struct Force
        {
            public CatStacker.StackedCat RootCat;
            public int StartIndex;
            public float Mass;
            public Vector2 CenterOfMass;
            public Vector2 Direction;

            public void Apply(IReadOnlyList<CatStacker.StackedCat> stack)
            {
                var progress = (float) StartIndex / stack.Count;
                Debug.DrawLine(RootCat.Position, CenterOfMass, new Color(progress, progress, progress * 4 % 1f));
            }
        }

        private const float Gravity = 9.807f;
    }
}
