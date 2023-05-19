using System;
using Systems;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Data", menuName = "Data/Character", order = 0)]
[Serializable]
public class CharacterData : UniqueId
{
    [Header("Stats")]
    [SerializeField] private int baseHealth;
    [SerializeField] private float baseSpeed;
    [SerializeField] private float baseAttackSpeed;

    [Header("References")] 
    [SerializeField] private GameObject prefab;

    public int BaseHealth => baseHealth;
    public float BaseSpeed => baseSpeed;
    public float BaseAttackSpeed => baseAttackSpeed;
    public GameObject Prefab => prefab;
}
