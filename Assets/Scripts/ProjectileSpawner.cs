using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject arrow;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private WeaponStats weaponStats;

    private CharacterStats _stats;
    // Start is called before the first frame update
    void Start()
    {
        _stats = GetComponent<CharacterStats>();
        InvokeRepeating("Shoot", 1/_stats.attackSpeed, 1/_stats.attackSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Shoot()
    {
        GameObject g = Instantiate(arrow, spawnPos.position, Quaternion.identity);
        var p = g.GetComponent<Projectile>();
        p.Initialize(weaponStats.projectileSpeed);
    }
}
