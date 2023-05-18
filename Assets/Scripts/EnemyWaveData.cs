using System;
using System.Collections.Generic;
using Systems;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Wave Data", menuName = "Data/Wave", order = 0)]
[Serializable]
public class EnemyWaveData : UniqueId
{
    [SerializeField] private List<EnemySpawnData> spawnData;

    public List<EnemySpawnData> SpawnData => spawnData;
}

[Serializable]
public struct EnemySpawnData
{
    public CharacterData EnemyData;
    public float SpawnTime;
    public Vector2 SpawnOffset;
}