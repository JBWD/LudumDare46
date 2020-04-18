using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{


    Dictionary<string, int> playerUpgrades = new Dictionary<string, int>();
    Dictionary<string, int> turtleUpgrades = new Dictionary<string, int>();



    // Start is called before the first frame update
    void Start()
    {
        Start_W();    
    }

    // Update is called once per frame
    void Update()
    {
        Update_W();
    }
}
