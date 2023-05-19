using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject arrow;
    [SerializeField] private float interval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", interval, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Shoot()
    {
        GameObject g = Instantiate(arrow, transform.position, Quaternion.identity);
    }
}
