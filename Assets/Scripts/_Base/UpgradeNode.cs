﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class UpgradeNode : MonoBehaviour
{

    public Button UpgradeButton,
        DowngradeButton;

    public List<int> CostOfUpgrades;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Upgrade()
    {

    }

    public virtual void DownGrade()
    {

    }

}
