using UnityEngine;

public class CreditHolder : MonoBehaviour
{
    public int m_credits = 0;
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("CreditHolder");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_credits++;
        }
    }

    public void F_removeCredit()
    {
        m_credits--;
    }
}
