using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;  // basic xml atrribs
using System.Xml.Serialization; // allows access to xmlserialiser
using System.IO; // file management
using System;

public class XMLManager : MonoBehaviour
{
    #region Singleton
    public static XMLManager instance = null;


    #endregion
    private void Start()
    {
        instance = this;
    }

    public static HighScores scores = new HighScores();

    // save score function
    public static void SaveScore()
    {
        //open xml file
        XmlSerializer serializer = new XmlSerializer(typeof(HighScores));
        FileStream stream;
        //check if highscores file exists        
        stream = new FileStream(Application.dataPath + "/Saves/HighScores.xml", FileMode.Create);       

        serializer.Serialize(stream, scores);
        stream.Close();
    }

    // load function
    public static void LoadHighScores()
    {
        //check if file exists
        if (File.Exists(Application.dataPath + "/Saves/HighScores.xml"))
        { 
            XmlSerializer serializer = new XmlSerializer(typeof(HighScores));
            // load the highscores file
            FileStream stream = new FileStream(Application.dataPath + "/Saves/HighScores.xml", FileMode.Open);

            scores = serializer.Deserialize(stream) as HighScores;

            stream.Close();
        }
    }

    // add new high score to 
    public static void AddHighScore(string name, int score, float timeAlive)
    {
        Debug.Log("AddHighScore");
        LoadHighScores();
        ScoreEntry newScore = new ScoreEntry
        {
            playerName = name,
            score = score,
            timeAlive = timeAlive
        };

        scores.list.Add(newScore);
    }
}

[System.Serializable]
public class ScoreEntry
{
    // Name of the player for high score list
    public string playerName;

    // the Score the player got on death (enemies killed)
    public int score;
    
    // time the player was able to stay alive    
    public float timeAlive;
}

[System.Serializable]
public class HighScores
{
    // the list of high scores
    [XmlArray("HighScores")]
    public List<ScoreEntry> list = new List<ScoreEntry>();
}


