using UnityEngine;
using UnityEngine.UI;
public class UIControl : MonoBehaviour
{
    public TMPro.TextMeshProUGUI m_score;
    public TMPro.TextMeshProUGUI m_highScore;
    public TMPro.TextMeshProUGUI m_playButton;

    private CreditHolder m_creditHolder;
    private ScoreManager m_scoreManager;


    private void Start()
    {
        m_creditHolder = FindFirstObjectByType<CreditHolder>();
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

        if (m_playButton != null && m_creditHolder.m_credits > 0)

        {
            m_playButton.text = "Shoot here to play";
        }
        else if(m_playButton != null)
        {
            m_playButton.text = "Insert credit to play";
        }
    }
}
