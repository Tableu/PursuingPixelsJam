using System;
using Systems.Modifiers;
using UnityEngine;

[CreateAssetMenu(fileName = "Reflect effect", menuName = "Modifiers/Reflect", order = 0)]
[Serializable]
public class SwordReflectModifier : IEffect
{
    public override void Apply(ModifiableTarget target)
    {
        target.GetComponent<WeaponStats>().ReflectProjectiles = true;
    }

    public override void Remove(ModifiableTarget target)
    {
        target.GetComponent<WeaponStats>().ReflectProjectiles = false;
    }
}
