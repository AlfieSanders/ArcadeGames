using UnityEngine;
using UnityEngine.UI;
public class ShootingScript : MonoBehaviour
{
    private Ray m_ray;
    private RaycastHit m_hit;
    
    private int m_ammo = 12;
    public TMPro.TextMeshProUGUI m_ammoText;

    private AudioSource m_audioSource;

    public AudioClip m_gunShot;
    public AudioClip m_gunShotDry;
    public AudioClip m_gunReload;

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        m_ray = Camera.main.ScreenPointToRay(mousePos);
        if(Input.GetMouseButtonDown(0) && m_ammo != 0)
        {
            
            m_ammo--;
            m_audioSource.PlayOneShot(m_gunShot, 1f);
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

        if(Input.GetMouseButton(0) && m_ammo == 0)
        {

            F_GunEmpty();

        }

        if(Input.GetMouseButtonDown(1) && m_ammo != 12)
            {
            m_audioSource.PlayOneShot(m_gunReload, 1f);
            m_ammo = 12;
        }


        m_ammoText.text = ("Ammo:" + m_ammo);

        if(m_ammo <=0)
        {
            m_ammoText.text = "RELOAD";
        }


    }


    private void F_GunEmpty()
    {
        m_audioSource.PlayOneShot(m_gunShotDry, 1f);
        
    }

    
}
