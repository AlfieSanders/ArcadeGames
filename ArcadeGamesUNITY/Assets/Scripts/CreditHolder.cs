using UnityEngine;

public class CreditHolder : MonoBehaviour
{

    public int m_credits = 0;
    // audio components 
    public AudioClip m_coinUp;
    private AudioSource m_audioSource;
    private void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
        // creates a single instance of the creditHolder and deletes any extras to avoid conflicts
        GameObject[] objs = GameObject.FindGameObjectsWithTag("CreditHolder");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }


    void Update()
    {
        // when pressign space, add a credit and play the audioclip
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_audioSource.PlayOneShot(m_coinUp);
            m_credits++;
        }
    }

    // remove credit function to trigger when playing the game or using the "continue" system 
    public void F_removeCredit()
    {
        m_credits--;
    }
}
