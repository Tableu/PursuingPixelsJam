using UnityEngine;

public class HealthBarSpawner : MonoBehaviour
{
    private static HealthBarSpawner _instance;

    public static HealthBarSpawner Instance => _instance;

    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject healthBarPrefab;
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

    public void SpawnHealthBar(Health health)
    {
        var healthBar = Instantiate(healthBarPrefab, canvas.transform);
        var script = healthBar.GetComponent<HealthBar>();
        script.Initialize(health);
    }
}
