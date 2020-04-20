using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BossController : MonoBehaviour
{
    public enum State { Idle, Attacking, Moving, Stunned, Enter, Exit, Offscreen };
    public State currentState = State.Offscreen;

    public int health = 4000;
    public float moveSpeed = 1;
    public float stateChangeTimer = 3;
    private float stateChangeTimerCD;

    private int stateChangeCounter = 0;
    private int attackCounter = 0;
    private Vector2 movementVector;
    private Vector2 exitVector = new Vector2(14, 0);
    private Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start_S()
    {
        stateChangeTimerCD = stateChangeTimer;
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update_S()
    {
        if (currentState == State.Offscreen)
        {
            stateChangeTimerCD -= Time.deltaTime;
            if (stateChangeTimerCD < 0)
            {
                stateChangeTimerCD = stateChangeTimer;
                if (stateChangeCounter < 5)
                {
                    stateChangeCounter++;
                }
                else
                {
                    currentState = State.Enter;
                    movementVector = GetMovementVector();
                    stateChangeCounter = 0;
                    return;
                }
            }
        }

        else if (currentState == State.Enter)
        {
            Vector2 diffVector = rbody.position - movementVector;
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
                    currentState = State.Idle;
                    //gameObject.GetComponent<EnemyWeapon>().SetTarget(FindObjectOfType<TurtleController>().transform);
                }
            }
        }

        else if (currentState == State.Idle)
        {
            stateChangeTimerCD -= Time.deltaTime;
            if (stateChangeTimerCD < 0)
            {
                stateChangeTimerCD = stateChangeTimer;
                currentState = State.Attacking;
            }
        }

        else if (currentState == State.Attacking)
        {
            //Do something cool
            attackCounter++;
            if (attackCounter >= 2)
            {
                currentState = State.Exit;
                attackCounter = 0;
            }
            else
            {
                currentState = State.Idle;
            }
        }

        else if (currentState == State.Exit)
        {
            Vector2 diffVector = rbody.position - exitVector;
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
                    currentState = State.Offscreen;
                }
            }
        }
    }

    protected Vector2 GetMovementVector()
    {
        return new Vector2(7, Random.Range(-4.5f, 4.5f));
    }

    public void TakeDamage(float damage)
    {
        health -= (int)damage;
        if (health <= 0)
        {
            //DIE!!!!!!!
            //cool fun death effects go here
            //Instantiate(FindObjectOfType<GameManager>().currencyPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
            //End game probably
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile") && currentState != State.Offscreen)
        {
            TakeDamage(collision.GetComponent<Projectile>().damage);
        }
    }
}
