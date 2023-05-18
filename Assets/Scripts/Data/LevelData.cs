using System;

using System.Collections.Generic;
using Systems;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Data", menuName = "Data/Level", order = 0)]
[Serializable]
public class LevelData : UniqueId
{
    [SerializeField] private List<EnemyWaveData> waveData;

    public List<EnemyWaveData> WaveData => waveData;
}


