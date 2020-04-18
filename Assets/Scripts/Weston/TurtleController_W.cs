using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class TurtleController : MonoBehaviour
{
    [System.Serializable]
    public class EquippedItems
    {
        public TurtleUpgradeValues upgradeEnum;
        public GameObject equippedObject;

    }

    public List<EquippedItems> items = new List<EquippedItems>();
    public int health;




    // Start is called before the first frame update
    void Start_W()
    {
        
    }

    // Update is called once per frame
    void Update_W()
    {
        
    }


    public void TurnOnItem(TurtleUpgradeValues turtleUpgrade)
    {
        foreach(EquippedItems item in items)
        {
            if(item.upgradeEnum == turtleUpgrade)
            {
                item.equippedObject.SetActive(true);
            }
        }
    }
    public void TurnOffItem(TurtleUpgradeValues turtleUpgrade)
    {
        foreach (EquippedItems item in items)
        {
            if (item.upgradeEnum == turtleUpgrade)
            {
                item.equippedObject.SetActive(false);
            }
        }
    }


    public void UpdateTurtle(Dictionary<TurtleUpgradeValues, int> upgrades)
    {
        foreach(KeyValuePair<TurtleUpgradeValues,int> upgrade in upgrades)
        {
            
        }
    }
}
