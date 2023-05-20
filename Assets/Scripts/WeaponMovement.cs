using System;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    [SerializeField] private float radius;
    private CharacterStats _stats;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = Vector3.right * radius;
    }

    private void Update()
    {
        Vector2 targetVector = Camera.main.WorldToScreenPoint(transform.parent.position);
        targetVector = (Vector2)Input.mousePosition - targetVector;

        transform.position = (Vector2) transform.parent.position + targetVector.normalized * radius;
        
        var angle = Mathf.Atan2(targetVector.y, targetVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
