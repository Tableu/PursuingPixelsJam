using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Vector3 offset;
    private Health _health;
    public void Initialize(Health health)
    {
        _health = health;
        health.OnHealthChanged += delegate
        {
            slider.value = health.PercentHealth;
        };
        
        health.OnDestroyed += delegate
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        };
    }

    private void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(_health.transform.position) + offset;
    }
}
