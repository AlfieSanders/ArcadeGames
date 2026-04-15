using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    private int m_score = 0;
    public TMPro.TextMeshProUGUI m_scoreText;

    private void Update()
    {
        m_scoreText.text = "Score: " + m_score;
    }

    public void addToScore(int scoretoAdd)
    {
        m_score += scoretoAdd;
    }
}
