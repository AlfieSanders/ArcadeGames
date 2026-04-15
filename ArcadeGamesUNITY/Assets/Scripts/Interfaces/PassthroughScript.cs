using UnityEngine;

public class PassthroughScript : MonoBehaviour, I_Connect
{
    private EnemyScript m_enemyScript;
    
    void Start()
    {
       m_enemyScript = GetComponentInParent<EnemyScript>(); 
    }

   
    public void onConnect()
    {
        m_enemyScript.F_damage(1f);
    }


}
