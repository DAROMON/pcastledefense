using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.TestTools.CodeCoverage;
using UnityEngine;
using UnityEngine.UI;

public class BuyMenu : MonoBehaviour
{
    public MoneyBank Bank;
    public int BuildCost = 100;
    public int UpgradeCost = 80;
    public float Multiplier = 1;
    Placement Placement;
    public GameObject BuyB;
    public GameObject UpgradeB;
    public GameObject Menu;
    public Text upgradeText;
    int level;
    public void SetPlacement(Placement place, int lvl)
    {
        UpgradeCost = 80;
        level = lvl;
        Placement = place;
        if (lvl > 0)
        {
            BuyB.SetActive(false);
            UpgradeB.SetActive(true);
            UpgradeCost = (int)(UpgradeCost * (level * (float)0.5));
            upgradeText.text = "Улучшить x" + UpgradeCost.ToString();
        }
        else
        {
            BuyB.SetActive(true);
            UpgradeB.SetActive(false);
        }
    }
    public void Build()
    {
        if (Bank.Coins >= BuildCost)
        {
            Bank.Coins -= BuildCost;
            Placement.Build();
        }
    }
    public void Upgrade()
    {
        if (Bank.Coins >= UpgradeCost)
        {
            Bank.Coins -= UpgradeCost;
            Placement.Upgrade();
        }
    }
    public void Close()
    {
        Menu.SetActive(false);
    }
}
