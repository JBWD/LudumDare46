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
    public float currentHealth;
    public float startingHealth = 1000;
    public float healthUpgradeAmount;
    public float shieldStrength = 0;
    public float shieldUpgradeAmount = 0;
    public float armorStrength = 0;
    public float armorUpgradeAmount = 0;


    // Start is called before the first frame update
    void Start_W()
    {
        currentHealth = startingHealth;
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


    public void UpdateTurtle(TurtleUpgradeValues value, int upgradeLevel)
    {
        switch (value)
        {
            case TurtleUpgradeValues.Armor1:
                armorStrength += armorUpgradeAmount;
                break;
            case TurtleUpgradeValues.Armor2:
                break;
            case TurtleUpgradeValues.Armor3:
                break;
            case TurtleUpgradeValues.Movement:
                break;
            case TurtleUpgradeValues.Strength:
                break;
            case TurtleUpgradeValues.Health:
                currentHealth += healthUpgradeAmount;
                startingHealth += healthUpgradeAmount;
                break;
            case TurtleUpgradeValues.Shield:
                shieldStrength += shieldUpgradeAmount;
                break;
        }
    }
}
