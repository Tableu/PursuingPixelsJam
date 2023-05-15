using Systems.Modifiers;
using UnityEngine;

public class CharacterStats : ModifiableTarget
{
    [SerializeField] private CharacterData characterData;
    internal ModifiableStat health;
    internal ModifiableStat speed;

    public void Start()
    {
        if (characterData != null)
        {
            Initialize(characterData);
        }
    }

    public void Initialize(CharacterData data)
    {
        health = new ModifiableStat(data.BaseHealth);
        speed = new ModifiableStat(data.BaseSpeed);
    }
}
