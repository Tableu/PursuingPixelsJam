using Systems.Modifiers;
using UnityEngine;

public class CharacterStats : ModifiableTarget
{
    [SerializeField] private CharacterData characterData;
    private bool _initialized = false;
    internal ModifiableStat speed;
    internal ModifiableStat attackSpeed;
    internal ModifiableStat scale;
    public CharacterData Data => characterData;
    public void Start()
    {
        if (!_initialized && characterData != null)
        {
            Initialize();
        }
    }

    public void Initialize(CharacterData data)
    {
        characterData = data;
        Initialize();
    }

    private void Initialize()
    {
        _initialized = true;
        var health = gameObject.AddComponent<Health>();
        health.Initialize(this);
        speed = new ModifiableStat(characterData.BaseSpeed);
        attackSpeed = new ModifiableStat(characterData.BaseAttackSpeed);
        scale = new ModifiableStat(1);
    }
}
