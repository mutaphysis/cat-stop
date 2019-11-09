using System.Collections.Generic;
using GameLogic;
using UnityEngine;

namespace Physics
{
    public abstract class AbstractCatStackPhysics : MonoBehaviour
    {
        [SerializeField]
        private CatStacker _catStacker = null;

        private void Update()
        {
            ApplyPhysics(_catStacker.Stack);
        }

        protected abstract void ApplyPhysics(IReadOnlyList<CatStacker.StackedCat> stack);
    }
}
