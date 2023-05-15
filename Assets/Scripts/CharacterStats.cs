using System;
using Systems.Modifiers;
using UnityEngine;

public class CharacterStats : ModifiableTarget
{
    [SerializeField] private CharacterData characterData;
    internal ModifiableStat speed;
    public CharacterData Data => characterData;
    public void Start()
    {
        if (characterData != null)
        {
            Initialize(characterData);
        }
    }

    public void Initialize(CharacterData data)
    {
        var health = gameObject.AddComponent<Health>();
        health.Initialize(this);
        speed = new ModifiableStat(data.BaseSpeed);
    }
    
    
}
