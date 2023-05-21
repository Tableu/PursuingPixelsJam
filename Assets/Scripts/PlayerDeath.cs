using System;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private AudioSource death;

    private void OnDestroy()
    {
        death.Play();
        WaveSpawner.Instance.RestartButton.SetActive(true);
    }
}
