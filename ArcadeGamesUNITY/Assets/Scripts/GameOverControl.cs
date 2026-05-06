using System.Collections;
using UnityEngine;

public class GameOverControl : MonoBehaviour
{
    private ScoreManager m_scoreManager;
    public GameObject m_gameOver;
    public GameObject m_continue;
    public SceneControl m_sceneManager;


    void Start()
    {
        m_scoreManager = FindFirstObjectByType<ScoreManager>();
    }

  public void F_gameOverSequence()
    {
        Time.timeScale = 0;
        m_gameOver.SetActive(true);
        m_scoreManager.SaveScoresToFile();      
        m_continue.SetActive(true);
        StartCoroutine("I_sequence");
    }


    IEnumerator I_sequence()
    {
        
        yield return new WaitForSecondsRealtime(10);
        Time.timeScale = 1;
        m_scoreManager.F_removeScore();
        m_sceneManager.F_openMenu();


    }
}
