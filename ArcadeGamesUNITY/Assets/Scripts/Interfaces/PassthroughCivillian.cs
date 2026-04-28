using UnityEngine;

public class PassthroughCivillian : MonoBehaviour, I_Connect
{
    private CivillianScript m_civillianScript;
   
    [SerializeField] private GameObject m_Bloodeffect;
    [SerializeField] private Transform m_bloodLocation;
    void Start()
    {
        m_civillianScript = GetComponentInParent<CivillianScript>();
    }

   
    public void onConnect()
    {
        Instantiate(m_Bloodeffect, m_bloodLocation);
        m_civillianScript.F_takeDamage(1);
    }


}
