using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TurtleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start_S()
    {
        
    }

    // Update is called once per frame
    void Update_S()
    {
        
    }

    protected void TakeDamage(float damage)
    {
        
        health -= damage;
        if (health <= 0)
        {
            //DIE!!!!!!!
            //cool fun death effects go here
            Destroy(gameObject);
        }
        //print(gameObject.name + " took " + damage + " damage!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            TakeDamage(collision.GetComponent<Projectile>().damage);
        }
    }
}
