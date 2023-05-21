using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private GameObject restartButton;
    void OnClick()
    {
        ModifierManager.Instance.Restart();
        WaveSpawner.Instance.Restart();
    }
}
