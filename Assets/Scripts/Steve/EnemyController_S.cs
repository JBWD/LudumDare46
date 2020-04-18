using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyController : MonoBehaviour
{
    public float moveSpeed = .06f;
    public float health = 10;

    private Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start_S()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update_S()
    {
        
    }
}
