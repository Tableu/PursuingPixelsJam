using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Collision with wall");
        if(collision.gameObject.tag != "Enemy")
            Destroy(gameObject);
    }
}

