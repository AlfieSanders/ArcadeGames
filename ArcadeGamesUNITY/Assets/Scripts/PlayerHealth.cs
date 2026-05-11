using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, I_Damageable
{
    public int m_maxHealth = 5;
    // UI
    public TMPro.TextMeshProUGUI m_healthText;
    // stops the player from being hurt further and leading to negative health
    public bool m_canBeHurt = true;  
    public UnityEvent playerDeath;
    // vars for damage feedback
    public Animator m_hurtFlash;   
    private Animator m_cameraAnim;
    // audio components for damage feedback
    private AudioSource m_audioSource;
    public AudioClip m_gasp;

    private void Awake()
    {  
        // asigns the camera animator variable
        m_cameraAnim = Camera.main.GetComponent<Animator>();        
    }
    private void Start()
    {
        // asigns the audio source component
        m_audioSource = GetComponent<AudioSource>();           
    }
    private void Update()
    {
        // updates the health UI
        m_healthText.text = "Health: " + m_maxHealth;
    }
    public void TakeDamage(int m_damage)
    {
        if(m_canBeHurt == true)
        {
            // plays audioclip
            m_audioSource.PlayOneShot(m_gasp, 1f);
            // plays the camera shake and red flash animation
            m_cameraAnim.SetTrigger("IsHurt");
            m_hurtFlash.SetTrigger("IsHurt");
            // takes damage
            m_maxHealth -= m_damage;
            

        }
        
        // Invokes the player death event which then triggers the game over sequence
        if (m_maxHealth <= 0)
        {
            m_canBeHurt = false;
            
            playerDeath.Invoke();
        }
    } 
        
}
