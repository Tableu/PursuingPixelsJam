using System.Collections.Generic;
using Systems.Modifiers;
using UnityEngine;

public class ModifierManager : MonoBehaviour
{
    private static ModifierManager _instance;

    public static ModifierManager Instance => _instance;

    [SerializeField] private GameObject modifierPanel;
    [SerializeField] private GameObject modifierButton;
    [SerializeField] private ModifierStages modifierStages;
    [SerializeField] private GameObject canvas;

    private int _modifierIndex;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void OpenWindow()
    {
        GameObject panel = Instantiate(modifierPanel, canvas.transform);
        ModifierStage stage = modifierStages.Modifiers[_modifierIndex];
        _modifierIndex++;
        List<ModifierData> modifiers = stage.Data.GetRandomModifiers(stage.Count);
        for (int i = 0; i < stage.Count; i++)
        {
            var button = Instantiate(modifierButton, panel.transform);
            ModifierButton script = button.GetComponent<ModifierButton>();
            script.Initialize(modifiers[i]);
        }
    }
    #if UNITY_EDITOR
    [ContextMenu("Test Open Window")]
    public void TestOpenWindow()
    {
        OpenWindow();
    }
    #endif
}
