using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyController : MonoBehaviour
{
    public float moveSpeed = .06f;
    public int health = 10;

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
        movementVector = GetMovementVector();
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
        movementVector = GetMovementVector();
        state = State.Moving;
    }

    protected Vector2 GetMovementVector()
    {
        return new Vector2(Random.Range(2f, 8f), Random.Range(-4.5f, 4.5f));
    }

    public void TakeDamage(float damage)
    {
        health -= (int)damage;
        if (health <= 0)
        {
            //DIE!!!!!!!
            //cool fun death effects go here
            Instantiate(FindObjectOfType<GameManager>().currencyPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine("ShowHit");
        }
        //print(gameObject.name + " took " + damage + " damage!");
    }

    protected IEnumerator ShowHit()
    {
        Color original = GetComponentInChildren<SpriteRenderer>().color;
        float ElapsedTime = 0;
        float TotalTime = .1f;
        while (ElapsedTime < TotalTime)
        {
            ElapsedTime += Time.deltaTime;
            GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(original, new Color(1, 0, 0, 1f), (ElapsedTime / TotalTime));
            yield return new WaitForEndOfFrame();
        }
        ElapsedTime = 0;
        while (ElapsedTime < TotalTime)
        {
            ElapsedTime += Time.deltaTime;
            GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(new Color(1, 0, 0, 1f), original, (ElapsedTime / TotalTime));
            yield return new WaitForEndOfFrame();
        }
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
