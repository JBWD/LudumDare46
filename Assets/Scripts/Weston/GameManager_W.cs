using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{

    public int currency = 0;
    public int lives = 4;

    public enum PlayerUpgradeValues
    {
        Weapon1,
        Weapon2,
        Weapon3,
        Armor1,
        Armor2,
        Armor3,
        Movement,
        Strength,
        Health,
        Shield
    }

    public enum TurtleUpgradeValues
    {
        Weapon1,
        Weapon2,
        Weapon3,
        Armor1,
        Armor2,
        Armor3,
        Movement,
        Strength,
        Health,
        Shield
    }


    Dictionary<PlayerUpgradeValues, int> playerUpgrades = new Dictionary<PlayerUpgradeValues, int>();
    Dictionary<TurtleUpgradeValues, int> turtleUpgrades = new Dictionary<TurtleUpgradeValues, int>();



    // Start is called before the first frame update
    void Start_W()
    {
        
    }

    // Update is called once per frame
    void Update_W()
    {
        
    }


    public bool AddPlayerUpgrade(PlayerUpgradeValues upgrade, int cost)
    {
        if(currency < cost)
        {
            return false;
        }
        if (playerUpgrades.ContainsKey(upgrade))
        {           
            playerUpgrades[upgrade] = playerUpgrades[upgrade] +1;
            
        }
        else
        {
            playerUpgrades.Add(upgrade, 1);
        }
        currency -= cost;
        UpdatePlayer();
        return true;
    }

    public bool SubtractPlayerUpgrade(PlayerUpgradeValues upgrade, int cost)
    {

        if (playerUpgrades.ContainsKey(upgrade) && playerUpgrades[upgrade]>0)
        {
            playerUpgrades[upgrade] = playerUpgrades[upgrade] - 1;
            currency += cost;
            UpdateTurtle();
            return true;
        }
        else
            return false;
       
    }


    public void UpdatePlayer()
    {
       
    }
    public void UpdateTurtle()
    {

    }
    
}
