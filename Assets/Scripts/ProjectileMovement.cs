using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 1;
    private GameObject gameObject;
    
    // Start is called before the first frame update
    void Start()
    {   
        gameObject = GameObject.FindWithTag("Player");
        if(gameObject != null)
        {   
            Vector3 v3 = (gameObject.transform.position - transform.position).normalized;
            Vector2 v2 = new Vector2(v3.x, v3.y);
            GetComponent<Rigidbody2D>().velocity = v2 * speed;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
