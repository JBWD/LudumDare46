using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyController : MonoBehaviour
{
    public float moveSpeed = .06f;
    public float health = 10;

    public float changeTimer = 2;
    private float changeTimerCD;

    [Range(0, 100)]
    public float attackChance = 50;
    
    public enum State { Moving, Idle, Attacking };
    public State state = State.Moving;

    private Rigidbody2D rbody;
    private Vector2 movementVector;

    // Start is called before the first frame update
    void Start_S()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
        movementVector = new Vector2(Random.Range(2f, 8f), Random.Range(-4.5f, 4.5f));
        changeTimerCD = changeTimer;
        Mathf.Clamp(attackChance, 0, 100);
    }

    // Update is called once per frame
    void Update_S()
    {
        if (state == State.Moving)
        {
            Vector2 diffVector = rbody.position - movementVector;
            //print(diffVector.magnitude);
            if (diffVector.magnitude > 1)
            {
                rbody.MovePosition(rbody.position - diffVector.normalized * moveSpeed);
            }
            else
            {
                if (diffVector.magnitude > .01)
                {
                    rbody.MovePosition(rbody.position - diffVector * moveSpeed);
                }
                else
                {
                    state = State.Idle;
                    gameObject.GetComponent<EnemyWeapon>().SetTarget(FindObjectOfType<TurtleController>().transform);
                    return;
                }
            }
        }
        else if (state == State.Idle)
        {
            changeTimerCD -= Time.deltaTime;
            if (changeTimerCD < 0)
            {
                changeTimerCD = changeTimer;
                float chance = Random.Range(0, 100);
                if (chance <= attackChance)
                {
                    Attack();
                    
                }
            }
        }
    }

    protected void Attack()
    {
        //print(gameObject.name + " attacks!");
        gameObject.GetComponent<EnemyWeapon>().Fire();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Boundary") || collision.gameObject.CompareTag("Enemy"))
        {
            //print(collision.gameObject.tag);
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            TakeDamage(collision.GetComponent<Projectile>().damage);
        }
    }
}
