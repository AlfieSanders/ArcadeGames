using System.Collections;
using UnityEngine;

public class GameOverControl : MonoBehaviour
{
    private ScoreManager m_scoreManager;
    // UI elements
    public GameObject m_gameOver;
    public GameObject m_continue;

    // various scripts needed to interact with
    public SceneControl m_sceneManager;
    public PlayerHealth m_playerHealth;
    private CreditHolder m_creditHolder;
    public ShootingScript m_shootingScript;

    
    void Start()
    {
        // asigns script variables for the single instance scripts that exist in the Main Menu script
        m_creditHolder = FindFirstObjectByType<CreditHolder>();
        m_scoreManager = FindFirstObjectByType<ScoreManager>();
    }

  public void F_gameOverSequence()
    {
        // time scale =0 pauses the gameplay
        Time.timeScale = 0;
        // activates the gameover screen
        m_gameOver.SetActive(true);
        // saves scores for the highscore
        m_scoreManager.SaveScoresToFile();   
        // activates the continue button
        m_continue.SetActive(true);
        StartCoroutine("I_sequence");
    }


    private IEnumerator I_sequence()
    {
          // waits for 10 seconds and then resets timescale
            yield return new WaitForSecondsRealtime(10);
            Time.timeScale = 1;
        // removes the players current score
            m_scoreManager.F_removeScore();
        // opens the main menu
            m_sceneManager.F_openMenu();   
    }


    public void F_continue()
    {
        // if the continue button is pressed, stops the coroutine
        StopCoroutine("I_sequence");
        // removes a credit
        m_creditHolder.F_removeCredit();
        // resests timescale
        Time.timeScale = 1;
        // deactivates the gameoverUI
        m_gameOver.SetActive(false);
        // resets health and makes the player invulnerable for a set duration
        m_playerHealth.m_maxHealth = 5;
        m_playerHealth.m_canBeHurt = false;
        // gives the player 50 ammo
        m_shootingScript.m_ammo = 50;
        // deactivates the "continue?" UI
        m_continue.SetActive(false);
        StartCoroutine("I_invulnerable");

        

    }

    private IEnumerator I_invulnerable()
    {
        // resets the players ammo and invulnerablitity after 7 seconds. 
        yield return new WaitForSeconds(7);
        m_playerHealth.m_canBeHurt = true;
        m_shootingScript.m_ammo = 12;

    }
}
