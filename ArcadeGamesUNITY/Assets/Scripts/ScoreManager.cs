using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    private int m_localScore;
    private int m_score;
    private int m_highscore = 0;

    public TMPro.TextMeshProUGUI m_scoreText;


    public TMPro.TextMeshProUGUI m_highScoreText;

    private void Awake()
    {
        LoadScoreFromFile();
    }
    private void Update()
    {
        m_scoreText.text = "Score: " + m_score;

        if (m_highScoreText != null)
        {
            m_highScoreText.text = "HighScore: " + m_highscore;
        }
        
       
    }

    public void addToScore(int scoretoAdd)
    {
        m_score += scoretoAdd;
    }

    public void removeScore()
    {
        m_score = 0;
    }

    public void SaveScoresToFile()
    {
        ScoreEntry scores = new ScoreEntry(m_score);

        string json = JsonUtility.ToJson(scores, true);

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

            if (scores != null)
            {
                m_score = scores.Score;
            }
        }
    }
}
