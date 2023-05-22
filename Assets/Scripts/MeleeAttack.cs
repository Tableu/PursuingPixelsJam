using System.Collections;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private WeaponStats stats;
    [SerializeField] private AudioSource sword;
    [SerializeField] private string enemyTag;
    [SerializeField] private float knockback;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(enemyTag))
        {
            sword.Play();
            Health health = other.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(stats.damage);
            }

            HitStun hitStun = other.gameObject.GetComponent<HitStun>();
            if (hitStun != null)
            {
                hitStun.OnHit();
            }
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = (other.transform.position - transform.position).normalized;
                rb.AddForce(direction*knockback, ForceMode2D.Impulse);
            }
        }else if (other.CompareTag("Projectile"))
        {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            if (stats.ReflectProjectiles && rb != null)
            {
                rb.velocity *= -1;
            }
        }
    }

    
}
