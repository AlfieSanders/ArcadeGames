using UnityEngine;

public class EnemyThrow : EnemyScript
{

    public Transform m_throwPoint;
    public Rigidbody m_projectile;

    

    public float m_speed;


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
        m_audioSource.PlayOneShot(m_attackNoise, 1f);
        Rigidbody brick = Instantiate(m_projectile,m_throwPoint.position,m_throwPoint.rotation);

        Vector3 dir = m_target.transform.position - transform.position;

        dir.y -= 2;

        brick.linearVelocity = dir * m_speed;
    }

}
