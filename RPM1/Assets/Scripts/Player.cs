using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    public float Xincrement;

    public float speed;
    public float maxWidth;
    public float minWidth;
    public float maxHeight;
    public float minHeight;

    public int health = 5;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite full;
    public Sprite empty;

    string DATABASE_NAME = "/user.db";
    string conn;
    string sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;

    public string profileName;
    string proID;
    string dead;
    GameObject Text;
    //public Text MyText1;
    //public Text MyText2;

    void Start()
    {
        profileName = Profile.playerName;
        FindIDOnName();
        EnemyCount.enemys = 20;
        Score.scores = 0;
        //MyText1.text = "ID = " + proID.ToString();
        //MyText2.text = "ID = " + profileName.ToString();
    }
    void Update()
    {
        if(health <= 0 )
        {
            dead = Convert.ToString(Score.scores);
            string conn = "URI=file:" + Application.dataPath + "/user.db"; //Path to database.
            IDbConnection dbconn;
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "UPDATE Score SET Score = '" + dead + "'" + "WHERE Score.ID = '" + proID + "'";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;

            
            EnemyCount.enemys = 20;
            Score.scores = 0;
            SceneManager.LoadScene("SampleScene");
        }
        if (EnemyCount.enemys == 0)
        {
           
            dead = Convert.ToString(Score.scores);
            string conn = "URI=file:" + Application.dataPath + "/user.db"; //Path to database.
            IDbConnection dbconn;
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "UPDATE Score SET Score = '" + dead + "'" + "WHERE Score.ID = '" + proID + "'";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;

            EnemyCount.enemys = 20;
            Score.scores = 0;
            SceneManager.LoadScene("SampleScene");
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if(Input.GetKey(KeyCode.D) && transform.position.x < maxWidth)
        {
            targetPos = new Vector2(transform.position.x + Xincrement, transform.position.y);
        }
        else if (Input.GetKey(KeyCode.A) && transform.position.x > minWidth)
        {
            targetPos = new Vector2(transform.position.x - Xincrement, transform.position.y);
        }

        else if (Input.GetKey(KeyCode.W) && transform.position.y < maxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Xincrement);
        }
        else if (Input.GetKey(KeyCode.S) && transform.position.y > minHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Xincrement);
        }
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void FixedUpdate()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i<hearts.Length; i++)
        {
            if(i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = full;
            }
            else
            {
                hearts[i].sprite = empty;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void FindIDOnName()
    {

        string conn = "URI=file:" + Application.dataPath + "/user.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT ID FROM Username WHERE username = '"+profileName +"'";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int User = reader.GetInt32(0);
            proID = Convert.ToString(User);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
