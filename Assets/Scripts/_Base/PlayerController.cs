using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    private void Awake()
    {
        Awake_S();
        Awake_W();
    }

    // Start is called before the first frame update
    void Start()
    {
        Start_S();
        Start_W();
    }

    // Update is called once per frame
    void Update()
    {
        Update_S();
        Update_W();
    }
}
