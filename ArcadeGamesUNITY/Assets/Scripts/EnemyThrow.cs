using UnityEngine;

public class EnemyThrow : EnemyScript
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            m_agent.isStopped = true;
            m_animator.SetTrigger("Attack");
        }
    }


    public void F_throwProjectile()
    {
        Debug.Log("Brick!!");
    }

}
