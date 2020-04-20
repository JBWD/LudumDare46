using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CCS.SoundPlayer;
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

    public AudioClip MenuMusic,
        InGameMusic;


    // Start is called before the first frame update
    void Start_W()
    {
        PlayMenuMusic();
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
            Debug.Log("Upgraded Player");
        }
        else
        {
            playerUpgrades.Add(upgrade, 1);
        }
        currency -= cost;
        UpdatePlayer(upgrade,playerUpgrades[upgrade]);
        return true;
    }

    public bool SubtractPlayerUpgrade(PlayerUpgradeValues upgrade, int cost)
    {

        if (playerUpgrades.ContainsKey(upgrade) && playerUpgrades[upgrade]>0)
        {
            playerUpgrades[upgrade] = playerUpgrades[upgrade] - 1;
            currency += cost;
            UpdatePlayer(upgrade,playerUpgrades[upgrade]);
            return true;
        }
        else
            return false;
       
    }
    public bool AddTurtleUpgrade(TurtleUpgradeValues upgrade, int cost)
    {
        if (currency < cost)
        {
            return false;
        }
        if (turtleUpgrades.ContainsKey(upgrade))
        {
            turtleUpgrades[upgrade] = turtleUpgrades[upgrade] + 1;

        }
        else
        {
            turtleUpgrades.Add(upgrade, 1);
        }
        currency -= cost;
        UpdateTurtle(upgrade,turtleUpgrades[upgrade]);
        Debug.Log("Upgraded Turtle");
        return true;
    }

    public bool SubtractTurtleUpgrade(TurtleUpgradeValues upgrade, int cost)
    {

        if (turtleUpgrades.ContainsKey(upgrade) && turtleUpgrades[upgrade] > 0)
        {
            turtleUpgrades[upgrade] = turtleUpgrades[upgrade] - 1;
            currency += cost;
            UpdateTurtle(upgrade, turtleUpgrades[upgrade]);
            return true;
        }
        else
            return false;

    }

    public void UpdatePlayer(PlayerUpgradeValues upgrade, int level)
    {
        player.UpdatePlayer(upgrade, level);
    }
    public void UpdateTurtle(TurtleUpgradeValues upgrade, int level)
    {
        turtle.UpdateTurtle(upgrade,level);
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

    public int GetCurrentUpgradeLevel(TurtleUpgradeValues upgrade)
    {
        if (turtleUpgrades.ContainsKey(upgrade))
            return turtleUpgrades[upgrade];
        return 0;
    }

    public int GetCurrentUpgradeLevel(PlayerUpgradeValues upgrade)
    {
        if (playerUpgrades.ContainsKey(upgrade))
            return playerUpgrades[upgrade];
        return 0;
    }


    public void GameOver()
    {
        //Display the GameOverScreen;
    }

    public void PlayMenuMusic()
    {
        SoundManager.Instance.TransitionSound(MixerPlayer.Music, MenuMusic, 1, 2);
    }
    public void PlayInGameMusic()
    {
        SoundManager.Instance.TransitionSound(MixerPlayer.Music, InGameMusic, 1, 2);
    }

    public void SwapPlayerWeapon()
    {
        player.SwapWeapon();
    }

    public bool OverUI()
    {
        return UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
    }
}
