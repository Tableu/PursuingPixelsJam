using UnityEngine;

namespace Systems.Modifiers
{
    public class ModiferAdder : MonoBehaviour
    {
        public ModifiableTarget Target;
        public ModifierData Modifier;

        public void AddSelectedModifer()
        {
            Modifier.AttachNewModifer(Target);
        }
        #if UNITY_EDITOR
        [ContextMenu("AddModifer")]
        public void AddModifer()
        {
            AddSelectedModifer();
        }
        #endif
    }
}
