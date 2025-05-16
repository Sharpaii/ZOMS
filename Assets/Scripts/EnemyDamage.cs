using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    
    public int textDisplay = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // var healthComponent = gameObject.GetComponent<Health>();
            // healthComponent.takeDamage(10);
            Destroy(gameObject.GetComponent("Enemy"));
        }
    }
}
