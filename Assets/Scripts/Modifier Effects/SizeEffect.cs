using System;
using Systems.Modifiers;
using UnityEngine;

[CreateAssetMenu(fileName = "Size Effect", menuName = "Modifiers/Size", order = 0)]
[Serializable]
public class SizeEffect : StatModiferEffect
{
    public override void Apply(ModifiableTarget target)
    {
        base.Apply(target);
        target.transform.localScale = new Vector3(multiplicativeModifer, multiplicativeModifer, 1);
    }

    public override void Remove(ModifiableTarget target)
    {
        base.Remove(target);
        target.transform.localScale = new Vector3(1, 1, 1);
    }

    protected override ModifiableStat GetStat(ModifiableTarget target)
    {
        return target.GetComponent<CharacterStats>().scale;
    }
}
