using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InformationUpdateTurtle : MonoBehaviour
{
    public TextMeshProUGUI defense,
        civilization,
        weapon;

    public TurtleController turtle;
    // Update is called once per frame
    void Update()
    {
        defense.text = "Health: " + turtle.currentHealth.ToString() + "\n"
            + "Armor: " + turtle.armorStrength;
        civilization.text = "Year: 2019" + //get information from gamemanager
            "\nPopulation: " + GameManager.Instance.population.ToString();
        weapon.text = "ChaRGE: 200/500" + //GetCurrent Charge and max Charge
            "\nDAmAgE: 2000";
    }
}
