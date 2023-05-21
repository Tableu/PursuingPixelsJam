using UnityEngine;
// using UnityEngine.AudioSource;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private WeaponStats stats;
    [SerializeField] private AudioSource sword;
    [SerializeField] private string enemyTag;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(enemyTag))
        {
            // print(gameObject.name);
            sword.Play();
            Health health = other.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(stats.damage);
            }

            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(new Vector2(100,100), ForceMode2D.Impulse);
            }
        }
    }
}
