using UnityEngine;
using UnityEngine.UI;
public class ShootingScript : MonoBehaviour
{
    private Ray m_ray;
    private RaycastHit m_hit;
    
    public int m_ammo = 12;
    // UI variable
    public TMPro.TextMeshProUGUI m_ammoText;

    
    private PlayerHealth m_playerHealth;
    private float m_health;
    // audio components
    public AudioClip m_gunShot;
    public AudioClip m_gunShotDry;
    public AudioClip m_gunReload;
    private AudioSource m_audioSource;

    private void Start()
    {// Initialisation asigns variables
        m_audioSource = GetComponent<AudioSource>();
        m_playerHealth = GetComponent<PlayerHealth>();
       
    }


    void Update()
    {
        // tracks the players health
        m_health = m_playerHealth.m_maxHealth;
  
        // gets the mouse position and fires a raycast from the mouse directly forward
        Vector3 mousePos = Input.mousePosition;
        m_ray = Camera.main.ScreenPointToRay(mousePos);
        if(Input.GetMouseButtonDown(0) && m_ammo > 0  && m_health !=0)
        {
            //reduces ammo
            m_ammo--;
            //plays audio clip
            m_audioSource.PlayOneShot(m_gunShot, 1f);
            
            if(Physics.Raycast(m_ray, out m_hit, 500f))
            {    
                // uses an interface to passthrough information on whatver to hits
                I_Connect capsule = m_hit.collider.GetComponent<I_Connect>();
                if (capsule != null)
                {
                    capsule.onConnect();               
                }
            }
        } 
        // reloads the gun
        if(Input.GetMouseButtonDown(1) && m_ammo != 12)
        {
            m_audioSource.PlayOneShot(m_gunReload, 1f);
            m_ammo = 12;
        }

        // updates the UI
        m_ammoText.text = ("Ammo:" + m_ammo);
        if(m_ammo <=0)
        {
            m_ammoText.text = "RELOAD";
        }
    }

    // if ammo is less than 0 plays a different audio clip, uses fixed update to avoid playing clip every frame
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && m_ammo <= 0)
        {
            m_audioSource.PlayOneShot(m_gunShotDry);
            m_ammo--;
        }
    }





}
