using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class ScoreManager : MonoBehaviour
{   
    // score variables
    public int m_score;
    public int m_highscore = 0;

    private void Awake()
    {
        // single instance class, destroys matching objects to avoid conflicts
        GameObject[] objs = GameObject.FindGameObjectsWithTag("ScoreHolder");

        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }




    public void F_addToScore(int m_scoreToAdd)
    {
        m_score += m_scoreToAdd;
    }

    public void F_removeScore()
    {
        m_score = 0;
    }

    // score saving using Json files- follows tutorial shown in lesson
    public void SaveScoresToFile()
    {
        if(m_score > m_highscore)
        {
            m_highscore = m_score;
        }
      
        ScoreEntry scores = new ScoreEntry(m_highscore);

        string json = JsonUtility.ToJson(scores, true);
        
        // filepath uses my own intitials to make it unique- avoid conflicting Json files if project is loaded onto the same machine as another project
        string filepath = Path.Combine(Application.persistentDataPath, "AJSCurrentscore.json");    

        File.WriteAllText(filepath, json);
    }


    public void LoadScoreFromFile()
    {
        string filepath = Path.Combine(Application.persistentDataPath, "AJSCurrentscore.json");

        if(File.Exists(filepath))
        {
            string json = File.ReadAllText(filepath);

            ScoreEntry scores = JsonUtility.FromJson<ScoreEntry>(json);
                              
                m_highscore = scores.Highscore;                           
        }
    }
}
