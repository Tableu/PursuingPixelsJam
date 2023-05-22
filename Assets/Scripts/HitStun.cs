using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStun : MonoBehaviour
{
    public EnemyMovement EnemyMovement;
    public PlayerMovement PlayerMovement;

    public void OnHit()
    {
        StartCoroutine(Stun());
    }
    private IEnumerator Stun()
    {
        if (EnemyMovement != null)
        {
            EnemyMovement.enabled = false;
        }

        if (PlayerMovement != null)
        {
            PlayerMovement.enabled = false;
        }

        yield return new WaitForSeconds(0.4f);
        
        if (EnemyMovement != null)
        {
            EnemyMovement.enabled = true;
        }

        if (PlayerMovement != null)
        {
            PlayerMovement.enabled = true;
        }
    }
}
