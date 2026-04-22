using UnityEngine;

public class ScoreHolder : MonoBehaviour
{

    public int m_score;


    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("ScoreHolder");

        if (objs.Length > 1 )
        {
            Destroy(this.gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }

    public void F_addToScore(int m_scoreToAdd)
    {
        m_score += m_scoreToAdd;
    }

    public void F_removeScore()
    {
        m_score = 0;
    }
}
