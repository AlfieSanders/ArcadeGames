using UnityEngine;
using UnityEngine.UI;
public class TestRay : MonoBehaviour
{
    private Ray m_ray;
    private RaycastHit m_hit;
    
    private int m_ammo = 6;
    public TMPro.TextMeshProUGUI m_ammoText;

    

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        m_ray = Camera.main.ScreenPointToRay(mousePos);
        if(Input.GetMouseButtonDown(0) && m_ammo != 0)
        {
            m_ammo--;
            if(Physics.Raycast(m_ray, out m_hit, 500f))
            {
                Debug.DrawLine(m_ray.origin, m_hit.transform.position, Color.red, 4f);
                Debug.Log(m_hit.collider);

                I_Connect capsule = m_hit.collider.GetComponent<I_Connect>();


                if (capsule != null)
                {
                    capsule.onConnect();
                    
                }
            }
        }

        if(Input.GetMouseButtonDown(1))
            {
            m_ammo = 6;
        }


        m_ammoText.text = ("Ammo:" + m_ammo);

        if(m_ammo <=0)
        {
            m_ammoText.text = "RELOAD";
        }


    }




    
}
