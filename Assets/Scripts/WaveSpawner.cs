using System.Collections;
using Systems.Modifiers;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    private static WaveSpawner _instance;

    public static WaveSpawner Instance => _instance;
    
    [SerializeField] private LevelData levelData;
    [SerializeField] private Transform enemyParent;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject playerPrefab;

    private int _waveNumber = 0;
    private int _spawnCount = 0;
    private void Start()
    {
        SpawnWave();
    }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void FixedUpdate()
    {
        if (enemyParent.childCount == 0 && _waveNumber < levelData.WaveData.Count && levelData.WaveData[_waveNumber].SpawnData.Count == _spawnCount)
        {
            _waveNumber++;
            if (_waveNumber < levelData.WaveData.Count)
            {
                ModifierManager.Instance.OpenWindow(SpawnWave);
            }
            else
            {
                GameObject player = GameObject.FindWithTag("Player");
                Destroy(player);
            }
        }
    }

    public void Restart()
    {
        _waveNumber = 0;
        _spawnCount = 0;
        foreach (Transform child in enemyParent.transform)
        {
            Destroy(child.gameObject);
        }
        Instantiate(playerPrefab);
        SpawnWave();
    }

    public void SpawnWave()
    {
        if (_waveNumber >= levelData.WaveData.Count)
        {
            Debug.Log("Error: Wave Index out of range");
            return;
        }
        _spawnCount = 0;
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
    }

    private void SpawnEnemy(EnemySpawnData data)
    {
        _spawnCount++;
        GameObject enemy = Instantiate(data.EnemyData.Prefab, (Vector2)spawnPos.position + data.SpawnOffset,Quaternion.identity,enemyParent);
        CharacterStats stats = enemy.GetComponent<CharacterStats>();
        if (stats == null)
        {
            Destroy(enemy);
            Debug.Log("Error: Enemy does not have a CharacterStats class");
            return;
        }
        stats.Initialize(data.EnemyData);
        foreach(ModifierData md in ModifierManager.Instance.EnemyModifiers)
        {
            md.AttachNewModifer(stats);
        }
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
