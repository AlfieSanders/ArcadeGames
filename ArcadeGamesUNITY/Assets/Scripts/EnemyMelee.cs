using UnityEngine;

public class EnemyMelee : EnemyScript
{
    private I_Damageable i_storedInterfaceRef;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            I_Damageable damageableEntity = other.GetComponent<I_Damageable>();
            i_storedInterfaceRef = damageableEntity;

            m_agent.isStopped = true;
            m_animator.SetTrigger("Attack");
        }
    }
    public void F_doDamage()
    {
        if (i_storedInterfaceRef != null)
        {
            i_storedInterfaceRef.TakeDamage(1);
        }
    }


}




