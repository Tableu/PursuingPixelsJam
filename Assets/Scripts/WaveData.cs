using System;

using System.Collections.Generic;
using Systems;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave Data", menuName = "Data/Wave", order = 0)]
[Serializable]
public class WaveData : UniqueId
{
    [SerializeField] private List<EnemyWaveData> enemies;
}

[Serializable]
struct EnemyWaveData
{
    public CharacterData CharacterData;
    public float SpawnTime;
}
