using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void OnClick()
    {
        ModifierManager.Instance.Restart();
        WaveSpawner.Instance.Restart();
    }
}
