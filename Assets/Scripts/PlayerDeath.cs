using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject restartButton;
    [SerializeField] private AudioSource death;

    private void OnDestroy()
    {
        death.Play();
        restartButton.SetActive(true);
        // ModifierManager.Instance.Restart();
        // WaveSpawner.Instance.Restart();
    }
}
