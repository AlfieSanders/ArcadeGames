using UnityEngine;

public class ProjectileScript : MonoBehaviour, I_Connect
{
    // audio components
    private GameObject m_audioSource;
    public AudioClip m_glassBreak;
    private AudioSource m_AS;

     public void Start()
    {
        // has to find an external audio source as the projectile destroys itself. 
        m_audioSource = GameObject.FindGameObjectWithTag("GlassBreak");
         m_AS = m_audioSource.GetComponent<AudioSource>();
    }
    void I_Connect.onConnect()
    {
        // when shot, play audio and get destroyed
        m_AS.PlayOneShot(m_glassBreak, 1f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") == true)
        {
            // gets the player halth component of the player
            PlayerHealth m_player = other.GetComponent<PlayerHealth>();
            // player takes damage
            m_player.TakeDamage(1);
            // plays audio
            m_AS.PlayOneShot(m_glassBreak, 1f);
            Destroy(gameObject);

        }           
        
    }
}
