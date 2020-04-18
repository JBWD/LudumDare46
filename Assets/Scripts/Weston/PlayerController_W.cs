using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    private void Awake_W()
    {

    }
    [System.Serializable]
    public class EquippedItems
    {
        public PlayerUpgradeValues upgradeEnum;
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

    public void UpdatePlayer(Dictionary<PlayerUpgradeValues, int> upgrades)
    {
        foreach (KeyValuePair<PlayerUpgradeValues, int> upgrade in upgrades)
        {

        }
    }
}
