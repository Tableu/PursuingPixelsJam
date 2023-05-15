using System;
using Systems.Modifiers;
using UnityEngine;

[CreateAssetMenu(fileName = "Health Modifier", menuName = "Modifiers/Health", order = 0)]
[Serializable]
public class HealthModifierEffect : StatModiferEffect
{
    protected override ModifiableStat GetStat(ModifiableTarget target)
    {
        var stats = target.GetComponent<Health>();
        return stats.maxHealth;
    }
}
