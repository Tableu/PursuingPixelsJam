using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1;
    private GameObject _player;
    void Start()
    {   
        _player = GameObject.FindWithTag("Player");
        if (_player == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector2 direction = ((Vector2)(_player.transform.position - transform.position)).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        transform.LookAt(_player.transform.position);
        transform.right = _player.transform.position - transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(10);
            }
        }
        Destroy(gameObject);
    }
}
