using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private LevelData levelData;
    [SerializeField] private Transform enemyParent;
    [SerializeField] private Transform spawnPos;

    private int _waveNumber = 0;

    public void SpawnWave()
    {
        if (_waveNumber >= levelData.WaveData.Count)
        {
            Debug.Log("Error: Wave Index out of range");
            return;
        }
        foreach (EnemySpawnData data in levelData.WaveData[_waveNumber].SpawnData)
        {
            if (data.SpawnTime <= 0)
            {
                SpawnEnemy(data);
            }
            else
            {
                StartCoroutine(WaitAndSpawn(data.SpawnTime, data));
            }
        }
        _waveNumber++;
    }

    private void SpawnEnemy(EnemySpawnData data)
    {
        GameObject enemy = Instantiate(data.EnemyData.Prefab, (Vector2)spawnPos.position + data.SpawnOffset,Quaternion.identity,enemyParent);
        CharacterStats stats = enemy.GetComponent<CharacterStats>();
        if (stats == null)
        {
            Destroy(enemy);
            Debug.Log("Error: Enemy does not have a CharacterStats class");
            return;
        }
        stats.Initialize(data.EnemyData);
    }

    IEnumerator WaitAndSpawn(float duration, EnemySpawnData data)
    {
        yield return new WaitForSeconds(duration);
        SpawnEnemy(data);
    }
    
    #if UNITY_EDITOR
    [ContextMenu("Test Wave Spawn")]
    public void TestWaveSpawn()
    {
        SpawnWave();
    }
    #endif

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
