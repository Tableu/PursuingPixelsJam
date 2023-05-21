using System;
using Systems.Modifiers;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Health : ModifiableTarget
{
    internal ModifiableStat maxHealth;
    private bool _healthDirty;
    public float CurrentHealth => PercentHealth * maxHealth.CurrentValue;
    public float PercentHealth { get; protected set; } = 1f;

    public void Initialize(CharacterStats stats)
    {
        maxHealth = new ModifiableStat(stats.Data.BaseHealth);
        HealthBarSpawner.Instance.SpawnHealthBar(this);
    }
    
    private void Update()
    {
        if (_healthDirty)
        {
            _healthDirty = false;
            OnHealthChanged?.Invoke();
        }
    }
    
    public void TakeDamage(float damage)
    {
        PercentHealth -= damage / maxHealth;
        PercentHealth = Mathf.Min(PercentHealth, 1);
        _healthDirty = true;
        if (CurrentHealth <= 0.01)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(float amount)
    {
        PercentHealth += amount / maxHealth;
        PercentHealth = Mathf.Min(PercentHealth, 1);
        _healthDirty = true;
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke();
    }

    public event Action OnDestroyed;
    public event Action OnHealthChanged;
    
    #if UNITY_EDITOR
    [ContextMenu("Test Damage")]
    public void TestDamage()
    {
        TakeDamage(10);
    }
    #endif
}
