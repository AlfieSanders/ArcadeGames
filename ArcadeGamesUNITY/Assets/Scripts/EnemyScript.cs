using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    // the enemies health total
    public float m_health = 3f;

    [SerializeField] private GameObject m_target;
    [SerializeField] private ScoreManager m_scoreManager;
    NavMeshAgent m_agent;
    private Animator m_animator;
    private Rigidbody m_rb;
    private bool m_canBeHurt = true;
    
    private I_Damageable i_storedInterfaceRef;


    

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_agent = GetComponent<NavMeshAgent>();
        m_rb = GetComponent<Rigidbody>();
        m_scoreManager = FindFirstObjectByType<ScoreManager>();
        m_target = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void Update()
    {
        // on update set the destination to the player's location
        m_agent.SetDestination(m_target.transform.position);

        
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
            I_Damageable  damageableEntity = other.GetComponent<I_Damageable>();
            i_storedInterfaceRef = damageableEntity;

            m_agent.isStopped = true;
            m_animator.SetTrigger("Attack");
        }


    }
    public void F_Die()
    {
        m_scoreManager.addToScore(200);
        Destroy(gameObject);
    }

    public void F_doDamage()
    {
        if (i_storedInterfaceRef != null)
        {
            i_storedInterfaceRef.TakeDamage(1);
        }
        


    }

}
