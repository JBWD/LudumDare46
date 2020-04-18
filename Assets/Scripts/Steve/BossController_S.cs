using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BossController : MonoBehaviour
{
    public enum State { Idle, Attacking, Moving, Stunned, Enter, Exit, Offscreen };
    public State currentState = State.Offscreen;
    public float stateChangeTimer = 3;
    
    // Start is called before the first frame update
    void Start_S()
    {
        
    }

    // Update is called once per frame
    void Update_S()
    {
        
    }

}
