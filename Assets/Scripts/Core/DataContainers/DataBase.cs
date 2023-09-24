using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

/// <summary>
/// Stores information about any entity in the game
/// </summary>
public class DataBase : MonoBehaviour
{
    [HideInInspector] public List<Enemy> EnemyObjectsPool = new List<Enemy>();
    [HideInInspector] public PlayerObject PlayerObject;
}
