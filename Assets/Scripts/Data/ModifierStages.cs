using System;
using System.Collections.Generic;
using Systems.Modifiers;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/RandomModifierList")]
[Serializable]
public class ModifierStages : ScriptableObject
{
    [SerializeField] private List<ModifierStage> modifiers;

    public List<ModifierStage> Modifiers => modifiers;
}

[Serializable]
public struct ModifierStage
{
    public RandomModifierData Data;
    public int Count;
}
