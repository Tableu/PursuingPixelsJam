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

            EnemyMovement enemyMovement = other.gameObject.GetComponent<EnemyMovement>();
            PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            StartCoroutine(HitStun(enemyMovement, playerMovement));
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

    private IEnumerator HitStun(EnemyMovement enemyMovement, PlayerMovement playerMovement)
    {
        if (enemyMovement != null)
        {
            enemyMovement.enabled = false;
        }

        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        yield return new WaitForSeconds(0.4f);
        
        if (enemyMovement != null)
        {
            enemyMovement.enabled = true;
        }

        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }
    }
}
