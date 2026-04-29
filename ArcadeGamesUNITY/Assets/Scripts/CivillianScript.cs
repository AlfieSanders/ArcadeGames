using UnityEngine;
using UnityEngine.AI;

public class CivillianScript : MonoBehaviour
{
    private float m_health = 1f;
    private GameObject m_target;
    private ScoreManager m_scoreManager;
    private PlayerHealth m_playerHealth;
    NavMeshAgent m_agent;
    private Animator m_animator;
    private bool m_canBeHurt = true;
   
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_agent = GetComponent<NavMeshAgent>();
        m_scoreManager = FindFirstObjectByType<ScoreManager>();
        m_target = GameObject.FindGameObjectWithTag("Safety");
        m_playerHealth = FindFirstObjectByType<PlayerHealth>();
    }

    
    void Update()
    {
        m_agent.SetDestination(m_target.transform.position);
    }


    private void OnTriggerEnter(Collider other)
    {
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
            m_canBeHurt = false;
            m_agent.isStopped = true;
            m_playerHealth.TakeDamage(1);
            m_scoreManager.F_addToScore(-500);
            m_animator.SetTrigger("Death");
        }
    }

    public void F_Die()
    {
        Destroy(gameObject);
    }
}
