using Systems.Modifiers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModifierButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Button button;

    public void Initialize(ModifierData data)
    {
        titleText.text = data.ModiferName;
        descriptionText.text = data.ModiferDescription;
        button.onClick.AddListener(delegate
        {
            data.AttachNewModifer(GameObject.FindWithTag("Player").GetComponent<ModifiableTarget>());
            Destroy(gameObject.transform.parent.gameObject);
        });
    }
}
