using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void OnDestroy()
    {
        ModifierManager.Instance.Restart();
        WaveSpawner.Instance.Restart();
    }
}
