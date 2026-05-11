using UnityEngine;

public class PassthroughScript : MonoBehaviour, I_Connect
{
     // acts as a script to pass information from the enemies collider to the enemy script. 
    // lets the script know when it has been damaged by the raycast
    private EnemyScript m_enemyScript;
  
    [SerializeField] private GameObject m_Bloodeffect;
    [SerializeField] private Transform m_bloodLocation;
    void Start()
    {
        // asigns the enemy script variable
        m_enemyScript = GetComponentInParent<EnemyScript>();
    }

   
    public void onConnect()
    {
        // spawns the blood particle effect at the specified location
        Instantiate(m_Bloodeffect, m_bloodLocation);
        m_enemyScript.F_damage(1f);
    }


}
