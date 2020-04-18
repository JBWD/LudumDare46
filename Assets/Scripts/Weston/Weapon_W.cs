using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Weapon : MonoBehaviour
{

    public int _baseDamage = 20;
    public int damageRange = 10;
    [SerializeField]
    private int currentDamage = 20;
    [SerializeField]
    private float currentFireRate = .5f;
    public int upgradeDamageChanger =  6;
    public float fireRateChanger = .05f;


    public void UpdateWeapon(int upgrade)
    {
        currentDamage = _baseDamage + upgrade * upgradeDamageChanger;
        currentFireRate = firerate - upgrade * fireRateChanger;
    }
}
