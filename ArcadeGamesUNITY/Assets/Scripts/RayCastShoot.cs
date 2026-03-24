using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayCastShoot : MonoBehaviour
{
    // amount of damage the gun does
   private float m_gunDamage = 1;
    //how often the gun can shoot
   private float m_fireRate = 1f;

    
    private WaitForSeconds m_shotDuration = new WaitForSeconds(0.07f);
    private LineRenderer m_laserLine;
    private float m_nextFire;
    private Camera m_mainCam;
    
    void Start()
    {
        m_laserLine = GetComponent<LineRenderer>();

        m_mainCam = GetComponent<Camera>();
    }

   
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > m_nextFire)
        {
            
            m_nextFire = Time.time + m_fireRate;


            Debug.Log("shooting");

            StartCoroutine(IE_shotEffect());

            //Vector2 m_mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 m_rayOrigin = m_mainCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            RaycastHit hit;

            m_laserLine.SetPosition(0, m_rayOrigin);

            if (Physics.Raycast(m_rayOrigin, m_mainCam.transform.forward, out hit, 100f))
            {
                m_laserLine.SetPosition(1, hit.point);

                EnemyScript health = hit.collider.GetComponent<EnemyScript>();

                Debug.Log("hitSomething!");


                if (health != null)
                {
                    Debug.Log("bang");
                    health.F_damage(m_gunDamage);
                }

            }
            else
            {
                m_laserLine.SetPosition(1, m_rayOrigin + (m_mainCam.transform.forward * 100f));
            }
        }
    }
    
    private IEnumerator IE_shotEffect()
    {
        //Debug.Log("Line");
        m_laserLine.enabled = true;
        yield return m_shotDuration;
        m_laserLine.enabled = false;
    }
}
