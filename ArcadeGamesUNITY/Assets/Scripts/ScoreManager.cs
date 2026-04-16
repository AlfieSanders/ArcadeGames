using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    private int m_score;
    public TMPro.TextMeshProUGUI m_scoreText;


    private void Start()
    {
        new HighScoreEntry(m_score);
       
    }

    private void Update()
    {
        m_scoreText.text = "Score: " + m_score;
    }

    public void addToScore(int scoretoAdd)
    {
        m_score += scoretoAdd;
    }
}
