using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 1;
    private GameObject _player;
    
    void Start()
    {   
        _player = GameObject.FindWithTag("Player");
        if (_player == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector2 direction = (_player.transform.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        transform.LookAt(_player.transform.position);
        transform.right = _player.transform.position - transform.position;
    }
}
