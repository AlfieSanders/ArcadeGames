using UnityEngine;

public class PassthroughCivillian : MonoBehaviour, I_Connect
{
    // acts as a script to pass information from the civillians collider to the civillian script. 
    // lets the script know when it has been damaged by the raycast
    private CivillianScript m_civillianScript;
   
    [SerializeField] private GameObject m_Bloodeffect;
    [SerializeField] private Transform m_bloodLocation;
    void Start()
    {
        // asigns the civilian script variable
        m_civillianScript = GetComponentInParent<CivillianScript>();
    }

   
    public void onConnect()
    {
        // spawns a blood effect at the spawn location variable when taking damage
        Instantiate(m_Bloodeffect, m_bloodLocation);
        // talls the main script to take damage. 
        m_civillianScript.F_takeDamage(1);
    }


}
