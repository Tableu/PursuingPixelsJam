using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject _player;
    private CharacterStats _stats;
    private Rigidbody2D _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        if(_player != null)
        {   
            _rb = GetComponent<Rigidbody2D>();
            _stats = GetComponent<CharacterStats>();
            Vector2 direction = (_player.transform.position - transform.position).normalized;
            _rb.velocity = direction * _stats.speed;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_player != null)
        {
            Vector2 direction = (_player.transform.position - transform.position).normalized;
            _rb.AddForce(direction*_stats.speed, ForceMode2D.Impulse);
            var velocity = _rb.velocity;
            if (Mathf.Abs(_rb.velocity.x) > _stats.speed)
            {
                velocity.x = Mathf.Sign(_rb.velocity.x)*_stats.speed;
            }
            if (Mathf.Abs(_rb.velocity.y) > _stats.speed)
            {
                velocity.y = Mathf.Sign(_rb.velocity.y)*_stats.speed;
            }
            _rb.velocity = velocity;
            if (direction.x > 0)
            {
                transform.rotation = Quaternion.Euler(0,0,0);
            }
            else if(direction.x < 0)
            {
                transform.rotation = Quaternion.Euler(0,180,0);
            }
        }
    }
}
