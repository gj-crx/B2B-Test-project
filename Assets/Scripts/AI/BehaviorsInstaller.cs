using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

namespace AI
{
    public class BehaviorsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IBehavior>().To<PlayerChaserBehavior>().AsTransient();
        }
    }
}
