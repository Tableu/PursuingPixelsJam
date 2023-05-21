using System;
using Systems.Modifiers;
using UnityEngine;

[CreateAssetMenu(fileName = "Health Effect", menuName = "Modifiers/Health", order = 0)]
[Serializable]
public class HealthEffect : StatModiferEffect
{
    protected override ModifiableStat GetStat(ModifiableTarget target)
    {
        var stats = target.GetComponent<Health>();
        return stats.maxHealth;
    }
}
