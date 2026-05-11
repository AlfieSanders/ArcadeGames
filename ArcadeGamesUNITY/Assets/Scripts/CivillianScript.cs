using UnityEngine;
using UnityEngine.AI;

public class CivillianScript : MonoBehaviour
{
    // civilian has 1 health
    private float m_health = 1f;
    // target is the player
    private GameObject m_target;
    //the scoremanager and playerhealth script for damaging the layer and adding negative score. 
    private ScoreManager m_scoreManager;
    private PlayerHealth m_playerHealth;
    // agent is used for navigation
    NavMeshAgent m_agent;
    private Animator m_animator;
    // stops the civilian from being shot whilst the death animation plays. 
    private bool m_canBeHurt = true;

    // audio componenets
    private AudioSource m_audioSource;
    public AudioClip m_scream;
   
    void Start()
    {
        // initialisation asigns all variables 
        m_animator = GetComponent<Animator>();
        m_agent = GetComponent<NavMeshAgent>();
        m_scoreManager = FindFirstObjectByType<ScoreManager>();
        m_target = GameObject.FindGameObjectWithTag("Safety");
        m_playerHealth = FindFirstObjectByType<PlayerHealth>();
        m_audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        // tells the navmesh agent to go towards the player
        m_agent.SetDestination(m_target.transform.position);
    }


    private void OnTriggerEnter(Collider other)
    {
        // when colliding with the "safety" trigger, destroys itself and adds 500 pts
        if(other.CompareTag("Safety") == true)
        {
            m_scoreManager.F_addToScore(500);
            Destroy(gameObject);
        }
    }

    public void F_takeDamage(float damageAmount)
    {
        m_health -= damageAmount; 

        if(m_health <=0 && m_canBeHurt == true)
        {
            // plays the scream audioclip
            m_audioSource.PlayOneShot(m_scream, 1f);
            // stops movement and being able to be damage
            m_canBeHurt = false;
            m_agent.isStopped = true;
            // cause the player to take damage and add negative score
            m_playerHealth.TakeDamage(1);
            m_scoreManager.F_addToScore(-500);
            // triggers the death animation
            m_animator.SetTrigger("Death");
        }
    }

    public void F_Die()
    {
        Destroy(gameObject);
    }
}
