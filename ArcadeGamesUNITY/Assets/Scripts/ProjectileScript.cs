using UnityEngine;

public class ProjectileScript : MonoBehaviour, I_Connect
{
    private I_Damageable i_storedInterfaceRef;

    void I_Connect.onConnect()
    {     
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") == true)
        {
            PlayerHealth m_player = other.GetComponent<PlayerHealth>();
            m_player.TakeDamage(1);
            Destroy(gameObject);

        }
            

        
    }
}
