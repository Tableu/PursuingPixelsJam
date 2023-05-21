using System;
using System.Collections.Generic;
using System.Linq;
using Systems.Modifiers;
using Unity.VisualScripting;
using Random = UnityEngine.Random;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/RandomModifierData")]
[Serializable]
public class RandomModifierData : ScriptableObject
{
    [SerializeField] private List<RandomModifier> modifierList;

    public List<ModifierPair> GetRandomModifiers(int count)
    {
        List<ModifierPair> results = new List<ModifierPair>();
        List<RandomModifier> copy = modifierList.ToList();
        for (int i = 0; i < count; i++)
        {
            ModifierPair data = RandomModifier(copy);
            results.Add(data);
            copy.RemoveAll(modifier => modifier.Data.Equals(data));
        }

        return results;
    }

    private ModifierPair RandomModifier(List<RandomModifier> modifiers)
    {
        List<int> intervals = new List<int>();
        int totalWeight = 0;
        foreach (int weight in modifiers.Select(o => o.Weight).ToList())
        {
            totalWeight += weight;
            intervals.Add(totalWeight);
        }

        float randomNumber = Random.Range(0, totalWeight);
        int index = 0;
        foreach (int interval in intervals)
        {
            if (randomNumber < interval)
            {
                return modifiers[index].Data;
            }

            index++;
        }

        return modifiers[0].Data;
    }
}
[Serializable]
public struct RandomModifier
{
    public ModifierPair Data;
    public int Weight;
}

[Serializable]
public struct ModifierPair
{
    public ModifierData Player;
    public ModifierData Enemy;

    public override bool Equals(object obj)
    {
        if (!(obj is ModifierPair))
        {
            return false;
        }

        ModifierPair pair = (ModifierPair) obj;
        return pair.Enemy == Enemy && pair.Player == Player;
    }
}