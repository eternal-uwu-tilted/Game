using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
using System.Data;
using System;



public class Profile : MonoBehaviour
{
    [SerializeField] private InputField InName;
    private Text name;
    public static string playerName;

    string DATABASE_NAME = "/user.db";
    string conn;
    string sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;
    // Start is called before the first frame update
    void Start()
    {
        string filepath = Application.dataPath + DATABASE_NAME;
        conn = "URI=file:" + filepath;
        dbconn = new SqliteConnection(conn);
        CreateTable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Next()
    {
        if (InName.text != "")
        {    
            string conn = "URI=file:" + Application.dataPath + "/user.db"; //Path to database.
            IDbConnection dbconn;
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "INSERT INTO Username (username) VALUES('"+ InName.text + "')";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
            InsT();
            playerName = InName.text;
            SceneManager.LoadScene("MainMenu");
        }

    }
    private void CreateTable()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();

            sqlQuery = "CREATE TABLE IF NOT EXISTS [Username](" +
        "[ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
        "username  TEXT)";
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();

            sqlQuery = "CREATE TABLE IF NOT EXISTS [Score](" +
        "[ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
        "Score  INTEGER)";
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }
    private void InsT()
    {
        string conn = "URI=file:" + Application.dataPath + "/user.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "INSERT INTO Score ('Score') SELECT  '0'";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
