using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    // the enemies health total
    public float m_health = 3f;

    [SerializeField] private Transform m_target;
    NavMeshAgent m_agent;
    private Animator m_animator;
    private Rigidbody m_rb;
    private bool m_canBeHurt = true;
    [SerializeField] private GameObject m_player;
    private PlayerHealth m_playerhealth;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_agent = GetComponent<NavMeshAgent>();
        m_rb = GetComponent<Rigidbody>();
        
        
    }

    private void Update()
    {
        m_agent.SetDestination(m_target.position);

        
    }
    public void F_damage(float damageAmount)
    {
       
            // take damage from health when fucntion is called
            m_health -= damageAmount;
        
        // check if health is below zero
        if(m_health <= 0 && m_canBeHurt == true)
        {
            
            m_canBeHurt = false;
            // deactivate when health is below zero.
            
            m_agent.isStopped = true;
            m_animator.SetTrigger("Death");
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            m_agent.speed = 0f;
            m_animator.SetTrigger("Attack");
        }


    }
    public void F_Die()
    {
        Destroy(gameObject);
    }

    public void F_doDamage()
    {
        m_playerhealth.F_takeDamage(1);
    }

}
