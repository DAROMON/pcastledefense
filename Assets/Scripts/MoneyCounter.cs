using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    public MoneyBank Bank;
    public Text TextField;
    void Update()
    {
        TextField.text = Bank.Coins.ToString() + "x";
    }
}
