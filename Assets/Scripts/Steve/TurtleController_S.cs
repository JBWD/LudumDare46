using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TurtleController : MonoBehaviour
{
    public float speedValue = .1f;
    private bool movingUp = true;
    private Vector2 movementVector;
    private Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start_S()
    {
        rbody = GetComponent<Rigidbody2D>();
        movementVector = GetMovementVector();
    }

    // Update is called once per frame
    void Update_S()
    {
        //Vector2 diffVector = transform.position - (Vector3)movementVector;
        transform.position = Vector3.Lerp(gameObject.transform.position, movementVector, speedValue);
        if (Mathf.Abs(transform.position.y - movementVector.y) < .1f)
        {
            //print("switch");
            movingUp = !movingUp;
            movementVector = GetMovementVector();
        }
    }

    private Vector2 GetMovementVector()
    {
        if (movingUp)
        {
            return new Vector2(-7, 3);
        }
        else
        {
            return new Vector2(-7, -3);
        }
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
