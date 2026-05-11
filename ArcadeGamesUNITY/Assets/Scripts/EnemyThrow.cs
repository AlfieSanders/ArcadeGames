using UnityEngine;

public class EnemyThrow : EnemyScript
{
    // child class of the base enemy script

    // thowing componenets: where to spawn the projectile, what projectile to spawn and how fast tp throw it;
    public Transform m_throwPoint;
    public Rigidbody m_projectile;   
    public float m_speed;


    // when colliding with the player, set attack trigger and stop movement
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
        // plays audio clip
        m_audioSource.PlayOneShot(m_attackNoise, 1f);
        // instantiates projectile
        Rigidbody brick = Instantiate(m_projectile,m_throwPoint.position,m_throwPoint.rotation);
        // direction of throw = players postion - enemies current position
        Vector3 dir = m_target.transform.position - transform.position;
        // offsets direction so it accurately hits the player
        dir.y -= 2;
        brick.linearVelocity = dir * m_speed;
    }

}
