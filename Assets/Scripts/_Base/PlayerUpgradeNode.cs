using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradeNode : UpgradeNode
{

    public PlayerUpgradeValues upgrade;
    

    // Start is called before the first frame update
    void Start()
    {
        if (UpgradeButton != null)
        {
            UpgradeButton.onClick.AddListener(() => Upgrade());
        }
        if (DowngradeButton != null)
        {
            DowngradeButton.onClick.AddListener(() => DownGrade());
        }
        UpdateLevelInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Upgrade()
    {
        int level = GameManager.Instance.GetCurrentUpgradeLevel(upgrade);
        if (level < CostOfUpgrades.Count)
        {
            if (!GameManager.Instance.AddPlayerUpgrade(upgrade, CostOfUpgrades[level]))
            {
                Debug.Log("Wasnt able to purchase the upgrade not enough money.");
            }
            UpdateLevelInfo();
        }
        else
        {
            Debug.Log("Fully Upgraded");
        }
    }

    public override void DownGrade()
    {
        int level = GameManager.Instance.GetCurrentUpgradeLevel(upgrade);
        if (level > CostOfUpgrades.Count && level < CostOfUpgrades.Count)
        {
            GameManager.Instance.SubtractPlayerUpgrade(upgrade, CostOfUpgrades[level]);
            UpdateLevelInfo();
        }
    }

    public override void UpdateLevelInfo()
    {
        int value = GameManager.Instance.GetCurrentUpgradeLevel(upgrade);
        for (int i = 0; i < UpgradeSprite.Count; i++)
        {
            if (i < value)
            {
                UpgradeSprite[i].SetActive(true);
            }
            else
            {
                UpgradeSprite[i].SetActive(false);
            }
        }
    }
}
