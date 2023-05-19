using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 1;
    private GameObject _player;
    
    // Start is called before the first frame update
    void Start()
    {   
        _player = GameObject.FindWithTag("Player");
        if(_player != null)
        {   
            Vector3 v3 = (_player.transform.position - transform.position).normalized;
            Vector2 v2 = new Vector2(v3.x, v3.y);
            GetComponent<Rigidbody2D>().velocity = v2 * speed;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
