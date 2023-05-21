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
        titleText.text = data.Player.ModiferName;
        descriptionText.text = data.Player.ModiferDescription;
        button.onClick.AddListener(delegate
        {
            data.Player.AttachNewModifer(GameObject.FindWithTag("Player").GetComponent<ModifiableTarget>());
            ModifierManager.Instance.AddEnemyModifier(data.Enemy);
            callback?.Invoke();
            Destroy(gameObject.transform.parent.gameObject);
        });
    }
}
