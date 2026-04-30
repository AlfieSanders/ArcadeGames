using UnityEngine;

public class PassthroughScript : MonoBehaviour, I_Connect
{
    private EnemyScript m_enemyScript;
   
    [SerializeField] private GameObject m_Bloodeffect;

    [SerializeField] private Transform m_bloodLocation;
    void Start()
    {
        m_enemyScript = GetComponentInParent<EnemyScript>();
    }

   
    public void onConnect()
    {
        Instantiate(m_Bloodeffect, m_bloodLocation);
        m_enemyScript.F_damage(1f);
    }


}
