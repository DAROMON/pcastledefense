using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyBank : MonoBehaviour
{
    public int Coins = 0;
    public float MoneyBoost = 1;
    public int MoneySpeed = 1;
    public int health = 1000;
    public GameObject LoseMenu;
    public HealthBar healthBar;
    float lastGived;
    public ScoreManager scoreManager;
    void Start()
    {
        Time.timeScale = 1;
        //InvokeRepeating("AddMoney", 0, MoneySpeed / MoneyBoost);
        healthBar.SetMaxHealth(health);
        lastGived = Time.time;
    }
    private void Update()
    {
        if (Time.time - lastGived > MoneySpeed / MoneyBoost)
        {
            lastGived = Time.time;
            AddMoney();
        }
    }
    public void AddMoney()
    {
        Coins += 5;
    }
    public void TakeDamage(int dmg)
    {
        health -= dmg;
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            LoseMenu.SetActive(true);
            scoreManager.EndGame();
            Time.timeScale = 0;
            health = 9900;
        }
    }
    public void EarnBoost()
    {
        if (MoneyBoost < 5)
            MoneyBoost += (float)0.01;
    }
}
