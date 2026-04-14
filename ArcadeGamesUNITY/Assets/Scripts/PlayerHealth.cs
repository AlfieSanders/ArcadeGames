using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int m_maxHealth = 5;
    public TMPro.TextMeshProUGUI m_healthText;


    private void Update()
    {
        m_healthText.text = "Health: " + m_maxHealth;
    }
    public void F_takeDamage(int m_damage)
    {
         m_maxHealth -= m_damage;

    } 
        
}
