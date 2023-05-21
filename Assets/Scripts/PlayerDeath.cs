using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void OnDestroy()
    {
        if (ModifierManager.Instance != null)
        {
            ModifierManager.Instance.Restart();
        }

        if (WaveSpawner.Instance != null)
        {
            WaveSpawner.Instance.Restart();
        }
    }
}
