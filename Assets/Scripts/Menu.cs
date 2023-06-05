using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Xml.Linq;
using System;
using UnityEngine.SocialPlatforms.Impl;
using System.Data;

public class Menu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject RecordsMenu;
    public GameObject ExitMenu;
    public Text scoreText;
    string dbName = "URI=file:Records.db";
    private void Start()
    {
        CreateDB();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenRecords()
    {
        UpdateRecords();
        MainMenu.SetActive(false);
        RecordsMenu.SetActive(true);
    }
    public void GoBack()
    {
        MainMenu.SetActive(true);
        RecordsMenu.SetActive(false);
    }
    public void TryExit()
    {
        MainMenu.SetActive(false);
        ExitMenu.SetActive(true);
    }
    public void ExitYes()
    {
        Application.Quit();
    }
    public void ExitNo()
    {
        MainMenu.SetActive(true);
        ExitMenu.SetActive(false);
    }
    void CreateDB()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS records (id INTEGER PRIMARY KEY, time TEXT DEFAULT CURRENT_TIMESTAMP, wave INTEGER, value INTEGER);";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
    void UpdateRecords()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT date (time) as dt, wave, value FROM Records ORDER BY value DESC LIMIT 5;";
                using (IDataReader reader = command.ExecuteReader())
                {
                    int i = 1;
                    scoreText.text = "";
                    while (reader.Read())
                    {
                        scoreText.text += i.ToString() + ")\t" + reader["dt"] + "\t" + reader["wave"] + "\t" + reader["value"] + "\n";
                        i++;
                    }
                }
            }
            connection.Close();
        }
    }
}
