using UnityEngine;
using UnityEngine.UI;
public class UIControl : MonoBehaviour
{
    public TMPro.TextMeshProUGUI m_score;
    public TMPro.TextMeshProUGUI m_highScore;


    private ScoreManager m_scoreManager;


    private void Start()
    {
        m_scoreManager = FindFirstObjectByType<ScoreManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (m_score != null)
        {
            m_score.text = "Score: " + m_scoreManager.m_score;
        }

        if (m_highScore != null)
        {
            m_highScore.text = "Highscore: " + m_scoreManager.m_highscore;
        }
        else
        {
            return;
        }
    }
}
