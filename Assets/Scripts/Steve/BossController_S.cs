using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BossController : MonoBehaviour
{
    public enum State { Idle, Attacking, Moving, Stunned, Enter, Exit, Offscreen };
    public State currentState = State.Offscreen;

    public int health = 4000;
    public float fireRate = .5f;
    private float fireRateCD;
    public float moveSpeed = 1;
    public float stateChangeTimer = 3;
    private float stateChangeTimerCD;

    private int stateChangeCounter = 0;
    private int attackCounter = 0;
    private Vector2 movementVector;
    private Vector2 exitVector = new Vector2(20, 0);
    private Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start_S()
    {
        stateChangeTimerCD = stateChangeTimer;
        fireRateCD = fireRate;
        GetComponent<BoxCollider2D>().enabled = false;
        rbody = GetComponent<Rigidbody2D>();
        gameObject.GetComponent<EnemyWeapon>().SetTarget(FindObjectOfType<TurtleController>().transform);
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
                    FindObjectOfType<EnemySpawner>().paused = true;
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
                    GetComponent<BoxCollider2D>().enabled = true;
                    currentState = State.Idle;
                }
            }
        }

        else if (currentState == State.Idle)
        {
            stateChangeTimerCD -= Time.deltaTime;
            if (stateChangeTimerCD < 0)
            {
                stateChangeTimerCD = stateChangeTimer;
                currentState = State.Moving;
            }
        }

        else if (currentState == State.Moving)
        {
            //transform.position = Vector3.Lerp(gameObject.transform.position, new Vector2(gameObject.transform.position.x, 4.5f), moveSpeed);
            Vector2 diffVector = rbody.position - new Vector2(gameObject.transform.position.x, 4.5f);
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
                    currentState = State.Attacking;
                }
            }
            //if (Mathf.Abs(transform.position.y - 4.5f) < .1f)
            //{
            //    currentState = State.Attacking;
            //}
        }

        else if (currentState == State.Attacking)
        {
            Vector2 diffVector = rbody.position - new Vector2(gameObject.transform.position.x, -4.5f);
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
                    attackCounter++;
                    if (attackCounter >= 2)
                    {
                        GetComponent<BoxCollider2D>().enabled = false;
                        FindObjectOfType<EnemySpawner>().paused = false;
                        currentState = State.Exit;
                        attackCounter = 0;
                    }
                    else
                    {
                        currentState = State.Idle;
                    }
                }
            }

            print("attacking");
            fireRateCD -= Time.deltaTime;
            if (fireRateCD < 0)
            {
                fireRateCD = fireRate;
                gameObject.GetComponent<EnemyWeapon>().Fire();
            }
            
            //if (Mathf.Abs(transform.position.y - -4.5f) < .1f)
            //{
            //    attackCounter++;
            //    if (attackCounter >= 2)
            //    {
            //        currentState = State.Exit;
            //        attackCounter = 0;
            //    }
            //    else
            //    {
            //        currentState = State.Idle;
            //    }
            //}
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
        //Color original = GetComponentInChildren<SpriteRenderer>().color;
        float ElapsedTime = 0;
        float TotalTime = .1f;
        while (ElapsedTime < TotalTime)
        {
            ElapsedTime += Time.deltaTime;
            GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, (ElapsedTime / TotalTime));
            yield return new WaitForEndOfFrame();
        }
        ElapsedTime = 0;
        while (ElapsedTime < TotalTime)
        {
            ElapsedTime += Time.deltaTime;
            GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.red, Color.white, (ElapsedTime / TotalTime));
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
