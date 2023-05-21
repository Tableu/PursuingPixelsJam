using System;
using Systems.Modifiers;
using UnityEngine;

[CreateAssetMenu(fileName = "Speed Effect", menuName = "Modifiers/Speed", order = 0)]
[Serializable]
public class SpeedEffect : StatModiferEffect
{
    protected override ModifiableStat GetStat(ModifiableTarget target)
    {
        var stats = target.GetComponent<CharacterStats>();
        return stats.speed;
    }
}
