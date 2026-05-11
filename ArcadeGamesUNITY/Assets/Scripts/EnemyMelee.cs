using UnityEngine;

public class EnemyMelee : EnemyScript
{
    private I_Damageable i_storedInterfaceRef;
    // child class of the enemy script 
    private void OnTriggerEnter(Collider other)
    {
        // when overlapping with the player, set animation trigger and get a reference to the player for damaging later on
        if (other.CompareTag("Player") == true)
        {
            I_Damageable damageableEntity = other.GetComponent<I_Damageable>();
            i_storedInterfaceRef = damageableEntity;

            m_agent.isStopped = true;
            m_animator.SetTrigger("Attack");
        }
    }

    // damage the player utilising the stored reference from earlier
    public void F_doDamage()
    {
        m_audioSource.PlayOneShot(m_attackNoise, 1f);
        if (i_storedInterfaceRef != null)
        {
            i_storedInterfaceRef.TakeDamage(1);
        }
    }


}




