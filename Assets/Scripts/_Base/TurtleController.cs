using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TurtleController : MonoBehaviour
{
   




    // Start is called before the first frame update
    void Start()
    {
        Start_W();
        Start_S();
    }

    // Update is called once per frame
    void Update()
    {
        Update_W();
        Update_S();
    }

}
