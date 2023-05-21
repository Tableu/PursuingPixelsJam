using System;
using Systems.Modifiers;
using UnityEngine;
[CreateAssetMenu(fileName = "Damage Effect", menuName = "Modifiers/Damage", order = 0)]
[Serializable]
public class DamageEffect : StatModiferEffect
{
    protected override ModifiableStat GetStat(ModifiableTarget target)
    {
        var stats = target.GetComponent<WeaponStats>();
        return stats.damage;
    }
}
