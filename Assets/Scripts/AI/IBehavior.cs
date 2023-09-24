using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public interface IBehavior
    {
        void ControlObject(GameObject objectToControl, HealthComponent healthComponent, IAttackingComponent attackingComponent);
        void MovementControl(GameObject objectToControl);
    }
}
