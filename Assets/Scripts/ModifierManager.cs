using System;
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
    private List<ModifierData> enemyModifiers = new List<ModifierData>();

    public List<ModifierData> EnemyModifiers => enemyModifiers;

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

    public void AddEnemyModifier(ModifierData data)
    {
        enemyModifiers.Add(data);
    }

    public void OpenWindow(Action callback)
    {
        GameObject panel = Instantiate(modifierPanel, canvas.transform);
        ModifierStage stage = modifierStages.Modifiers[_modifierIndex];
        _modifierIndex++;
        List<ModifierPair> modifiers = stage.Data.GetRandomModifiers(stage.Count);
        for (int i = 0; i < stage.Count; i++)
        {
            var button = Instantiate(modifierButton, panel.transform);
            ModifierButton script = button.GetComponent<ModifierButton>();
            script.Initialize(modifiers[i], callback);
        }
    }
#if UNITY_EDITOR
    [ContextMenu("Test Open Window")]
    public void TestOpenWindow()
    {
        OpenWindow(null);
    }
    #endif
}
