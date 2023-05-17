using System;
using Systems;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Data", menuName = "Data/Character", order = 0)]
[Serializable]
public class CharacterData : UniqueId
{
    [Header("Stats")]
    [SerializeField] private int baseHealth;
    [SerializeField] private int baseSpeed;

    [Header("References")] 
    [SerializeField] private GameObject prefab;

    public int BaseHealth => baseHealth;
    public int BaseSpeed => baseSpeed;
    public GameObject Prefab => prefab;
}
