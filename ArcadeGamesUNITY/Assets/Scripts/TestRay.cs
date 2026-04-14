using UnityEngine;

public class TestRay : MonoBehaviour
{
    private Ray m_ray;
    private RaycastHit m_hit;

    private float m_gunDamage = 1f;
 
    
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        m_ray = Camera.main.ScreenPointToRay(mousePos);
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(m_ray, out m_hit, 1000f))
            {
                EnemyScript health = m_hit.collider.GetComponent<EnemyScript>();


                //Debug.Log(m_hit.transform.gameObject.name);

                if (health != null)
                {
                    Debug.Log("bang");
                    health.F_damage(m_gunDamage);
                }
            }
        }
    }
}
