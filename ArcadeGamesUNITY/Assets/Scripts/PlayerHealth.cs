using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, I_Damageable
{
    public int m_maxHealth = 5;
    public TMPro.TextMeshProUGUI m_healthText;


    private void Update()
    {
        m_healthText.text = "Health: " + m_maxHealth;
    }
    public void TakeDamage(int m_damage)
    {
         m_maxHealth -= m_damage;

    } 
        
}
