using UnityEngine;

public class TestRay : MonoBehaviour
{
    private Ray m_ray;
    private RaycastHit m_hit;
    
    private float m_gunDamage = 1f;

    [SerializeField] private GameObject m_BloodEffect;
    

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        m_ray = Camera.main.ScreenPointToRay(mousePos);
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(m_ray, out m_hit, 500f))
            {
                Debug.DrawLine(m_ray.origin, m_hit.transform.position, Color.red, 2.5f);
                I_Connect capsule = m_hit.collider.GetComponent<I_Connect>();


                if (capsule != null)
                {
                    capsule.onConnect();
                    
                }
            }
        }
    }
}
