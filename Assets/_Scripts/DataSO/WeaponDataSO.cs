using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/WeaponData")]
public class WeaponDataSO : ScriptableObject
{
    [field: SerializeField]
    public BulletDataSO BulletData { get; set; }

    [field: SerializeField]
    [field: Range(0, 100)]
    public int AmmoCapacity { get; set; } = 100;

    [field: SerializeField]
    public bool AutomaticFire { get; set; } = false;

    [field: SerializeField]
    [field: Range(0.1f, 2f)]
    public float WeaponDelay { get; set; } = 0.2f;

    [field: SerializeField]
    [field: Range(0f, 10f)]
    public float SpreadAngle { get; set; } = 5;

    [SerializeField]
    private bool multiBulletShoot = false;

    [SerializeField]
    [Range(0, 10)]
    private int bulletCount = 1;

    public int GetBulletCountToSpawn()
    {
        if(multiBulletShoot == true)
        {
            return bulletCount;
        }
        return 1;
    }
}
