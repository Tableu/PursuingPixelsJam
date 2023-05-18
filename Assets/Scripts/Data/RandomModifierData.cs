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

    public List<ModifierData> GetRandomModifiers(int count)
    {
        List<ModifierData> results = new List<ModifierData>();
        List<RandomModifier> copy = modifierList.ToList();
        for (int i = 0; i < count; i++)
        {
            ModifierData data = RandomModifier(copy);
            results.Add(data);
            copy.RemoveAll(modifier => modifier.Data == data);
        }

        return results;
    }

    private ModifierData RandomModifier(List<RandomModifier> modifiers)
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
    public ModifierData Data;
    public int Weight;
}