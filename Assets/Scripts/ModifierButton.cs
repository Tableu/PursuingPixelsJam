using System;
using Systems.Modifiers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModifierButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Button button;

    public void Initialize(ModifierPair data, Action callback)
    {
        titleText.text = data.Title;
        descriptionText.text = data.Description;
        button.onClick.AddListener(delegate
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                data.Player.AttachNewModifer(player.GetComponent<ModifiableTarget>());
                ModifierManager.Instance.AddEnemyModifier(data.Enemy);
                callback?.Invoke();
                Destroy(gameObject.transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
        });
    }
}
