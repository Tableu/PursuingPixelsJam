using UnityEngine;
// using UnityEngine.AudioSource;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private WeaponStats stats;
    [SerializeField] private AudioSource sword;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // print(gameObject.name);
            sword.Play();
            Health health = other.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(stats.damage);
            }
            
        }
    }
}
