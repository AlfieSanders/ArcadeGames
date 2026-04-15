using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, I_Damageable
{
    public int m_maxHealth = 5;
    public TMPro.TextMeshProUGUI m_healthText;
    public GameObject m_gameOver;
    private bool m_canBeHurt = true;

    private void Start()
    {
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
        }
    } 
        
}
