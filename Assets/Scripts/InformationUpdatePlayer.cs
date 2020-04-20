using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InformationUpdatePlayer : MonoBehaviour
{
    public TextMeshProUGUI weapon1Text,
           weapon2Text,
           weapon3Text;

    public Weapon weapon1,
        weapon2,
        weapon3;
    // Update is called once per frame
    void Update()
    {
        weapon1Text.text = "FireRate: " + weapon1.firerate + "\n"
            + "DAMaGE: " + weapon1.currentDamage;
        weapon2Text.text = "FireRate: " + weapon2.firerate + "\n"
            + "DAMaGE: " + weapon2.currentDamage;
        weapon3Text.text = "FireRate: " + weapon3.firerate + "\n"
            + "DAMaGE: " + weapon3.currentDamage + "\n" +
            "\tExplosive Shots!";
    }
}
