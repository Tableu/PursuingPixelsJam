using System;
using Systems.Modifiers;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack Speed Effect", menuName = "Modifiers/Attack Speed", order = 0)]
[Serializable]
public class AttackSpeedEffect : StatModiferEffect
{
    protected override ModifiableStat GetStat(ModifiableTarget target)
    {
        var stats = target.GetComponent<CharacterStats>();
        return stats.attackSpeed;
    }
}
