using Systems.Modifiers;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    [SerializeField] private WeaponData weaponData;
    internal ModifiableStat cooldown;
    internal ModifiableStat damage;
    internal ModifiableStat projectileSpeed;

    private void Awake()
    {
        cooldown = new ModifiableStat(weaponData.BaseCooldown);
        damage = new ModifiableStat(weaponData.BaseDamage);
        projectileSpeed = new ModifiableStat(weaponData.BaseProjectileSpeed);
    }
}
