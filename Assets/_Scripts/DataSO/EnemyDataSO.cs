using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemies/Enemy Data")]
public class EnemyDataSO : ScriptableObject
{
    [field: SerializeField]
    public int MaxHealth { get; private set; } = 3;

    [field: SerializeField]
    public int Damage { get; set; } = 1;
}
