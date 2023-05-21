using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject _player;
    private CharacterStats _stats;
    
    // Start is called before the first frame update
    void Start()
    {
        _stats = GetComponent<CharacterStats>();
        _player = GameObject.FindWithTag("Player");
        if(_player != null)
        {   
            Vector2 direction = (_player.transform.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * _stats.speed;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_player != null)
        {
            Vector2 direction = (_player.transform.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * _stats.speed;
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
