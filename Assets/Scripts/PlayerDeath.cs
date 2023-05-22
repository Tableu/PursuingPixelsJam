using System;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private AudioSource death;

    private void OnDestroy()
    {
        death.Play();
        if (WaveSpawner.Instance != null && WaveSpawner.Instance.RestartButton != null)
        {
            WaveSpawner.Instance.RestartButton.SetActive(true);
        }
    }
}
