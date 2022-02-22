using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class Lead : MonoBehaviour
{
    GameObject text;
    string DATABASE_NAME = "/user.db";
    string conn;
    string sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;
    // Start is called before the first frame update
    void Start()
    {
        ReadDB();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ReadDB()
    {

        string conn = "URI=file:" + Application.dataPath + "/user.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT DISTINCT Username.username, Score.Score " + "FROM Username, Score " + "WHERE Username.ID = Score.ID ORDER BY Score DESC";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            string User = reader.GetString(0);
            int Score = reader.GetInt32(1);
            GameObject.Find("Player").GetComponent<UnityEngine.UI.Text>().text += User +"\n";
            GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>().text += Convert.ToString(Score) + "\n";


        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
