using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController: MonoBehaviour
{
    public float moveSpeed = 1;

    private Rigidbody2D rbody;

    private void Awake_S()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start_S()
    {
        
    }

    // Update is called once per frame
    void Update_S()
    {
        Vector2 movementVector = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movementVector += Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementVector += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementVector += Vector2.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movementVector += Vector2.left;
        }
        //rbody.MovePosition(rbody.position + (movementVector.normalized * moveSpeed));
        rbody.AddForce(movementVector.normalized * currentMoveSpeed);
    }

    //ADD TAKE DAMAGE FUNCTION
}
