using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    public GameObject currencyPrefab;

    // Start is called before the first frame update
    void Start_S()
    {
        
    }

    // Update is called once per frame
    void Update_S()
    {
        
    }

    public void AddCurrency(int value)
    {
        currency += value;
    }
}
