using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    private void Awake_W()
    {

    }
   
    public float moveSpeedChanger = .5f;
    public float currentMoveSpeed = 2f;


    [System.Serializable]
    public class EquippedItems
    {
        public PlayerUpgradeValues upgradeEnum;
        public GameObject equippedObject;
    }

    public List<EquippedItems> items = new List<EquippedItems>();
    public int health;

    //Health
    public int startingTotalHealth = 4;
    public int currentTotalHealth = 4;
    public int healthUpgradeModifier = 3;
    //Shield
    public int startingBaseShield = 0;
    public int currentTotalShield = 0;
    public int currentShield = 0;



    // Start is called before the first frame update
    void Start_W()
    {
        for(int i = 0;i<items.Count;i++)
        {
            if (i == 0)
            {
                items[i].equippedObject.SetActive(true);
            }
            else
            {
                items[i].equippedObject.SetActive(false) ;
            }
        }
    }

    // Update is called once per frame
    void Update_W()
    {
        RotateToMouse();
    }


    public void TurnOnItem(PlayerUpgradeValues turtleUpgrade)
    {
        foreach (EquippedItems item in items)
        {
            if (item.upgradeEnum == turtleUpgrade)
            {
                item.equippedObject.SetActive(true);
            }
        }
    }
    public void TurnOffItem(PlayerUpgradeValues turtleUpgrade)
    {
        foreach (EquippedItems item in items)
        {
            if (item.upgradeEnum == turtleUpgrade)
            {
                item.equippedObject.SetActive(false);
            }
        }
    }

    public void UpdatePlayer(PlayerUpgradeValues value, int upgradeLevel)
    {
        
        switch (value)
        {
            case PlayerUpgradeValues.Weapon1:
                foreach(EquippedItems item in items)
                {
                    item.equippedObject.GetComponent<Weapon>().UpdateWeapon(upgradeLevel);
                }
                break;
            case PlayerUpgradeValues.Weapon2:
                foreach (EquippedItems item in items)
                {
                    item.equippedObject.GetComponent<Weapon>().UpdateWeapon(upgradeLevel);
                }
                break;
            case PlayerUpgradeValues.Weapon3:
                foreach (EquippedItems item in items)
                {
                    item.equippedObject.GetComponent<Weapon>().UpdateWeapon(upgradeLevel);
                }
                break;
            case PlayerUpgradeValues.Armor1:
                break;
            case PlayerUpgradeValues.Armor2:
                break;
            case PlayerUpgradeValues.Armor3:
                break;
            case PlayerUpgradeValues.Movement:
                currentMoveSpeed = moveSpeed * moveSpeedChanger * upgradeLevel;
                break;
            case PlayerUpgradeValues.Strength:
                break;
            case PlayerUpgradeValues.Health:
                int diff = currentTotalHealth - health;
                currentTotalHealth = startingTotalHealth + upgradeLevel * healthUpgradeModifier;
                health = currentTotalHealth - diff;
                break;
            case PlayerUpgradeValues.Shield:
                break;
        }
        
    }

    public void TakeDamage(int damage)
    {
        if(currentShield > 0)
        {
            if(currentShield - damage <0)
            {
                currentShield = 0;
                health -= currentShield - damage;
            }
            else
            {
                currentShield -= damage;
            }
        }
        else
        {
            health -= damage; 
        }

        if (health < 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    public void RemoveDamage(int damage)
    {
        health += damage;
        if(health > currentTotalHealth)
        {
            health = currentTotalHealth;
        }
    }

    public void RotateToMouse()
    {
        Vector2 mousePos = Input.mousePosition;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z - Camera.main.transform.position.z));

        transform.rotation = Quaternion.Euler(0,0, Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x)) * Mathf.Rad2Deg + -90);
    }

    public void SwapWeapon()
    {
        int currentWeapon = 0;
        for(int i = 0;i<items.Count;i++)
        {
            if(items[i].equippedObject.activeInHierarchy)
            {
                currentWeapon = i;
                break;
            }
        }
        
        currentWeapon++;
        if(currentWeapon == items.Count)
        {
            currentWeapon = 0;
        }
        for(int i = 0;i<items.Count;i++)
        {
            if (i == currentWeapon)
                items[i].equippedObject.SetActive(true);
            else
            {
                items[i].equippedObject.SetActive(false);
            }
        }
       

    }

}
