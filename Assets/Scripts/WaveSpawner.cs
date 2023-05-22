using System.Collections;
using Systems.Modifiers;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    private static WaveSpawner _instance;

    public static WaveSpawner Instance => _instance;
    
    [SerializeField] private LevelData levelData;
    [SerializeField] private Transform enemyParent;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject winText;
    [SerializeField] private GameObject quitButton;
    [SerializeField] private GameObject restartButton;

    private int _waveNumber = 0;
    private int _spawnCount = 0;

    public GameObject RestartButton => restartButton;
    public GameObject WinText => winText;
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
                _spawnCount = 0;
                ModifierManager.Instance.OpenWindow(SpawnWave);
            }
            else
            {
                GameObject player = GameObject.FindWithTag("Player");
                Destroy(player);
                winText.SetActive(true);
                quitButton.SetActive(true);
                restartButton.SetActive(true);
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

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            var health = player.GetComponent<Health>();
            if (health != null)
            {
                health.Heal(10000);
            }
        }
        winText.SetActive(false);
        quitButton.SetActive(false);
        restartButton.SetActive(false);
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
