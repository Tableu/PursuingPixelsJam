using System;
using Systems;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Data/Weapon", order = 0)]
[Serializable]
public class WeaponData : UniqueId
{
    [SerializeField] private int baseCooldown;
    [SerializeField] private int baseDamage;
    [SerializeField] private int baseProjectileSpeed;

    public int BaseCooldown => baseCooldown;
    public int BaseDamage => baseDamage;
    public int BaseProjectileSpeed => baseProjectileSpeed;
}
