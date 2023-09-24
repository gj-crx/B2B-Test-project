using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

[CreateAssetMenu(fileName = "LevelScenario", menuName = "ScriptableObjects/LevelScenario", order = 2)]
public class LevelScenario : ScriptableObject
{
    public int countEnemiesToSpawn = 4;
    public float MapRadius = 7;

}
