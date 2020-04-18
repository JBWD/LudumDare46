using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public partial class GameManager : MonoBehaviour
{

    public int currency = 0;
    public int lives = 4;


    Dictionary<PlayerUpgradeValues, int> playerUpgrades = new Dictionary<PlayerUpgradeValues, int>();
    Dictionary<TurtleUpgradeValues, int> turtleUpgrades = new Dictionary<TurtleUpgradeValues, int>();

    bool paused = false;

    public PlayerController player;
    public TurtleController turtle;




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
        player.UpdatePlayer(playerUpgrades);
    }
    public void UpdateTurtle()
    {
        turtle.UpdateTurtle(turtleUpgrades);
    }

    public void TogglePause()
    {
        //Determines the state of the pause and does the opposite
        if (paused)
            ResumeGame();
        else
            PauseGame();
    }
    public void PauseGame()
    {
        //Keeps Everything moving turns off PlayerController and TurtleController
        paused = true;
    }

    public void ResumeGame()
    {
        paused = false;
        //Keeps Everything moving turns on PlayerController and TurtleController
    }

}
