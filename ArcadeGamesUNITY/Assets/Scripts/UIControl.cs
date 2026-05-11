using UnityEngine;
using UnityEngine.UI;
public class UIControl : MonoBehaviour
{
    // Ui variables
    public TMPro.TextMeshProUGUI m_score;
    public TMPro.TextMeshProUGUI m_highScore;
    public TMPro.TextMeshProUGUI m_playButton;

    // scripts with necessary information for the UI
    private CreditHolder m_creditHolder;
    private ScoreManager m_scoreManager;


    private void Start()
    {
        // initialisation asigns the variables
        m_creditHolder = FindFirstObjectByType<CreditHolder>();
        m_scoreManager = FindFirstObjectByType<ScoreManager>();
    }
    // Update is called once per frame
    void Update()
    {
        // null reference checks and then asigns each text object accordingly
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
