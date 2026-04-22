using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, I_Damageable
{
    public int m_maxHealth = 5;
    public TMPro.TextMeshProUGUI m_healthText;
    public GameObject m_gameOver;
    private bool m_canBeHurt = true;

    private ScoreManager m_scoreManager;

    public UnityEvent playerDeath;

    private void Awake()
    {
        
        m_scoreManager = FindFirstObjectByType<ScoreManager>();
    }
    private void Start()
    {
        
        m_scoreManager.F_removeScore();
        m_gameOver.SetActive(false);
    }
    private void Update()
    {
        m_healthText.text = "Health: " + m_maxHealth;
    }
    public void TakeDamage(int m_damage)
    {
        if(m_canBeHurt == true)
        {
            m_maxHealth -= m_damage;
        }
        
        if (m_maxHealth <= 0)
        {
            m_canBeHurt = false;
            m_gameOver.SetActive(true);
            m_scoreManager.SaveScoresToFile();
            playerDeath.Invoke();
        }
    } 
        
}
