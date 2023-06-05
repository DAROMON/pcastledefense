using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;

public class ScoreManager : MonoBehaviour
{
    public SpawnMonsters Spawner;
    string dbName = "URI=file:Records.db";
    public void EndGame()
    {
        AddRecord(Spawner.GetScore(), Spawner.GetWave());
    }

    void AddRecord(int score, int wave)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO records (time, wave, value) VALUES ('" + DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss") + "', '" + wave + "', '" + score + "');";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}
