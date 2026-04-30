using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    
    private float m_health;

    protected GameObject m_target;
    private ScoreManager m_scoreManager;
    public NavMeshAgent m_agent;
    public Animator m_animator;
    
    private bool m_canBeHurt = true;
    
    


    

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_agent = GetComponent<NavMeshAgent>();
          
        m_scoreManager = FindFirstObjectByType<ScoreManager>();
        m_target = GameObject.FindGameObjectWithTag("Player");


        m_health = Random.Range(3f, 6f);
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

            m_scoreManager.F_addToScore(200);
            m_agent.isStopped = true;
            m_animator.SetTrigger("Death");
            
        }
        
    }

   
    public void F_Die()
    {
       
        Destroy(gameObject);
    } 
}
